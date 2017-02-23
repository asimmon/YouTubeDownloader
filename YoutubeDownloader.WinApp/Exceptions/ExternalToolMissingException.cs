using System;

namespace YoutubeDownloader.WinApp.Exceptions
{
    [Serializable]
    public class ExternalToolMissingException : Exception
    {
        public string ToolName { get; private set; }

        public string ToolPath { get; private set; }

        public ExternalToolMissingException(string toolName, string toolPath)
            : base($"L'outil externe {toolName} n'existe pas à l'emplacement {toolPath}")
        {
            ToolName = toolName;
            ToolPath = toolPath;
        }
    }
}
