using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TeklifVer.Business.Abstract;
using TeklifVer.Dto.Car;
using TeklifVer.UI.Models.Car;

namespace TeklifVer.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdsController : Controller
    {
        private readonly IAdvertisingService _advertisingService;
        private readonly IModelService _modelService;
        private readonly IBrandService _brandService;

        public AdsController(IAdvertisingService advertisingService, IModelService carModelService, IBrandService brandService)
        {
            _advertisingService = advertisingService;
            _modelService = carModelService;
            _brandService = brandService;
        }


        public IActionResult Index()
        {
            var result = _advertisingService.GetAll();
            ViewBag.CustomCss = "Car/CarList.css";
            return result.IsSuccess ? View(result.Data) : View();
        }

        [HttpPost]
        public IActionResult Create(AdvertisingCreateDto carCreateDto)
        {
            carCreateDto.MemberId =Convert.ToInt32((User.FindFirst(ClaimTypes.NameIdentifier)).Value);
            var result = _advertisingService.Create(carCreateDto);
            TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
            return result.IsSuccess ? RedirectToAction("Index") : View(carCreateDto);
        }


        public IActionResult Remove(int id)
        {
            var result = _advertisingService.Delete(id);
            TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var car = _advertisingService.GetById(id);
            var brands = _brandService.GetAll();
            var models = _modelService.GetAll();

            var viewModel = new AdvertisingUpdateViewModel
            {
                Car = car.Data,
                Brands = brands.Data,
                Models = models.Data
            };
            ViewBag.CustomCss = "Brand/BrandUpdate.css";
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(AdvertisingUpdateViewModel model)
        {
            AdvertisingUpdateDto dto = new();
            dto.Id = model.Car.Id;
            dto.Year = model.Car.Year;
            dto.Definition = model.Car.Definition;
            dto.ModelId = model.Car.ModelId;
            dto.Price = model.Car.Price;
            dto.Description= model.Car.Description;
            dto.MemberId=model.Car.MemberId;
            var result = _advertisingService.Update(dto);
            TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
            return result.IsSuccess ? RedirectToAction("Index") : View(model);
        }

        public IActionResult GetModelsByBrand(int brandId)
        {
            var result = _advertisingService.GetModelsByBrandId(brandId);
            return result.IsSuccess ? Json(result.Data) : Json(null);
        }
    }
}
