using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace laget.Cryptography
{
    public interface ICryptographer
    {
        string Encrypt(string @string);
        string Decrypt(string @string);
    }

    public class Cryptographer : ICryptographer
    {
        private readonly byte[] _key;
        private readonly byte[] _iv;

        public CipherMode CipherMode { get; set; } = CipherMode.CBC;
        public PaddingMode PaddingMode { get; set; } = PaddingMode.PKCS7;

        public Cryptographer(string key, string iv)
        {
            _key = Convert.FromBase64String(key);
            _iv = Convert.FromBase64String(iv);
        }

        public string Encrypt(string @string)
        {
            using (var aes = Aes.Create())
            {
                aes.Mode = CipherMode;
                aes.Padding = PaddingMode;
                aes.Key = _key;
                aes.IV = _iv;

                using (var transform = aes.CreateEncryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                    {
                        using (var sw = new StreamWriter(cs))
                        {
                            sw.Write(@string);
                        }

                        var bytes = ms.ToArray();
                        return Convert.ToBase64String(bytes);
                    }
                }
            }
        }

        public string Decrypt(string @string)
        {
            string value;

            using (var aes = Aes.Create())
            {
                aes.Mode = CipherMode;
                aes.Padding = PaddingMode;
                aes.Key = _key;
                aes.IV = _iv;

                var bytes = Convert.FromBase64String(@string);

                using (var transform = aes.CreateDecryptor(aes.Key, aes.IV))
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, transform, CryptoStreamMode.Write))
                    {
                        cs.Write(bytes, 0, bytes.Length);
                        cs.FlushFinalBlock();
                    }

                    value = Encoding.UTF8.GetString(ms.ToArray());
                }
            }

            return value;
        }
    }
}
