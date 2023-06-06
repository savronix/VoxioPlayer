using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp.Shared;

namespace VoxioPlayer.Forms
{
    public partial class Player : Form
    {
        public LibVLC _libVLC;
        public LibVLCSharp.Shared.MediaPlayer _mp;
        public Media media;
        private System.Windows.Forms.Timer _timer;
        public bool isFullscreen = false;
        public bool isPlaying = false;
        public Size oldVideoSize;
        public Size oldFormSize;
        public Point oldVideoLocation;
        private bool _isDragging;
        // DLL importları
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        public Player(string text, string videoFile)
        {
            InitializeComponent();
            this.Text = "Voxio Player - " + text;
            this.Icon = global::VoxioPlayer.Properties.Resources.programIcon;

            string[] videoExtensions = { ".3g2", ".3gp", ".amv", ".asf", ".avi", ".divx", ".flv", ".gvi", ".h264", ".m4v", ".mkv", ".mov", ".mp4", ".mpg", ".mpeg", ".rm", ".swf", ".vob", ".wmv",".m3u8","vr1" }; // Video uzantıları
            string[] musicExtensions = { ".aac", ".aif", ".amr", ".ape", ".flac", ".m4a", ".mp3", ".ogg", ".opus", ".wav", ".wma" }; // Müzik uzantıları

            string fileExtension = System.IO.Path.GetExtension(videoFile).ToLower();

            if (videoExtensions.Contains(fileExtension))
            {
                InitializeVLC(videoFile,"video");
            }
            else if (musicExtensions.Contains(fileExtension))
            {
                InitializeVLC(videoFile,"music");
            }
        }
        string videoLink;

        public void InitializeVLC(string Link,string tur)//music 
        {
            videoLink = Link;// Örnek olarak 20 kullanıldı, istediğiniz değeri belirleyebilirsiniz
            IntPtr region = CreateRoundRectRgn(
                0, 0, lblTimeLine1.Width, lblTimeLine1.Height, borderRadius, borderRadius);

            // Label kontrolünün Region'ı ayarlanır
            SetWindowRgn(lblTimeLine1.Handle, region, true);
            Core.Initialize();
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(ShortcutEvent);
            oldVideoSize = videoView2.Size;
            oldFormSize = this.Size;
            oldVideoLocation = videoView2.Location;
            //VLC stuff
            _libVLC = new LibVLC();
            _mp = new LibVLCSharp.Shared.MediaPlayer(_libVLC);
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000; // Her saniye güncelle
            _timer.Tick += Timer_Tick;
            _mp.Volume = 89;
            videoView2.MediaPlayer = _mp;
            InitializeLabel();
            InitializeLabelSes();
            PlayURLFile(videoLink);
            if (tur=="video")
            {
                videoView2.Visible = true;
                pctrbxMusic.Visible = false;
                this.MinimumSize = new Size(816, 542);
                this.Size = new Size(816, 542);
                videoView2.BackColor = Color.FromArgb(33, 37, 41);

            }
            else if (tur == "music")
            {
                videoView2.Visible = false;
                pctrbxMusic.Visible = true;
                this.MinimumSize = new Size(500, 400);
                this.Size = new Size(500, 400);
            }
        }

       

