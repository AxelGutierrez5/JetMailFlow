using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailFlow.UTILITY
{
    public static class Encripting
    {
        public static string SHA256(string input)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                // Convertir el string a bytes
                byte[] bytes = Encoding.UTF8.GetBytes(input);

                // Calcular el hash
                byte[] hashBytes = sha256.ComputeHash(bytes);

                // Convertir a string hexadecimal
                var sb = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // formato hexadecimal
                }

                return sb.ToString();
            }
        }
    }
}
