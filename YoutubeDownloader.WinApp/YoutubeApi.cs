using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NLog;
using YoutubeDownloader.WinApp.Helpers;
using YoutubeDownloader.WinApp.Models;

namespace YoutubeDownloader.WinApp
{
    public class YoutubeApi
    {
        private readonly DownloadRequest _downloadRequest;
        private readonly Logger _logger;

        public YoutubeApi(DownloadRequest downloadRequest, Logger logger)
        {
            _downloadRequest = downloadRequest;
            _logger = logger;
        }

        public Task<List<YoutubeFormat>> GetFormats()
        {
            return Task.Run(() => GetFormatsInternal());
        }

        public Task DownloadVideo(CancellationToken token)
        {
            return Task.Run(
                () => DownloadVideoInternal(token),
                token
            );
        }

        private void DownloadVideoInternal(CancellationToken token)
        {
            var videoCode = _downloadRequest.VideoFormat.Code;
            var audioCode = _downloadRequest.AudioFormat.Code;

            using (var process = CreateProcess($"--format {videoCode}+{audioCode}"))
            {
                using (var outputWaitHandle = new AutoResetEvent(false))
                {
                    process.OutputDataReceived += (sender, args) =>
                    {
                        var actualProcess = (Process)sender;

                        if (token.IsCancellationRequested || actualProcess.HasExited)
                        { }
                        else if (args.Data == null)
                        {
                            // ReSharper disable once AccessToDisposedClosure
                            outputWaitHandle.Set();
                        }
                        else
                        {
                            _logger.Debug(args.Data);
                        }
                    };

                    process.Start();
                    _logger.Info("Download started...");

                    process.BeginOutputReadLine();

                    while (!process.WaitForExit(1000) && !outputWaitHandle.WaitOne(1000))
                    {
                        if (token.IsCancellationRequested)
                        {
                            try
                            {
                                process.Kill();
                                _logger.Info("Download cancelled");
                                return;
                            }
                            catch
                            {
                                // ignored
                            }
                        }
                    }
                }
            }

            _logger.Info("Download finished");
        }

        private static readonly Regex AudioVideoFormatRegex = new Regex(
            @"(?<code>\d+)\s+(?<ext>[a-z0-9\-]+)\s+(?<res>(audio only|\d+x\d+))\s+DASH (?<kind>(audio|video))\s+(?<quality>[0-9]+)k",
            RegexOptions.Compiled | RegexOptions.Singleline
        );

        private List<YoutubeFormat> GetFormatsInternal()
        {
            string rawVideoFormats;

            using (var process = CreateProcess("--list-formats"))
            {
                process.Start();
                _logger.Info("Retrieving video formats...");

                rawVideoFormats = process.StandardOutput.ReadToEnd();

                process.WaitForExit();
            }

            _logger.Debug("Formats:");
            _logger.Debug(rawVideoFormats);

            var lines = rawVideoFormats.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            var formats = new List<YoutubeFormat>();

            foreach (var line in lines)
            {
                if (!line.StartsWithDigit())
                    continue;

                var match = AudioVideoFormatRegex.Match(line);
                if (!match.Success)
                    continue;

                int code;
                if (!int.TryParse(match.Groups["code"].Value, out code))
                    continue;

                var extension = match.Groups["ext"].Value;

                var format = new YoutubeFormat
                {
                    Code = code,
                    Extension = extension
                };

                var kind = match.Groups["kind"].Value;
                if ("audio".Equals(kind))
                    format.Kind = YoutubeFormatKind.Audio;
                if ("video".Equals(kind))
                    format.Kind = YoutubeFormatKind.Video;

                var res = match.Groups["res"].Value;
                if (format.Kind == YoutubeFormatKind.Video)
                {
                    var dimensions = res.Split(new[] { 'x' }, 2, StringSplitOptions.RemoveEmptyEntries);
                    if (dimensions.Length == 2)
                    {
                        int width, height;
                        if (int.TryParse(dimensions[0], out width) && int.TryParse(dimensions[1], out height))
                        {
                            format.VideoWidth = width;
                            format.VideoHeight = height;
                        }
                    }
                }

                int quality;
                if (int.TryParse(match.Groups["quality"].Value, out quality))
                    format.Quality = quality;

                formats.Add(format);
            }

            return formats;
        }

        private Process CreateProcess(params string[] args)
        {
            var timestamp = DateTime.Now.ToString("yyyyMMddhhmmss");
            var outputFileNameTemplate = $"{timestamp}_%(resolution)s_%(title)s.%(ext)s";

            var outputFolderPath = _downloadRequest.OutputFilePath;
            var outputFilePath = Path.Combine(outputFolderPath, outputFileNameTemplate);

            var allArgs = new List<string>(args)
            {
                "--prefer-ffmpeg",
                "--no-continue",
                "--restrict-filenames",
                $"--ffmpeg-location \"{Settings.Instance.FfmpegToolPath}\"",
                $"--output \"{outputFilePath}\"",
                $"\"{_downloadRequest.Url}\""
            };

            if (_downloadRequest.EncodeMp4)
                allArgs.Add("--recode-video mp4");

            var workingDirectory = outputFolderPath;

            var allArgsInline = string.Join(" ", allArgs);

            var processDescriptor = new ProcessStartInfo
            {
                FileName = Settings.Instance.YoutubeToolPath,
                Arguments = allArgsInline,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                WorkingDirectory = workingDirectory
            };


            return new Process
            {
                StartInfo = processDescriptor
            };
        }
    }
}
