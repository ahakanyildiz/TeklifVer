using Dto.CarModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeklifVer.Business.Abstract;
using TeklifVer.Dto.CarModel;
using TeklifVer.UI.Models.CarModel;

namespace TeklifVer.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class CarModelController : Controller
    {
        private readonly ICarModelService _modelService;
        private readonly ICarBrandService _brandService;

        public CarModelController(ICarModelService modelService, ICarBrandService brandService)
        {
            _modelService = modelService;
            _brandService = brandService;
        }

        public IActionResult Index()
        {
            var model = new CarModelListModel()
            {
                CarModels = _modelService.GetAll().Data,
                Brands = _brandService.GetAll().Data,
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _modelService.GetAll();
            return result.IsSuccess ? Json(result.Data) : Json(null);
        }

        [Route("CarModel/GetListByBrandId/{id?}")]
        [HttpGet]
        public IActionResult GetListByBrandId(int id)
        {
            var result = _modelService.GetAllByBrandId(id);
            return result.IsSuccess ? Json(result.Data) : Json(null);
        }

        [HttpPost]
        public IActionResult Create(CarModelListModel model)
        {
            var dto = new CarModelCreateDto()
            {
                BrandId = model.BrandId,
                Definition = model.Definition
            };
            var result = _modelService.Create(dto);
            TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
            return result.IsSuccess ? RedirectToAction("Index", "CarModel") : RedirectToAction("Index", "CarModel");
        }


        public IActionResult Remove(int id)
        {
            var result = _modelService.Delete(id);
            TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
            return result.IsSuccess ? RedirectToAction("Index") : RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            CarModelUpdateModel model = new CarModelUpdateModel();
            model.BrandsList = _brandService.GetAll().Data;
            var carModelResult = _modelService.GetById(id);
            model.Definition = carModelResult.Data.Definition;
            model.ImageName = carModelResult.Data.ImageName;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CarModelUpdateModel model)
        {
            CarModelUpdateDto carModelDto = new()
            {
                Id = model.Id,
                Definition = model.Definition,
                BrandId = model.BrandId
            };

            var result = _modelService.Update(carModelDto);

            if (result != null && result.IsSuccess)
            {
                TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
                model.BrandsList = _brandService.GetAll().Data;
                return View(model);
            }
        }

    }
}
