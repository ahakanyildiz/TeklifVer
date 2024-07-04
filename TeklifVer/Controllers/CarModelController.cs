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
            var result = _modelService.GetAll();
            TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
            return result.IsSuccess ? View(result.Data) : View();
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _modelService.GetAll();
            return result.IsSuccess ? Json(result.Data) : Json(null);
        }


        [HttpGet]
        public IActionResult GetListByBrandId(int id)
        {
            var result = _modelService.GetAllByBrandId(id);
            return result.IsSuccess ? Json(result.Data) : Json(null);
        }


        [Route("Model/Olustur")]
        [HttpPost]
        public IActionResult Create([FromForm] CarModelCreateDto dto)
        {
            var result = _modelService.Create(dto);
            TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
            return result.IsSuccess ? RedirectToAction("Index", "CarModel") : View(dto);
        }


        public IActionResult Remove(int id)
        {
            var result = _modelService.Delete(id);
            TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
            return result.IsSuccess ? RedirectToAction("Index") : RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            try
            {
                CarModelUpdateModel model = new CarModelUpdateModel();
                model.BrandsList = _brandService.GetAll().Data;
                var modelResult = _modelService.GetById(id);

                model.Definition = modelResult.Data.Definition;
                model.ImageName = modelResult.Data.ImageName;
                model.BrandName = modelResult.Data.Brand.Definition;
                return View(model);
            }


            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult EditAsync(CarModelCreateModel model)
        {
            CarModelUpdateDto carModel = new()
            {
                Id = model.Id,
                Definition = model.Definition,
                BrandId = _brandService.GetByName(model.BrandName).Data.Id,
            };

            var result = _modelService.Update(carModel);
            TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
            return result.IsSuccess ? RedirectToAction("Index") : View(model);
        }

    }
}
