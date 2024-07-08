using HtmlAgilityPack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeklifVer.Business.Abstract;
using TeklifVer.Common.Helpers;
using TeklifVer.Dto.CarBrand;

namespace TeklifVer.Controllers
{
   
    [Route("Marka/{action}/{id?}")]
    public class BrandController : Controller
    {

        private readonly IBrandService _carBrandService;

        public BrandController(IBrandService carBrandService)
        {
            _carBrandService = carBrandService;
        }

        //HtmlAgilityPack ile markalar ve logoları çekildi.
        public void getCarBrands()
        {
            var url = "https://www.sahibinden.com/kategori/otomobil";
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(url);

            var brandNodes = doc.DocumentNode.SelectNodes("//div[@class='jspPane']/li/h2");
            var brandImageNodes = doc.DocumentNode.SelectNodes("//div[@class='car-brand-frame']/a/img");
            if (brandNodes != null && brandImageNodes != null)
            {
                for (int i = 0; i < brandNodes.Count; i++)
                {
                    _carBrandService.Create(new BrandCreateDto()
                    {
                        Definition = brandNodes[i].InnerText,
                        ImgName = "https://www.tasit.com" + brandImageNodes[i].Attributes["src"].Value
                    });
                }
            }
        }
        [Authorize(Roles = "admin")]
        public IActionResult Index()
        {
            var result = _carBrandService.GetAll();
            ViewBag.CustomCss = "Brand/BrandList.css";
            return result.IsSuccess ? View(result.Data) : View();
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult CreateBrand()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult CreateBrand(BrandCreateDto brandDto)
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

        [Authorize(Roles = "admin")]
        public IActionResult Remove(int id)
        {
            var result = _carBrandService.Delete(id);
            TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var result = _carBrandService.GetByIdForUpdate(id);
            ViewBag.CustomCss = "Brand/BrandUpdate.css";
            return result.IsSuccess ? View(result.Data) : RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Update(BrandUpdateDto brandDto)
        {
            var result = _carBrandService.Update(brandDto);
            TempData["isSuccess"] = result.IsSuccess ? "İşlem Başarılı" : result.ErrorMessage;
            return result.IsSuccess ? RedirectToAction("Index") : View(brandDto); ;
        }
    }
}
