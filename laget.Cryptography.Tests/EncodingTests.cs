using laget.Cryptography.Extensions;
using Xunit;

namespace laget.Cryptography.Tests
{
    public class EncodingTests
    {
        [Fact]
        public void ShouldEncodeAndDecode()
        {
            const string expected = "1R+yK8L/5E814oDaoQ+ggRcZUaG0mGA2X4jtUwoKiNM=";

            var encoded = expected.UrlEncode();
            var decoded = encoded.UrlDecode();

            Assert.Equal("1R%2byK8L%2f5E814oDaoQ%2bggRcZUaG0mGA2X4jtUwoKiNM%3d", encoded);
            Assert.Equal(expected, decoded);
        }

        [Fact]
        public void ShouldUrlEncodeAndUrlDecode()
        {
            const string expected = "jane doe";

            var encoded = expected.Encode();
            var decoded = encoded.Decode();

            Assert.Equal("amFuZSBkb2U=", encoded);
            Assert.Equal(expected, decoded);
        }
    }
}
