using System.ComponentModel.DataAnnotations;
using TeklifVer.Dto.CarBrand;
using TeklifVer.Dto.CarModel;

namespace TeklifVer.UI.Models.CarModel
{
    public class ModelListModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "İsim zorunludur.")]
        public string? Definition { get; set; }
        [Required(ErrorMessage = "Marka seçmek zorunludur.")]
        public int BrandId { get; set; }
        public List<ModelListDto> CarModels { get; set; }
        public List<BrandListDto> Brands { get; set; }


    }
}
