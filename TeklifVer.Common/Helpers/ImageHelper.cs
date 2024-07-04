using Microsoft.AspNetCore.Http;

namespace TeklifVer.Common.Helpers
{
    public static class ImageHelper
    {
        public static void UploadImage(IFormFile image, string path)
        {
            if (image != null && image.Length > 0)
            {
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    Path.Combine(Directory.GetCurrentDirectory(), path, image.FileName);
                    image.CopyTo(stream);
                }
            }
        }
    }
}
