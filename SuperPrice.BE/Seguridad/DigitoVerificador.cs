using System.Security.Cryptography;
using System.Text;

namespace SuperPrice.BE.Seguridad
{
    public class DigitoVerificador
    {
        public static string CalcularDVH(string cadena)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] datos = Encoding.UTF8.GetBytes(cadena);
                byte[] hash = sha.ComputeHash(datos);

                StringBuilder sb = new StringBuilder();

                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}