namespace YoutubeDownloader.WinApp.Models
{
    public class DownloadRequest
    {
        public string Url { get; set; }

        public string OutputFilePath { get; set; }

        public bool EncodeMp4 { get; set; }

        public YoutubeFormat VideoFormat { get; set; }

        public YoutubeFormat AudioFormat { get; set; }

        public DownloadRequest()
        {
            Url = "";
            OutputFilePath = "";
            EncodeMp4 = false;
        }
    }

    public enum YoutubeFormatKind
    {
        Audio,
        Video
    }

    public class YoutubeFormat
    {
        public int Code { get; set; }

        public int Quality { get; set; }

        public string Extension { get; set; }

        public YoutubeFormatKind Kind { get; set; }

        public int VideoWidth { get; set; }

        public int VideoHeight { get; set; }

        public string Resolution
        {
            get
            {
                return Kind == YoutubeFormatKind.Video
                    ? $"{VideoWidth}x{VideoHeight}"
                    : null;
            }
        }

        public override string ToString()
        {
            return $"[{Code,3}] Quality: {Quality}k, Extension: {Extension.ToUpper()}, Resolution: {Resolution}";
        }
    }
}
