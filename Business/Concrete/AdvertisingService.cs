using AutoMapper;
using DataAccess.Abstract;
using Entities;
using TeklifVer.Business.Abstract;
using TeklifVer.Common.ResultPattern;
using TeklifVer.Dto.Car;
using TeklifVer.Dto.CarModel;

namespace TeklifVer.Business.Concrete
{
    public class AdvertisingService : IAdvertisingService
    {
        private readonly IRepository<Advertising> _carRepository;
        private readonly IRepository<Model> _carModelRepository;
        private readonly IMapper _mapper;

        public AdvertisingService(IRepository<Advertising> carRepository, IMapper mapper, IRepository<Model> carModelRepository)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _carModelRepository = carModelRepository;
        }

        public IResult Create(AdvertisingCreateDto carCreateDto)
        {
            try
            {
                _carRepository.Create(_mapper.Map<Advertising>(carCreateDto));
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
                Advertising car = _carRepository.GetById(id);
                _carRepository.Delete(car);
                return new Result(true);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public IResult IncrementViewsCount(int id)
        {
            try
            {
                var advertising = _carRepository.GetById(id);
                if (advertising != null)
                {
                    advertising.ViewsCount++;
                    _carRepository.Update(advertising);
                    return new Result(true);
                }
                return new Result(false, "İlan bulunamadı");
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }

        }

        public IResult<List<AdvertisingListDto>> GetAll()
        {
            try
            {
                var data = _mapper.Map<List<AdvertisingListDto>>(_carRepository.GetAll("Model,Model.Brand").ToList());
                return new Result<List<AdvertisingListDto>>(true, data);
            }
            catch (Exception ex)
            {
                return new Result<List<AdvertisingListDto>>(false, ex.Message);
            }
        }

        public IResult Update(AdvertisingUpdateDto dto)
        {
            try
            {
                _carRepository.Update(_mapper.Map<Advertising>(dto));
                return new Result(true);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }


        public IResult<AdvertisingListDto> GetById(int id)
        {
            try
            {
                var data = _mapper.Map<AdvertisingListDto>(_carRepository.GetById(id, "Model,Model.Brand"));
                return new Result<AdvertisingListDto>(true, data);

            }
            catch (Exception ex)
            {
                return new Result<AdvertisingListDto>(false, ex.Message);
            }

        }


        public IResult<IQueryable<ModelListDto>> GetModelsByBrandId(int id)
        {
            try
            {
                var data = _carModelRepository.GetByFilterList(x => x.BrandId == id) as IQueryable<Model>;
                return new Result<IQueryable<ModelListDto>>(true, _mapper.Map<IQueryable<ModelListDto>>(data));
            }
            catch (Exception ex)
            {
                return new Result<IQueryable<ModelListDto>>(false, ex.Message);
            }
        }

    }
}
