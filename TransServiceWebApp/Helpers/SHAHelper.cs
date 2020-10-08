using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TransServiceWebApp.Helpers
{
    public class SHAHelper
    {
        internal static string GenerateSHA512(string input)
        {
            using (SHA512 sha = new SHA512Managed())
            {
                var inputInBytes = Encoding.UTF8.GetBytes(input);
                var hash = sha.ComputeHash(inputInBytes);

                var sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}