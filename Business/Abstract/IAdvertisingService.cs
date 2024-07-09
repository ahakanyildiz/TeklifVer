using TeklifVer.Common.ResultPattern;
using TeklifVer.Dto.Car;
using TeklifVer.Dto.CarModel;

namespace TeklifVer.Business.Abstract
{
    public interface IAdvertisingService
    {
        public IResult Create(AdvertisingCreateDto carCreateDto);
        public IResult Update(AdvertisingUpdateDto car);
        public IResult Delete(int id);
        public IResult<List<AdvertisingListDto>> GetAll();
        public IResult<AdvertisingListDto> GetById(int id);
        public IResult<IQueryable<ModelListDto>> GetModelsByBrandId(int id);
        public IResult IncrementViewsCount(int id);
        public IResult<List<AdvertisingListDto>> GetAllByMemberId(int id);
    }
}
