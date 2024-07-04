using System.ComponentModel.DataAnnotations;
using TeklifVer.Dto.CarBrand;
using TeklifVer.Dto.CarModel;

namespace TeklifVer.UI.Models.CarModel
{
    public class CarModelListModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "İsim zorunludur.")]
        public string? Definition { get; set; }
        [Required(ErrorMessage = "Marka seçmek zorunludur.")]
        public int BrandId { get; set; }
        public List<CarModelListDto> CarModels { get; set; }
        public List<CarBrandListDto> Brands { get; set; }


    }
}
