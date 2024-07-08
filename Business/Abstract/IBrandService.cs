using TeklifVer.Common.ResultPattern;
using TeklifVer.Dto.CarBrand;

namespace TeklifVer.Business.Abstract
{
    public interface IBrandService
    {
        public IResult Create(BrandCreateDto brandDto);
        public IResult Update(BrandUpdateDto brandDto);
        public IResult Delete(int id);
        public IResult<List<BrandListDto>> GetAll();
        public IResult<BrandListDto> GetById(int id);
        public IResult<BrandUpdateDto> GetByIdForUpdate(int id);
        public IResult<BrandListDto> GetByName(string name);
    }
}
