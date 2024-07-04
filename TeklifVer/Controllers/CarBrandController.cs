using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeklifVer.Business.Abstract;
using TeklifVer.Common.Helpers;
using TeklifVer.Dto.CarBrand;

namespace TeklifVer.Controllers
{
    [Authorize(Roles = "admin")]
    public class CarBrandController : Controller
    {

        private readonly ICarBrandService _carBrandService;

        public CarBrandController(ICarBrandService carBrandService)
        {
            _carBrandService = carBrandService;
        }


        [Route("Marka/Index")]
        public IActionResult Index()
        {
            var result = _carBrandService.GetAll();
            TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
            return result.IsSuccess ? View(result.Data) : View();
        }


        [Route("Marka/Olustur")]
        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }

        [Route("Marka/Olustur")]
        [HttpPost]
        public IActionResult CreateBrand([FromForm] CarBrandCreateDto brandDto)
        {
            brandDto.ImgName = brandDto.Image.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/brand_images", brandDto.Image.FileName);
            ImageHelper.UploadImage(brandDto.Image, path);
            var result = _carBrandService.Create(brandDto);
            TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
            return result.IsSuccess ? RedirectToAction("Index") : View(brandDto);
        }


        [HttpGet]
        public IActionResult GetList()
        {
            var result = _carBrandService.GetAll();
            return Json(result.Data);
        }


        [Route("Marka/Remove/{id}")]
        public IActionResult Remove(int id)
        {
            var result = _carBrandService.Delete(id);
            TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Marka/Guncelle/{id}")]
        public IActionResult Update(int id)
        {
            var result = _carBrandService.GetByIdForUpdate(id);
            TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
            return result.IsSuccess ? View(result.Data) : RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Marka/Guncelle/{id}")]
        public IActionResult Update(CarBrandUpdateDto brandDto)
        {
            var result = _carBrandService.Update(brandDto);
            TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
            return result.IsSuccess ? RedirectToAction("Index") : View(brandDto); ;
        }
    }
}
