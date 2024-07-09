using Microsoft.AspNetCore.Mvc;
using TeklifVer.Business.Abstract;

namespace TeklifVer.API.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _sliderService.GetAll();
            return Ok(result.Data);
        }
    }
}
