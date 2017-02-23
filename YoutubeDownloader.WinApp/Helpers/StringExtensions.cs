namespace YoutubeDownloader.WinApp.Helpers
{
    public static class StringExtensions
    {
        public static bool StartsWithDigit(this string str)
        {
            return !string.IsNullOrEmpty(str) && char.IsDigit(str[0]);
        }
    }
}
