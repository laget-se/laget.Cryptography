using laget.Cryptography.Extensions;
using Xunit;

namespace laget.Cryptography.Tests
{
    public class EncodingTests
    {
        [Fact]
        public void ShouldEncodeAndDecode()
        {
        }

        [Fact]
        public void ShouldUrlEncodeAndUrlDecode()
        {
            const string expected = "jane doe";

            var encoded = expected.Encode();
            var decoded = encoded.Decode();

            Assert.Equal("amFuZSBkb2U=", encoded));
            Assert.Equal(expected, decoded);
        }
    }
}