        int borderRadius = 5;
        private void InitializeLabelSes()
        {// Örnek olarak 20 kullanıldı, istediğiniz değeri belirleyebilirsiniz
            IntPtr region = CreateRoundRectRgn(
                0, 0, lblSes.Width, lblSes2.Height, borderRadius, borderRadius);

            // Label kontrolünün Region'ı ayarlanır
            SetWindowRgn(lblSes.Handle, region, true);
            lblSes2.Width = _mp.Volume;
            IntPtr region2 = CreateRoundRectRgn(
                0, 0, lblSes2.Width, lblSes2.Height, borderRadius, borderRadius);

            // Label kontrolünün Region'ı ayarlanır
            SetWindowRgn(lblSes2.Handle, region2, true);
            lblSesDuzeyi.Text = _mp.Volume.ToString();
            lblSes.MouseDown += lblSes_MouseDown;
            lblSes.MouseMove += lblSes_MouseMove; // Yeni eklendi
            lblSes.MouseUp += lblSes_MouseUp; // Yeni eklendi

            lblSes2.MouseDown += lblSes_MouseDown;
            lblSes2.MouseMove += lblSes_MouseMove; // Yeni eklendi
            lblSes2.MouseUp += lblSes_MouseUp; // Yeni eklendi
        }
        private void InitializeLabel()
        {
            lblTimeLine1.MouseDown += lblTimeLine_MouseDown;
            lblTimeLine1.MouseMove += lblTimeLine_MouseMove; // Yeni eklendi
            lblTimeLine1.MouseUp += lblTimeLine_MouseUp; // Yeni eklendi

            lblTimeLine2.MouseDown += lblTimeLine_MouseDown;
            lblTimeLine2.MouseMove += lblTimeLine_MouseMove; // Yeni eklendi
            lblTimeLine2.MouseUp += lblTimeLine_MouseUp; // Yeni eklendi

            // Zaman değiştiğinde olayı ele al
            _timer.Start();
        }

        private void lblSes_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                // İlerleme çubuğunun tıklanma yüzdesini hesapla
                var clickedPercentage = (double)e.X / lblSes.Width;

                // Toplam süreyi al
                var totalDuration = 100;

