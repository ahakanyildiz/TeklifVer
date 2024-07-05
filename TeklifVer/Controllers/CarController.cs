using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeklifVer.Business.Abstract;
using TeklifVer.Dto.Car;
using TeklifVer.UI.Models.Car;

namespace TeklifVer.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly ICarModelService _modelService;
        private readonly ICarBrandService _brandService;

        public CarController(ICarService carService, ICarModelService carModelService, ICarBrandService brandService)
        {
            _carService = carService;
            _modelService = carModelService;
            _brandService = brandService;
        }

        public IActionResult Index()
        {
            var result = _carService.GetAll();
            return result.IsSuccess ? View(result.Data) : View();
        }

        [HttpPost]
        public IActionResult Create(CarCreateDto carCreateDto)
        {
            var result = _carService.Create(carCreateDto);
            TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
            return result.IsSuccess ? RedirectToAction("Index") : View(carCreateDto);
        }


        public IActionResult Remove(int id)
        {
            var result = _carService.Delete(id);
            TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Update(int id)
        {
            var car = _carService.GetById(id);
            var brands = _brandService.GetAll();
            var models = _modelService.GetAll();

            var viewModel = new CarUpdateViewModel
            {
                Car = car.Data,
                Brands = brands.Data,
                Models = models.Data
            };

            viewModel.Car.Model = _modelService.GetById(viewModel.Car.ModelId).Data;
            viewModel.Car.Model.Brand = _brandService.GetById(viewModel.Car.Model.BrandId).Data;
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(CarUpdateViewModel model)
        {
            CarUpdateDto dto = new();
            dto.Id = model.Car.Id;
            dto.Year = model.Car.Year;
            dto.Definition = model.Car.Definition;
            dto.ModelId = model.Car.ModelId;
            dto.Price = model.Car.Price;
            var result = _carService.Update(dto);
            TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
            return result.IsSuccess ? RedirectToAction("Index") : View(model);
        }

        public IActionResult GetModelsByBrand(int brandId)
        {
            var result = _carService.GetModelsByBrandId(brandId);
            return result.IsSuccess ? Json(result.Data) : Json(null);
        }
    }
}
