namespace FifthAve.Utils.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhitespace(this string str) 
            => string.IsNullOrWhiteSpace(str);
        public static bool IsNullOrEmpty(this string str)
            => string.IsNullOrEmpty(str);
    }
}
