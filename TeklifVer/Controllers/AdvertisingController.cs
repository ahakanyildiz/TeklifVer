using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TeklifVer.Business.Abstract;
using TeklifVer.Dto.Car;

namespace TeklifVer.UI.Controllers
{
    [Route("İlanlar/{action}")]
    public class AdvertisingController : Controller
    {
        private readonly IAdvertisingService _advertisingService;
        public AdvertisingController(IAdvertisingService advertisingService)
        {
            _advertisingService = advertisingService;
        }
        public IActionResult Index()
        {
            var result = _advertisingService.GetAll();
            ViewBag.CustomCss = "Advertising/AdvertisingList.css";
            return result.IsSuccess ? View(result.Data) : View();
        }

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
            dto.MemberId= Convert.ToInt32((User.FindFirst(ClaimTypes.NameIdentifier)).Value);
            _advertisingService.Create(dto);
            return RedirectToAction("Index");
        }

    }
}
