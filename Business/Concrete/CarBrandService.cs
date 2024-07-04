using AutoMapper;
using DataAccess.Abstract;
using Entities;
using TeklifVer.Business.Abstract;
using TeklifVer.Common.Helpers;
using TeklifVer.Common.ResultPattern;
using TeklifVer.Dto.CarBrand;

namespace Business.Concrete
{
    public class CarBrandService : ICarBrandService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CarBrand> _repository;

        public CarBrandService(IRepository<CarBrand> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IResult Create(CarBrandCreateDto brandDto)
        {
            try
            {
                _repository.Create(_mapper.Map<CarBrand>(brandDto));
                return new Result(true);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public IResult Delete(int id)
        {
            try
            {
                var deletedBrand = _repository.GetById(id);
                _repository.Delete(deletedBrand);
                return new Result(true);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public IResult<List<CarBrandListDto>> GetAll()
        {
            try
            {
                var list = _mapper.Map<List<CarBrandListDto>>(_repository.GetAll());
                return new Result<List<CarBrandListDto>>(true, list);
            }
            catch (Exception ex)
            {
                return new Result<List<CarBrandListDto>>(false, ex.Message);
            }
        }


        public IResult<CarBrandListDto> GetById(int id)
        {
            try
            {
                var carBrand = _repository.GetById(id);
                Result<CarBrandListDto> result;
                var data = _mapper.Map<CarBrandListDto>(carBrand);
                return new Result<CarBrandListDto>(true, data);
            }
            catch (Exception ex)
            {
                return new Result<CarBrandListDto>(false, ex.Message);
            }
        }

        public IResult<CarBrandUpdateDto> GetByIdForUpdate(int id)
        {
            try
            {
                var carBrand = _repository.GetById(id);
                Result<CarBrandUpdateDto> result;
                var data = _mapper.Map<CarBrandUpdateDto>(carBrand);
                return new Result<CarBrandUpdateDto>(true, data);
            }
            catch (Exception ex)
            {
                return new Result<CarBrandUpdateDto>(false, ex.Message);
            }
        }

        public IResult<CarBrandListDto> GetByName(string name)
        {
            try
            {
                var carBrand = _repository.GetByFilter(x => x.Definition == name);
                return new Result<CarBrandListDto>(true, _mapper.Map<CarBrandListDto>(carBrand));
            }
            catch (Exception ex)
            {
                return new Result<CarBrandListDto>(false, ex.Message);
            }
        }

        public IResult Update(CarBrandUpdateDto brandDto)
        {
            try
            {
                ImageHelper.UploadImage(brandDto.Image, brandDto.ImgName);
                brandDto.ImgName = brandDto.Image.FileName;

                _repository.Update(_mapper.Map<CarBrand>(brandDto));


                return new Result(true);
            }
            catch (Exception ex)
            {

                return new Result(false, ex.Message);
            }
        }
    }
}
