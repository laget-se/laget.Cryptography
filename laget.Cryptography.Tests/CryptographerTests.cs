using laget.Cryptography.Extensions;
using Xunit;

namespace laget.Cryptography.Tests
{
    public class CryptographerTests
    {
        private readonly ICryptographer _cryptographer;

        public CryptographerTests()
        {
            _cryptographer = new Cryptographer("ns0+5161cXn+UeD4/Gd8Bd7JDG00J81MzR7lliDihpk=", "w8SBmyQegQnBtoz9hpiJzQ==");
        }

        [Fact]
        public void ShouldEncryptAndDecrypt()
        {
            const string expected = "jane.doe@domain.tld";

            var encrypted = _cryptographer.Encrypt(expected);
            var actual = _cryptographer.Decrypt(encrypted);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldDecryptEncodedValue()
        {
            const string expected = "jane.doe@domain.tld";

            var encrypted = _cryptographer.Encrypt(expected);
            var encoded = encrypted.UrlEncode();

            var decoded = encoded.UrlDecode();
            var decrypted = _cryptographer.Decrypt(encrypted);

            Assert.Equal(encrypted, decoded);
            Assert.Equal(expected, decrypted);
        }

        [Fact]
        public void ShouldDecode()
        {
            const string expected = "jane.doe@domain.tld";

            var encrypted = "1R+yK8L/5E814oDaoQ+ggRcZUaG0mGA2X4jtUwoKiNM=";
            var decrypted = _cryptographer.Decrypt(encrypted);

            Assert.Equal(expected, decrypted);
        }

        [Fact]
        public void ShouldHandleEncodedString()
        {
            const string expected = "jane.doe@domain.tld";

            var encoded = "1R%2byK8L%2f5E814oDaoQ%2bggRcZUaG0mGA2X4jtUwoKiNM%3d";
            var decoded = encoded.UrlDecode();
            var decrypted = _cryptographer.Decrypt(decoded);

            Assert.Equal(expected, decrypted);
        }
    }
}
