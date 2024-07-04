using AutoMapper;
using DataAccess.Abstract;
using Dto.CarModel;
using Entities;
using Microsoft.EntityFrameworkCore;
using TeklifVer.Business.Abstract;
using TeklifVer.Common.ResultPattern;
using TeklifVer.Dto.CarModel;

namespace Business.Concrete
{
    public class CarModelService : ICarModelService
    {
        private readonly IRepository<CarModel> _repository;
        private readonly IRepository<CarBrand> _brandRepository;
        private readonly IMapper _mapper;
        public CarModelService(IRepository<CarModel> repository, IMapper mapper, IRepository<CarBrand> brandRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _brandRepository = brandRepository;
        }

        public IResult<List<CarModelListDto>> GetAllByBrandId(int id)
        {
            try
            {
                var data = _repository.GetByFilterList(x => x.BrandId == id);
                return new Result<List<CarModelListDto>>(true, _mapper.Map<List<CarModelListDto>>(data));
            }
            catch (Exception ex)
            {
                return new Result<List<CarModelListDto>>(false, ex.Message);
            }

        }
        public IResult Create(CarModelCreateDto carModelCreateDto)
        {
            try
            {
                _repository.Create(_mapper.Map<CarModel>(carModelCreateDto));
                return new Result(true);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }



        public IResult Delete(int id)
        {
            CarModel deletedCarModel = _repository.GetById(id);
            try
            {
                _repository.Delete(deletedCarModel);
                return new Result(true);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public IResult<List<CarModelListDto>> GetAll()
        {
            try
            {
                var carModels = _repository.GetAll("Brand");
                Result<List<CarModelListDto>> result = new(true, _mapper.Map<List<CarModelListDto>>(carModels));
                return result;
            }
            catch (Exception ex)
            {
                return new Result<List<CarModelListDto>>(false, ex.Message);
            }
        }

        public IResult<CarModelListDto> GetById(int id)
        {
            try
            {
                var carModels = _repository.GetAll("CarBrand").Include(x => x.Brand);
                var carModel = carModels.FirstOrDefault(x => x.Id == id);
                return new Result<CarModelListDto>(true, _mapper.Map<CarModelListDto>(carModel));
            }
            catch (Exception ex)
            {
                return new Result<CarModelListDto>(false, ex.Message);
            }
        }

        public IResult Update(CarModelUpdateDto carModelUpdateDto)
        {
            try
            {
                _repository.Update(_mapper.Map<CarModel>(carModelUpdateDto));
                return new Result(true);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

    }

}

