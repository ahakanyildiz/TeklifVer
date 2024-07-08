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
    public class ModelService : IModelService
    {
        private readonly IRepository<Model> _repository;
        private readonly IRepository<Brand> _brandRepository;
        private readonly IMapper _mapper;
        public ModelService(IRepository<Model> repository, IMapper mapper, IRepository<Brand> brandRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _brandRepository = brandRepository;
        }

        public IResult<List<ModelListDto>> GetAllByBrandId(int id)
        {
            try
            {
                var data = _repository.GetByFilterList(x => x.BrandId == id);
                return new Result<List<ModelListDto>>(true, _mapper.Map<List<ModelListDto>>(data));
            }
            catch (Exception ex)
            {
                return new Result<List<ModelListDto>>(false, ex.Message);
            }

        }
        public IResult Create(ModelCreateDto carModelCreateDto)
        {
            try
            {
                _repository.Create(_mapper.Map<Model>(carModelCreateDto));
                return new Result(true);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }



        public IResult Delete(int id)
        {
            Model deletedCarModel = _repository.GetById(id);
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

        public IResult<List<ModelListDto>> GetAll()
        {
            try
            {
                var carModels = _repository.GetAll("Brand");
                Result<List<ModelListDto>> result = new(true, _mapper.Map<List<ModelListDto>>(carModels));
                return result;
            }
            catch (Exception ex)
            {
                return new Result<List<ModelListDto>>(false, ex.Message);
            }
        }

        public IResult<ModelListDto> GetById(int id)
        {
            try
            {
                var carModels = _repository.GetAll("Brand").ToList();
                var carModel = carModels.FirstOrDefault(x => x.Id == id);
                return new Result<ModelListDto>(true, _mapper.Map<ModelListDto>(carModel));
            }
            catch (Exception ex)
            {
                return new Result<ModelListDto>(false, ex.Message);
            }
        }

        public IResult Update(ModelUpdateDto carModelUpdateDto)
        {
            try
            {
                _repository.Update(_mapper.Map<Model>(carModelUpdateDto));
                return new Result(true);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

    }

}

