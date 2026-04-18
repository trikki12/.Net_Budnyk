namespace Core
{
    public static class StringExtensions
    {
        public static int WordCount(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;

            return text.Split(' ', System.StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}