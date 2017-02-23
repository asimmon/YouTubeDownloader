using System;

namespace YoutubeDownloader.WinApp.Exceptions
{
    [Serializable]
    public class YoutubeFormatNotFoundException : Exception
    {
        public string Kind { get; private set; }

        public YoutubeFormatNotFoundException(string kind)
            : base($"Il n'existe pas de format {kind}")
        {
            Kind = kind;
        }
    }
}