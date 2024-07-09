using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TeklifVer.Business.Abstract;
using TeklifVer.Dto.Car;
using TeklifVer.Dto.Offer;

namespace TeklifVer.UI.Controllers
{

    public class AdvertisingController : Controller
    {
        private readonly IAdvertisingService _advertisingService;
        private readonly IOfferService _offerService;
        public AdvertisingController(IAdvertisingService advertisingService, IOfferService offerService)
        {
            _advertisingService = advertisingService;
            _offerService = offerService;
        }

        [Route("İlanlar")]
        public IActionResult Index()
        {
            var result = _advertisingService.GetAll();
            ViewBag.CustomCss = "Advertising/AdvertisingList.css";
            return result.IsSuccess ? View(result.Data) : View();
        }

        [Route("İlan/Detay/{id}")]
        public IActionResult Details(int id)
        {
            var result = _advertisingService.GetById(id);
            ViewBag.CustomCss = "Advertising/Details.css";
            _advertisingService.IncrementViewsCount(result.Data.Id);
            return result.IsSuccess ? View(result.Data) : View();
        }

        [Authorize(Roles = "member")]
        public IActionResult CreateAdvertising()
        {
            return View(new AdvertisingCreateDto());
        }


        [Authorize(Roles = "member")]
        [HttpPost]
        public IActionResult CreateAdvertising(AdvertisingCreateDto dto)
        {
            dto.MemberId = Convert.ToInt32((User.FindFirst(ClaimTypes.NameIdentifier)).Value);
            _advertisingService.Create(dto);
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "member")]
        [Route("TeklifYap/{id}")]
        public IActionResult GiveOffer(int id)
        {
            var result = _advertisingService.GetById(id);
            return result.IsSuccess ? View(new OfferCreateDto() { AdvertisingId = id }) : RedirectToAction("Detail", new { id = id });
        }

        [Authorize(Roles = "member")]
        [HttpPost]
        [Route("TeklifYap/{id}")]
        public IActionResult GiveOffer(OfferCreateDto dto)
        {
            var result = _offerService.Create(dto);
            return result.IsSuccess ? RedirectToAction("Details", new { id = dto.AdvertisingId }) : View(dto);
        }

    }
}
