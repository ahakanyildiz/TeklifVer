using AutoMapper;
using DataAccess.Abstract;
using TeklifVer.Business.Abstract;
using TeklifVer.Common.ResultPattern;
using TeklifVer.Dto.Offer;
using TeklifVer.Entities;

namespace TeklifVer.Business.Concrete
{
    public class OfferService : IOfferService
    {
        private readonly IRepository<Offer> _repository;
        private readonly IMapper _mapper;
        public OfferService(IRepository<Offer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IResult Create(OfferCreateDto dto)
        {
            try
            {
                _repository.Create(_mapper.Map<Offer>(dto));
                return new Result(true);
            }
            catch (Exception ex)
            {
                return new Result(false, ex.Message);
            }
        }
    }
}
