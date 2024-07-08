using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TeklifVer.Business.Abstract;
using TeklifVer.Models;

namespace TeklifVer.Controllers
{
    [Authorize(Roles = "admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IModelService _carModelService;
        private readonly IBrandService _carBrandService;
        private readonly IMemberService _memberService;
        public HomeController(ILogger<HomeController> logger, IModelService service, IMemberService memberService, IBrandService carBrandService)
        {
            _logger = logger;
            _carModelService = service;
            _memberService = memberService;
            _carBrandService = carBrandService;
        }

        public IActionResult Index()
        {
            var data = _carBrandService.GetAll().Data;
            ViewData["MarkaCount"] = data.Count();
            ViewData["ModelCount"] = _carModelService.GetAll().Data.Count();
            ViewBag.CustomCss = "Main/Main.css";
            var members = _memberService.GetAll();
            return View(members.Data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult SuccessNotification()
        {
            return PartialView("SuccessNotification"); // PartialView.cshtml dosyanızın adı
        }
    }


}