                if (totalDuration > 0)
                {
                    // İlgili süreyi hesapla
                    var targetTime = (long)(totalDuration * clickedPercentage);

                    // MediaPlayer'da ilgili süreye atla
                    _mp.Volume = (int)targetTime;

                    // İlerleme çubuğunu güncelle
                    UpdatelblSes(clickedPercentage * 100);
                }
            }
        }

        private void lblSes_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Sadece sol tıkla sürükleme işlemi gerçekleştir
            {
                // İlerleme çubuğunun tıklanma yüzdesini hesapla
                var clickedPercentage = (double)e.X / lblSes.Width;

                // Toplam süreyi al
                var totalDuration = 100;

                if (totalDuration > 0)
                {
                    // İlgili süreyi hesapla
                    var targetTime = (long)(totalDuration * clickedPercentage);

                    // Videonun toplam süresinden dışına çıkılıyorsa işlem yapma
                    if (targetTime > totalDuration || targetTime < 0)
                        return;

                    // MediaPlayer'da ilgili süreye atla
                    _mp.Volume = (int)targetTime;

                    // İlerleme çubuğunu güncelle
                    UpdatelblSes(clickedPercentage * 100);
                }
            }
        }

        private void lblSes_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Sadece sol tıkla sürükleme işlemi gerçekleştir
            {
                // Videonun toplam süresinden dışına çıkıldıysa işlem yapma
                var totalDuration = 100;
                if (_mp.Volume > totalDuration || _mp.Volume < 0)
                    return;
                lblSesDuzeyi.Text = " " + _mp.Volume.ToString();
            }
        }
        private void UpdatelblSes(double progressPercentage)
        {
            // İlerleme çubuğunun değerini güncelle
            lblSes2.Width = (int)(progressPercentage * lblSes.Width / 100);

            // Süreleri güncelle
            IntPtr region2 = CreateRoundRectRgn(
                0, 0, lblSes2.Width, lblSes2.Height, borderRadius, borderRadius);

            // Label kontrolünün Region'ı ayarlanır
            SetWindowRgn(lblSes2.Handle, region2, true);

            // Değerler total değerin içine girdiyse videoyu tekrar oynat
        }
        //****
        private void lblTimeLine_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true; // Sürükleme işlemi başladı

                // İlerleme çubuğunun tıklanma yüzdesini hesapla
                var clickedPercentage = (double)e.X / lblTimeLine1.Width;

                // Toplam süreyi al
                var totalDuration = _mp.Length;

                if (totalDuration > 0)
                {
                    // İlgili süreyi hesapla
                    var targetTime = (long)(totalDuration * clickedPercentage);

                    // MediaPlayer'da ilgili süreye atla
                    _mp.Time = targetTime;

                    // İlerleme çubuğunu güncelle
                    UpdatelblTimeLine(clickedPercentage * 100);
                }
            }
        }

        private void lblTimeLine_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging && e.Button == MouseButtons.Left) // Sadece sol tıkla sürükleme işlemi gerçekleştir
            {
                // İlerleme çubuğunun tıklanma yüzdesini hesapla
                var clickedPercentage = (double)e.X / lblTimeLine1.Width;

                // Toplam süreyi al
                var totalDuration = _mp.Length;

                if (totalDuration > 0)
                {
                    // İlgili süreyi hesapla
                    var targetTime = (long)(totalDuration * clickedPercentage);

                    // Videonun toplam süresinden dışına çıkılıyorsa işlem yapma
                    if (targetTime > totalDuration || targetTime < 0)
                        return;

                    // MediaPlayer'da ilgili süreye atla
                    _mp.Time = targetTime;

                    // İlerleme çubuğunu güncelle
                    UpdatelblTimeLine(clickedPercentage * 100);
                }
            }
        }

        private void lblTimeLine_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isDragging && e.Button == MouseButtons.Left) // Sadece sol tıkla sürükleme işlemi gerçekleştir
            {
                // Videonun toplam süresinden dışına çıkıldıysa işlem yapma
                var totalDuration = _mp.Length;
                if (_mp.Time > totalDuration || _mp.Time < 0)
                    return;

                _isDragging = false; // Sürükleme işlemi bitti
            }
        }




        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!_isDragging && _mp != null && _mp.IsPlaying)
            {
                // İlerleme çubuğunun değerini güncelle
                var currentPosition = _mp.Time;
                var totalDuration = _mp.Length;
                var progressPercentage = currentPosition / (double)totalDuration * 100;

                // İlerleme çubuğunu güncelle
                UpdatelblTimeLine(progressPercentage);
            }
        }

        private void UpdatelblTimeLine(double progressPercentage)
        {
            // İlerleme çubuğunun değerini güncelle
            lblTimeLine2.Width = (int)(progressPercentage * lblTimeLine1.Width / 100);

            // İlerleme çubuğunda sürenin gösterimi için zamanı biçimle
            var currentPosition = _mp.Time;
            var totalDuration = _mp.Length;
            var currentTime = TimeSpan.FromMilliseconds(currentPosition).ToString(@"hh\:mm\:ss");
            var totalTime = TimeSpan.FromMilliseconds(totalDuration).ToString(@"hh\:mm\:ss");

            // Süreleri güncelle
            IntPtr region2 = CreateRoundRectRgn(
                0, 0, lblTimeLine2.Width, lblTimeLine2.Height, borderRadius, borderRadius);

            // Label kontrolünün Region'ı ayarlanır
            SetWindowRgn(lblTimeLine2.Handle, region2, true);
            lblCurrentTime.Text = currentTime;
            lblTotalTime.Text = totalTime;

            // Değerler total değerin içine girdiyse videoyu tekrar oynat
            if (progressPercentage >= 100)
            {
                _timer.Stop(); // Timer'ı durdur

                _mp.Stop(); // MediaPlayer'ı durdur
                _mp.Play(); // MediaPlayer'ı tekrar başlat

                _timer.Start(); // Timer'ı tekrar başlat
            }
        }



        public void ShortcutEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && isFullscreen) // from fullscreen to window
            {
                this.FormBorderStyle = FormBorderStyle.Sizable; // change form style
                this.WindowState = FormWindowState.Normal; // back to normal size
                this.Size = oldFormSize;
                videoView2.Size = oldVideoSize; // make video the same size as the form
                videoView2.Location = oldVideoLocation; // remove the offset
                isFullscreen = false;
                panel1.Visible = true;
            }

            if (isPlaying) // while the video is playing
            {
                if (e.KeyCode == Keys.Space) // Pause and Play
                {
                    if (_mp.State == VLCState.Playing) // if is playing
                    {
                        _mp.Pause(); // pause
                        isPlaying = false;
                        this.btnPause.Image = global::VoxioPlayer.Properties.Resources.play;
                    }

                }

                if (e.KeyCode == Keys.J || e.KeyCode == Keys.Left) // skip 1% backwards
                {
                    _mp.Position -= 0.001f;
                }
                if (e.KeyCode == Keys.L || e.KeyCode == Keys.Right) // skip 1% forwards
                {
                    _mp.Position += 0.001f;
                }
            }
            else
            {
                if (e.KeyCode == Keys.Space)
                {
                    _mp.Play();
                    isPlaying = true;
                    this.btnPause.Image = global::VoxioPlayer.Properties.Resources.pause;
                }
            }
        }
        public void PlayURLFile(string file)
        {
            if (!string.IsNullOrEmpty(file))
            {
                media = new Media(_libVLC, new Uri(file));
                media.AddOption(":network-caching=500");
                media.AddOption("sout-rtp-caching=100");
                media.AddOption("sout-rtp-port-audio=20000");
                media.AddOption("sout-rtp-port-video=20002");
                media.AddOption(":rtp-timeout=10000");
                media.AddOption(":rtsp-tcp=0");
                media.AddOption(":rtsp-frame-buffer-size=1024");
                media.AddOption(":rtsp-caching=0");
                media.AddOption(":live-caching=0");
                _mp.Play(media);
                isPlaying = true;
                _timer.Start();

            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                _mp.Pause();
                isPlaying = false;
                this.btnPause.Image = global::VoxioPlayer.Properties.Resources.play;
            }
            else
            {
                _mp.Play();
                isPlaying = true;
                this.btnPause.Image = global::VoxioPlayer.Properties.Resources.pause;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _mp.Position -= 0.001f;
        }

        private void btnForwand_Click(object sender, EventArgs e)
        {
            _mp.Position += 0.001f;
        }

        private void UpdateLabelWidths()
        {
            IntPtr region1 = CreateRoundRectRgn(
                0, 0, lblTimeLine1.Width, lblTimeLine1.Height, borderRadius, borderRadius);
            SetWindowRgn(lblTimeLine1.Handle, region1, true);

            IntPtr region2 = CreateRoundRectRgn(
                0, 0, lblTimeLine2.Width, lblTimeLine2.Height, borderRadius, borderRadius);
            SetWindowRgn(lblTimeLine2.Handle, region2, true);
        }


        private void btnFullScreen_Click(object sender, EventArgs e)
        {
            if (isFullscreen)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable; // change form style
                this.WindowState = FormWindowState.Normal; // back to normal size
                this.Size = oldFormSize;
                videoView2.Size = oldVideoSize; // make video the same size as the form
                videoView2.Location = oldVideoLocation; // remove the offset
                isFullscreen = false;
                panel1.Visible = true;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None; // change form style
                this.WindowState = FormWindowState.Maximized;
                videoView2.Size = this.Size; // make video the same size as the form
                videoView2.Location = new Point(0, 0); // remove the offset
                isFullscreen = true;
                panel1.Visible = false;
            }
        }

        private void MediaPlayer2_SizeChanged(object sender, EventArgs e)
        {
            UpdateLabelWidths();
        }

        int lastVolume = 0;
        private void lblSesDuzeyi_MouseClick(object sender, MouseEventArgs e)
        {
            if (_mp.Volume > 0)
            {
                lastVolume = _mp.Volume;
                _mp.Volume = 0;
                lblSesDuzeyi.Text = "0";
                lblSes2.Width = _mp.Volume;
                IntPtr region2 = CreateRoundRectRgn(
                    0, 0, lblSes2.Width, lblSes2.Height, borderRadius, borderRadius);
                SetWindowRgn(lblSes2.Handle, region2, true);
                this.lblSesDuzeyi.Image = global::VoxioPlayer.Properties.Resources.seskapali;
            }
            else
            {
                _mp.Volume = lastVolume;
                lblSesDuzeyi.Text = " " + lastVolume.ToString();
                lblSes2.Width = _mp.Volume;
                IntPtr region2 = CreateRoundRectRgn(
                    0, 0, lblSes2.Width, lblSes2.Height, borderRadius, borderRadius);
                SetWindowRgn(lblSes2.Handle, region2, true);
                this.lblSesDuzeyi.Image = global::VoxioPlayer.Properties.Resources.ses;
            }
        }

    }
}
