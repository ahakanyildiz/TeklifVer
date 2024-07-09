using TeklifVer.Common.ResultPattern;
using TeklifVer.Dto.Slider;

namespace TeklifVer.Business.Abstract
{
    public interface ISliderService
    {
        public IResult<IEnumerable<SliderListDto>> GetAll();
    }
}
