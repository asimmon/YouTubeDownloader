namespace YoutubeDownloader.WinApp
{
    public class VideoQuality
    {
        public string Text { get; set; }

        public int VideoHeight { get; set; }

        public VideoQuality(string text, int videoHeight)
        {
            Text = text;
            VideoHeight = videoHeight;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}