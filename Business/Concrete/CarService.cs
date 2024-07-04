using AutoMapper;
using DataAccess.Abstract;
using Entities;
using TeklifVer.Business.Abstract;
using TeklifVer.Common.ResultPattern;
using TeklifVer.Dto.Car;
using TeklifVer.Dto.CarModel;

namespace TeklifVer.Business.Concrete
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> _carRepository;
        private readonly IRepository<CarModel> _carModelRepository;
        private readonly IRepository<CarBrand> _carBrandRepository;
        private readonly IMapper _mapper;

        public CarService(IRepository<Car> carRepository, IMapper mapper, IRepository<CarModel> carModelRepository, IRepository<CarBrand> carBrandRepository)
        {
            _carRepository = carRepository;
            _mapper = mapper;
            _carModelRepository = carModelRepository;
            _carBrandRepository = carBrandRepository;
        }

        public IResult Create(CarCreateDto carCreateDto)
        {
            try
            {
                _carRepository.Create(_mapper.Map<Car>(carCreateDto));
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
                Car car = _carRepository.GetById(id);
                _carRepository.Delete(car);
                return new Result(true);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }

        public IResult<List<CarListDto>> GetAll()
        {
            try
            {
                var data = _mapper.Map<List<CarListDto>>(_carRepository.GetAll("CarModel").ToList());
                return new Result<List<CarListDto>>(true, data);
            }
            catch (Exception ex)
            {
                return new Result<List<CarListDto>>(false, ex.Message);
            }
        }

        public IResult Update(CarUpdateDto dto)
        {
            try
            {
                _carRepository.Update(_mapper.Map<Car>(dto));
                return new Result(true);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }


        public IResult<CarListDto> GetById(int id)
        {
            try
            {
                var data = _mapper.Map<CarListDto>(_carRepository.GetById(id, "CarModel,CarBrand"));
                return new Result<CarListDto>(true, data);

            }
            catch (Exception ex)
            {
                return new Result<CarListDto>(false, ex.Message);
            }

        }


        public IResult<IQueryable<CarModelListDto>> GetModelsByBrandId(int id)
        {
            try
            {
                var data = _carModelRepository.GetByFilterList(x => x.BrandId == id) as IQueryable<CarModel>;
                return new Result<IQueryable<CarModelListDto>>(true, _mapper.Map<IQueryable<CarModelListDto>>(data));
            }
            catch (Exception ex)
            {
                return new Result<IQueryable<CarModelListDto>>(false, ex.Message);
            }
        }

    }
}
