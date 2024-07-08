using AutoMapper;
using DataAccess.Abstract;
using Entities;
using TeklifVer.Business.Abstract;
using TeklifVer.Common.Helpers;
using TeklifVer.Common.ResultPattern;
using TeklifVer.Dto.CarBrand;

namespace Business.Concrete
{
    public class BrandService : IBrandService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Brand> _repository;

        public BrandService(IRepository<Brand> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IResult Create(BrandCreateDto brandDto)
        {
            try
            {
                _repository.Create(_mapper.Map<Brand>(brandDto));
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

        public IResult<List<BrandListDto>> GetAll()
        {
            try
            {
                var list = _mapper.Map<List<BrandListDto>>(_repository.GetAll());
                return new Result<List<BrandListDto>>(true, list);
            }
            catch (Exception ex)
            {
                return new Result<List<BrandListDto>>(false, ex.Message);
            }
        }


        public IResult<BrandListDto> GetById(int id)
        {
            try
            {
                var carBrand = _repository.GetById(id);
                Result<BrandListDto> result;
                var data = _mapper.Map<BrandListDto>(carBrand);
                return new Result<BrandListDto>(true, data);
            }
            catch (Exception ex)
            {
                return new Result<BrandListDto>(false, ex.Message);
            }
        }

        public IResult<BrandUpdateDto> GetByIdForUpdate(int id)
        {
            try
            {
                var carBrand = _repository.GetById(id);
                Result<BrandUpdateDto> result;
                var data = _mapper.Map<BrandUpdateDto>(carBrand);
                return new Result<BrandUpdateDto>(true, data);
            }
            catch (Exception ex)
            {
                return new Result<BrandUpdateDto>(false, ex.Message);
            }
        }

        public IResult<BrandListDto> GetByName(string name)
        {
            try
            {
                var carBrand = _repository.GetByFilter(x => x.Definition == name);
                return new Result<BrandListDto>(true, _mapper.Map<BrandListDto>(carBrand));
            }
            catch (Exception ex)
            {
                return new Result<BrandListDto>(false, ex.Message);
            }
        }

        public IResult Update(BrandUpdateDto brandDto)
        {
            try
            {
                ImageHelper.UploadImage(brandDto.Image, brandDto.ImgName);
                brandDto.ImgName = brandDto.Image.FileName;

                _repository.Update(_mapper.Map<Brand>(brandDto));


                return new Result(true);
            }
            catch (Exception ex)
            {

                return new Result(false, ex.Message);
            }
        }
    }
}
