using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using NLog;
using YoutubeDownloader.WinApp.Exceptions;
using YoutubeDownloader.WinApp.Models;

namespace YoutubeDownloader.WinApp
{
    public partial class MainForm : Form
    {
        private Logger _logger;

        private static readonly Regex YoutubeUrlRegex = new Regex(
            "^https?://.*(?:youtu.be|v|u\\w|embed|watch?v=)([^#&?]*).*$",
            RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase
        );

        private readonly DownloadRequest _request = new DownloadRequest();

        public MainForm()
        {
            InitializeComponent();

            qualityComboBox.Items.Add(new VideoQuality("240p", 240));
            qualityComboBox.Items.Add(new VideoQuality("360p", 360));
            qualityComboBox.Items.Add(new VideoQuality("480p", 480));
            qualityComboBox.Items.Add(new VideoQuality("720p", 720));
            qualityComboBox.Items.Add(new VideoQuality("1080p", 1080));
            qualityComboBox.Items.Add(new VideoQuality("1440p", 1440));
            qualityComboBox.Items.Add(new VideoQuality("2160p 4K", 2160));

            qualityComboBox.SelectedIndex = 3;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _logger = LogManager.GetLogger("formLogger");

            try
            {
                Settings.Instance.Initialize();

#if DEBUG
                inputTextBox.Text = "https://www.youtube.com/watch?v=_F_u0iEG74E";
                outputTextBox.Text = @"C:\Users\ASI\Desktop\vid\";
#endif

                EnableDownloadButtonIfRequestIsValid();
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex);

                var toolEx = ex as ExternalToolMissingException;
                if (toolEx != null)
                    MessageBox.Show(this, toolEx.Message);

                inputTextBox.Enabled = false;
                inputTextBox.ReadOnly = true;

                outputTextBox.Enabled = false;
                outputTextBox.ReadOnly = true;

                chooseOutputButton.Enabled = false;
                convertCheckBox.Enabled = false;
            }
        }

        private void InputTextBoxTextChanged(object sender, EventArgs e)
        {
            _request.Url = inputTextBox.Text.Trim();
            EnableDownloadButtonIfRequestIsValid();
        }

        private void OutputTextBoxTextChanged(object sender, EventArgs e)
        {
            _request.OutputFilePath = outputTextBox.Text.Trim();
            EnableDownloadButtonIfRequestIsValid();
        }

        private void EnableDownloadButtonIfRequestIsValid()
        {
            if (!YoutubeUrlRegex.IsMatch(_request.Url))
            {
                okButton.Enabled = false;
                return;
            }

            if (string.IsNullOrWhiteSpace(_request.OutputFilePath))
            {
                okButton.Enabled = false;
                return;
            }

            okButton.Enabled = true;
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            StartDownload();
        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            StopDownload();
        }

        private CancellationTokenSource _tokenSource;

        private void StopDownload()
        {
            if (_tokenSource != null)
            {
                _tokenSource.Cancel();
                _tokenSource = null;
                statusLabel.Text = "Opération annulée.";
            }
        }

        private async void StartDownload()
        {
            okButton.Enabled = false;
            cancelButton.Enabled = true;
            inputTextBox.Enabled = false;
            outputTextBox.Enabled = false;
            chooseOutputButton.Enabled = false;

            _logger.Info("Video url: {0}", _request.Url);
            _logger.Info("Output folder: {0}", _request.OutputFilePath);
            _logger.Info("Convert to MP4? {0}", _request.EncodeMp4 ? "yes" : "no");

            if (_tokenSource != null)
            {
                try { _tokenSource.Dispose(); }
                catch
                {
                    // ignored
                }
            }

            _tokenSource = new CancellationTokenSource();
            var token = _tokenSource.Token;

            try
            {
                var api = new YoutubeApi(_request, _logger);

                statusLabel.Text = "Récupération de la liste des formats disponibles...";

                var formats = await api.GetFormats();

                PopulateDownloadWithBestFormats(formats);

                if (_request.VideoFormat == null)
                    throw new YoutubeFormatNotFoundException("video");

                if (_request.AudioFormat == null)
                    throw new YoutubeFormatNotFoundException("audio");

                _logger.Info("Best video format: {0}", _request.VideoFormat);
                _logger.Info("Best audio format: {0}", _request.AudioFormat);

                if (!token.IsCancellationRequested)
                {
                    statusLabel.Text = $"Téléchargement de la vidéo au format {_request.VideoFormat.Resolution} en cours...";
                    await api.DownloadVideo(token);
                }

                statusLabel.Text = "Téléchargement terminé.";
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Une erreur est survenue:");
                statusLabel.Text = "Une erreur est survenue.";
            }
            finally
            {
                okButton.Enabled = true;
                cancelButton.Enabled = false;
                inputTextBox.Enabled = true;
                outputTextBox.Enabled = true;
                chooseOutputButton.Enabled = true;
            }
        }

        private void PopulateDownloadWithBestFormats(List<YoutubeFormat> formats)
        {
            var maxVideoHeight = int.MaxValue;

            var maxQuality = qualityComboBox.SelectedItem as VideoQuality;
            if (maxQuality != null)
            {
                maxVideoHeight = maxQuality.VideoHeight;
            }

            _request.VideoFormat = formats.Where(f => f.Kind == YoutubeFormatKind.Video)
                    .Where(f => f.VideoHeight <= maxVideoHeight)
                    .OrderByDescending(f => f.Quality)
                    .FirstOrDefault();

            _request.AudioFormat = formats.Where(f => f.Kind == YoutubeFormatKind.Audio)
                    .OrderByDescending(f => f.Quality)
                    .FirstOrDefault();
        }

        private void ConvertCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            if (convertCheckBox.Checked)
            {
                const string title = "Confirmer la conversion en MP4";
                const string content = "La conversion en MP4 peut prendre beaucoup de temps selon la qualité et la longueur de la vidéo. Êtes-vous sûr de vouloir l'utiliser ?";

                var confirmation = MessageBoxEx.Show(
                    this,
                    content, title,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1
                );

                if (confirmation == DialogResult.No)
                    convertCheckBox.Checked = false;
            }

            _request.EncodeMp4 = convertCheckBox.Checked;
        }

        private void chooseOutputButton_Click(object sender, EventArgs e)
        {
            var result = folderBrowser.ShowDialog(this);
            if (result == DialogResult.OK && Directory.Exists(folderBrowser.SelectedPath))
            {
                outputTextBox.Text = folderBrowser.SelectedPath;
            }
        }
    }
}
