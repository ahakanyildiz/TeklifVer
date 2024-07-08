using Dto.CarModel;
using TeklifVer.Common.ResultPattern;
using TeklifVer.Dto.CarModel;

namespace TeklifVer.Business.Abstract
{
    public interface IModelService
    {
        public IResult<List<ModelListDto>> GetAllByBrandId(int id);
        public IResult Create(ModelCreateDto carModelCreateDto);
        public IResult Update(ModelUpdateDto carModelUpdateDto);
        public IResult Delete(int id);
        public IResult<List<ModelListDto>> GetAll();
        public IResult<ModelListDto> GetById(int id);
    }
}
