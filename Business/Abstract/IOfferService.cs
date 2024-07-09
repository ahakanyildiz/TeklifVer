using TeklifVer.Common.ResultPattern;
using TeklifVer.Dto.Offer;

namespace TeklifVer.Business.Abstract
{
    public interface IOfferService
    {
        public IResult Create(OfferCreateDto dto);
    }
}
