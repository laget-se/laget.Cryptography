using System.Web;

namespace laget.Cryptography.Extensions
{
    public static class StringExtensions
    {
        public static string Encode(this string @string)
        {
            var bytes = System.Text.Encoding.UTF8.GetBytes(@string);
            return System.Convert.ToBase64String(bytes);
        }

        public static string Decode(this string @string)
        {
            var bytes = System.Convert.FromBase64String(@string);
            return System.Text.Encoding.UTF8.GetString(bytes);
        }

        public static string UrlEncode(this string @string)
        {
            return HttpUtility.UrlEncode(@string);
        }

        public static string UrlDecode(this string @string)
        {
            return HttpUtility.UrlDecode(@string);
        }
    }
}
