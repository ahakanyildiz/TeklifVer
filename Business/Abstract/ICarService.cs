using TeklifVer.Common.ResultPattern;
using TeklifVer.Dto.Car;
using TeklifVer.Dto.CarModel;

namespace TeklifVer.Business.Abstract
{
    public interface ICarService
    {
        public IResult Create(CarCreateDto carCreateDto);
        public IResult Update(CarUpdateDto car);
        public IResult Delete(int id);
        public IResult<List<CarListDto>> GetAll();
        public IResult<CarListDto> GetById(int id);
        public IResult<IQueryable<CarModelListDto>> GetModelsByBrandId(int id);
    }
}
