using AutoMapper;
using DataAccess.Abstract;
using TeklifVer.Business.Abstract;
using TeklifVer.Common.ResultPattern;
using TeklifVer.Dto.Slider;
using TeklifVer.Entities;

namespace TeklifVer.Business.Concrete
{
    public class SliderService : ISliderService
    {
        private readonly IRepository<Slider> _repository;
        private readonly IMapper _mapper;
        public SliderService(IRepository<Slider> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IResult<IEnumerable<SliderListDto>> GetAll()
        {
            try
            {
                var data = _repository.GetAll();
                return new Result<IEnumerable<SliderListDto>>(true, _mapper.Map<IEnumerable<SliderListDto>>(data));
            }
            catch (Exception ex)
            {

                return new Result<IEnumerable<SliderListDto>>(false, ex.Message);
            }

        }

        public IResult Create(SliderCreateDto dto)
        {
            try
            {
                _repository.Create(_mapper.Map<Slider>(dto));
                return new Result(true);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
           
        }
    }
}
