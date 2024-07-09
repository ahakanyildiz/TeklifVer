using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeklifVer.Dto.Slider
{
    public class SliderCreateDto : IDto
    {
        public string Name { get; set; }
        public string ImgName { get; set; }
    }
}
