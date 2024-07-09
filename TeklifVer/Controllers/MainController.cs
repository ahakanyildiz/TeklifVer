using Microsoft.AspNetCore.Mvc;

namespace TeklifVer.UI.Controllers
{

    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
