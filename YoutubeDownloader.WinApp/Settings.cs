using System;
using System.IO;
using System.Windows.Forms;
using YoutubeDownloader.WinApp.Exceptions;

namespace YoutubeDownloader.WinApp
{
    public class Settings
    {
        private static readonly Lazy<Settings> LazyInstance = new Lazy<Settings>(() => new Settings());

        public static Settings Instance
        {
            get { return LazyInstance.Value; }
        }

        private const string ToolsFolderName = "Tools";

        private const string YoutubeToolName = "youtube-dl.exe";

        private const string FfmpegToolName = "ffmpeg.exe";

        public string ProgramPath { get; private set; }

        public string YoutubeToolPath { get; private set; }

        public string FfmpegToolPath { get; private set; }

        public string WorkingDirectory { get; private set; }

        private Settings()
        { }

        public void Initialize()
        {
            ProgramPath = Path.GetDirectoryName(Application.ExecutablePath);

            WorkingDirectory = Environment.CurrentDirectory;

            YoutubeToolPath = Path.Combine(ProgramPath, ToolsFolderName, YoutubeToolName);
            if (!File.Exists(YoutubeToolPath))
                throw new ExternalToolMissingException(YoutubeToolName, YoutubeToolPath);

            FfmpegToolPath = Path.Combine(ProgramPath, ToolsFolderName, FfmpegToolName);
            if (!File.Exists(FfmpegToolPath))
                throw new ExternalToolMissingException(FfmpegToolName, FfmpegToolPath);
        }
    }
}
