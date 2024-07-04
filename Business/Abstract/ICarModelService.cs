using Dto.CarModel;
using TeklifVer.Common.ResultPattern;
using TeklifVer.Dto.CarModel;

namespace TeklifVer.Business.Abstract
{
    public interface ICarModelService
    {
        public IResult<List<CarModelListDto>> GetAllByBrandId(int id);
        public IResult Create(CarModelCreateDto carModelCreateDto);
        public IResult Update(CarModelUpdateDto carModelUpdateDto);
        public IResult Delete(int id);
        public IResult<List<CarModelListDto>> GetAll();
        public IResult<CarModelListDto> GetById(int id);
    }
}
