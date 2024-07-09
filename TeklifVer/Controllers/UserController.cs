using AutoMapper;
using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TeklifVer.Business.Abstract;
using TeklifVer.Dto.Car;
using TeklifVer.Dto.Member;

namespace TeklifVer.UI.Controllers
{
    public class UserController : Controller
    {
        private readonly IAdvertisingService _advertisingService;
        private readonly IBrandService _brandService;
        private readonly IModelService _modelService;
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;
        public UserController(IAdvertisingService advertisingService, IBrandService brandService, IModelService modelService, IMemberService memberService, IMapper mapper)
        {
            _advertisingService = advertisingService;
            _brandService = brandService;
            _modelService = modelService;
            _memberService = memberService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "member")]
        [Route("Profil")]
        public IActionResult Index()
        {
            var result = _memberService.GetById(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            return View(result.Data);
        }


        [HttpGet]
        [Authorize(Roles = "member")]
        [Route("Profil/BilgilerimiGuncelle")]
        public IActionResult UpdateInformation()
        {
            var result = _memberService.GetById(Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value));
            return View(_mapper.Map<MemberUpdateDto>(result.Data));
        }

        [HttpPost]
        [Authorize(Roles = "member")]
        [Route("Profil/BilgilerimiGuncelle")]
        public IActionResult UpdateInformation(MemberUpdateDto dto)
        {
            var result = _memberService.Update(dto);
            TempData["isOkey"] = result.IsSuccess ? "Okey" : "No";
            TempData["message"] = result.IsSuccess ? "Bilgiler başarıyla güncellendi" : result.ErrorMessage;
            return result.IsSuccess ? RedirectToAction("Index") : View(dto);
        }

        [HttpGet]
        [Authorize(Roles = "member")]
        [Route("Profil/İlanlarim")]
        public IActionResult MyAdvertisings()
        {
            var userId = Convert.ToInt16(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var result = _advertisingService.GetAllByMemberId(userId);
            return result.IsSuccess ? View(result.Data) : View();
        }

        [HttpGet]
        [Authorize(Roles = "member")]
        [Route("Profil/Ilanlarim/Guncelle/{id}")]
        public IActionResult Update(int id)
        {

            var result = _advertisingService.GetById(id);
            if (!result.IsSuccess)
            {
                return RedirectToAction("MyAdvertisings", "User");
            }
            TempData["Brands"] = _brandService.GetAll().Data;
            ViewData["Models"] = _modelService.GetAll().Data;
            return View(result.Data);
        }

        [HttpPost]
        [Authorize(Roles = "member")]
        [Route("Profil/Ilanlarim/Guncelle/{id}")]
        public IActionResult Update(AdvertisingUpdateDto dto)
        {
            var result = _advertisingService.Update(dto);
            TempData["isOkey"] = result.IsSuccess ? "Okey" : "No";
            TempData["message"] = result.IsSuccess ? "İlan bilgileri başarıyla güncellendi" : result.ErrorMessage;
            return result.IsSuccess ? RedirectToAction("MyAdvertisings", "User") : RedirectToAction("Update", new { id = dto.Id });
        }


        [HttpGet]
        [Authorize(Roles = "member")]
        [Route("Profil/Ilanlarim/Sil/{id}")]
        public IActionResult Remove(int id)
        {
            var result = _advertisingService.Delete(id);
            TempData["isOkey"] = result.IsSuccess ? "Okey" : "No";
            TempData["message"] = result.IsSuccess ? "İlan başarıyla kaldırıldı" : result.ErrorMessage;
            return RedirectToAction("MyAdvertisings", "User");
        }
    }
}
