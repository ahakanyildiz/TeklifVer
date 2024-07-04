using System.ComponentModel.DataAnnotations;

namespace TeklifVer.UI.Models.CarModel
{
    public class CarModelCreateModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "İsim zorunludur.")]
        public string? Definition { get; set; }
        [Required(ErrorMessage = "Marka seçmek zorunludur.")]
        public string? BrandName { get; set; }


    }
}
