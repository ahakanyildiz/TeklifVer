using System.Security.Cryptography;
using System.Text;


namespace TeklifVer.Common.Helpers
{

    public static class PasswordHasher
    {
        public static string HashPassword(string password, string salt )
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Şifreye salt değerini ekleyerek toplam metni oluştur
                string combined = password + salt;

                // Metni byte dizisine dönüştür
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(combined));

                // Byte dizisini base64 string'e dönüştür
                return Convert.ToBase64String(bytes);
            }
        }

        public static string GenerateSalt(int length = 16)
        {
            // Rastgele bir salt değeri oluştur
            byte[] salt = new byte[length];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }
    }
}

