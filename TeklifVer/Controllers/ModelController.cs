using Dto.CarModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeklifVer.Business.Abstract;
using TeklifVer.Dto.CarModel;
using TeklifVer.UI.Models.CarModel;

namespace TeklifVer.UI.Controllers
{

    public class ModelController : Controller
    {
        private readonly IModelService _modelService;
        private readonly IBrandService _brandService;

        public ModelController(IModelService modelService, IBrandService brandService)
        {
            _modelService = modelService;
            _brandService = brandService;
        }
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            var model = new ModelListModel()
            {
                CarModels = _modelService.GetAll().Data,
                Brands = _brandService.GetAll().Data,
            };
            ViewBag.CustomCss = "Model/ModelList.css";

            return View(model);
        }

        [HttpGet]
        public IActionResult GetList()
        {
            var result = _modelService.GetAll();
            return result.IsSuccess ? Json(result.Data) : Json(null);
        }
        [Route("Model/GetListByBrandId/{id?}")]
        [HttpGet]
        public IActionResult GetListByBrandId(int id)
        {
            var result = _modelService.GetAllByBrandId(id);
            return result.IsSuccess ? Json(result.Data) : Json(null);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Create(ModelListModel model)
        {
            var dto = new ModelCreateDto()
            {
                BrandId = model.BrandId,
                Definition = model.Definition
            };
            var result = _modelService.Create(dto);
            TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
            return result.IsSuccess ? RedirectToAction("Index", "Model") : RedirectToAction("Index", "Model");
        }

        [Authorize(Roles = "admin")]
        public IActionResult Remove(int id)
        {
            var result = _modelService.Delete(id);
            TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
            return result.IsSuccess ? RedirectToAction("Index") : RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            ModelUpdateModel model = new ModelUpdateModel();
            model.BrandsList = _brandService.GetAll().Data;
            var carModelResult = _modelService.GetById(id);
            if (carModelResult.IsSuccess)
            {
                model.Definition = carModelResult.Data.Definition;
                model.BrandId = carModelResult.Data.BrandId;
            }
            ViewBag.CustomCss = "Brand/BrandUpdate.css";
            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Update(ModelUpdateModel model)
        {
            ModelUpdateDto carModelDto = new()
            {
                Id = model.Id,
                Definition = model.Definition,
                BrandId = model.BrandId
            };

            var result = _modelService.Update(carModelDto);
            TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
            if (result != null && result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                model.BrandsList = _brandService.GetAll().Data;
                return View(model);
            }
        }

    }
}
