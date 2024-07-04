using TeklifVer.Common.ResultPattern;
using TeklifVer.Dto.CarBrand;

namespace TeklifVer.Business.Abstract
{
    public interface ICarBrandService
    {
        public IResult Create(CarBrandCreateDto brandDto);
        public IResult Update(CarBrandUpdateDto brandDto);
        public IResult Delete(int id);
        public IResult<List<CarBrandListDto>> GetAll();
        public IResult<CarBrandListDto> GetById(int id);
        public IResult<CarBrandUpdateDto> GetByIdForUpdate(int id);
        public IResult<CarBrandListDto> GetByName(string name);
    }
}
