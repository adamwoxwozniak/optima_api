using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Optimo2021.Services
{
    public interface IKeyValidator
    {
        bool Validate(string key);
    }

    public class KeyValidator : IKeyValidator
    {
        private readonly IConfiguration _configuration;

        public KeyValidator(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Validate(string key)
        {
            return key == GetHashString(_configuration.GetValue<string>("Application:SecureKey"));
        }

        private byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        private string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
    }
}
