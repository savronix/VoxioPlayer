namespace VoxioPlayer.Forms
{
    partial class Player
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Player));
            this.videoView2 = new LibVLCSharp.WinForms.VideoView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSes2 = new System.Windows.Forms.Label();
            this.lblSesDuzeyi = new System.Windows.Forms.Label();
            this.lblSes = new System.Windows.Forms.Label();
            this.lblTimeLine2 = new System.Windows.Forms.Label();
            this.lblTimeLine1 = new System.Windows.Forms.Label();
            this.lblTotalTime = new System.Windows.Forms.Label();
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.btnFullScreen = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnForwand = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.pctrbxMusic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.videoView2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrbxMusic)).BeginInit();
            this.SuspendLayout();
            // 
            // videoView2
            // 
            this.videoView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoView2.BackColor = System.Drawing.Color.Black;
            this.videoView2.Location = new System.Drawing.Point(0, 0);
            this.videoView2.MediaPlayer = null;
            this.videoView2.Name = "videoView2";
            this.videoView2.Size = new System.Drawing.Size(800, 435);
            this.videoView2.TabIndex = 0;
            this.videoView2.Text = "videoView2";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.panel1.Controls.Add(this.lblSes2);
            this.panel1.Controls.Add(this.lblSesDuzeyi);
            this.panel1.Controls.Add(this.lblSes);
            this.panel1.Controls.Add(this.lblTimeLine2);
            this.panel1.Controls.Add(this.lblTimeLine1);
            this.panel1.Controls.Add(this.lblTotalTime);
            this.panel1.Controls.Add(this.lblCurrentTime);
            this.panel1.Controls.Add(this.btnFullScreen);
            this.panel1.Controls.Add(this.btnBack);
            this.panel1.Controls.Add(this.btnForwand);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.panel1.Location = new System.Drawing.Point(0, 435);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 68);
            this.panel1.TabIndex = 1;
            // 
            // lblSes2
            // 
            this.lblSes2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSes2.BackColor = System.Drawing.Color.IndianRed;
            this.lblSes2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSes2.ForeColor = System.Drawing.Color.Black;
            this.lblSes2.Location = new System.Drawing.Point(77, 46);
            this.lblSes2.Name = "lblSes2";
            this.lblSes2.Size = new System.Drawing.Size(0, 12);
            this.lblSes2.TabIndex = 11;
            this.lblSes2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSesDuzeyi
            // 
            this.lblSesDuzeyi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSesDuzeyi.BackColor = System.Drawing.Color.Transparent;
            this.lblSesDuzeyi.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSesDuzeyi.ForeColor = System.Drawing.Color.White;
            this.lblSesDuzeyi.Image = global::VoxioPlayer.Properties.Resources.ses;
            this.lblSesDuzeyi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSesDuzeyi.Location = new System.Drawing.Point(11, 42);
            this.lblSesDuzeyi.Name = "lblSesDuzeyi";
            this.lblSesDuzeyi.Size = new System.Drawing.Size(60, 20);
            this.lblSesDuzeyi.TabIndex = 10;
            this.lblSesDuzeyi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSesDuzeyi.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblSesDuzeyi_MouseClick);
            // 
            // lblSes
            // 
            this.lblSes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSes.BackColor = System.Drawing.Color.Gray;
            this.lblSes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSes.ForeColor = System.Drawing.Color.Black;
            this.lblSes.Location = new System.Drawing.Point(77, 46);
            this.lblSes.Name = "lblSes";
            this.lblSes.Size = new System.Drawing.Size(100, 12);
            this.lblSes.TabIndex = 9;
            this.lblSes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTimeLine2
            // 
            this.lblTimeLine2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimeLine2.BackColor = System.Drawing.Color.IndianRed;
            this.lblTimeLine2.Font = new System.Drawing.Font("Arial", 6F, System.Drawing.FontStyle.Bold);
            this.lblTimeLine2.ForeColor = System.Drawing.Color.Black;
            this.lblTimeLine2.Location = new System.Drawing.Point(12, 2);
            this.lblTimeLine2.Name = "lblTimeLine2";
            this.lblTimeLine2.Size = new System.Drawing.Size(0, 12);
            this.lblTimeLine2.TabIndex = 8;
            this.lblTimeLine2.Text = "▶";
            this.lblTimeLine2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTimeLine1
            // 
            this.lblTimeLine1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimeLine1.BackColor = System.Drawing.Color.Gray;
            this.lblTimeLine1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTimeLine1.ForeColor = System.Drawing.Color.Black;
            this.lblTimeLine1.Location = new System.Drawing.Point(12, 2);
            this.lblTimeLine1.Name = "lblTimeLine1";
            this.lblTimeLine1.Size = new System.Drawing.Size(773, 12);
            this.lblTimeLine1.TabIndex = 7;
            this.lblTimeLine1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblTotalTime.AutoSize = true;
            this.lblTotalTime.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalTime.ForeColor = System.Drawing.Color.White;
            this.lblTotalTime.Location = new System.Drawing.Point(729, 14);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(58, 17);
            this.lblTotalTime.TabIndex = 6;
            this.lblTotalTime.Text = "00:00:00";
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCurrentTime.AutoSize = true;
            this.lblCurrentTime.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentTime.ForeColor = System.Drawing.Color.White;
            this.lblCurrentTime.Location = new System.Drawing.Point(11, 14);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(58, 17);
            this.lblCurrentTime.TabIndex = 5;
            this.lblCurrentTime.Text = "00:00:00";
            // 
            // btnFullScreen
            // 
            this.btnFullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFullScreen.FlatAppearance.BorderSize = 0;
            this.btnFullScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFullScreen.Image = global::VoxioPlayer.Properties.Resources.fullscreen;
            this.btnFullScreen.Location = new System.Drawing.Point(750, 35);
            this.btnFullScreen.Name = "btnFullScreen";
            this.btnFullScreen.Size = new System.Drawing.Size(35, 30);
            this.btnFullScreen.TabIndex = 3;
            this.btnFullScreen.UseVisualStyleBackColor = true;
            this.btnFullScreen.Click += new System.EventHandler(this.btnFullScreen_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Image = global::VoxioPlayer.Properties.Resources.gerisar;
            this.btnBack.Location = new System.Drawing.Point(341, 25);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(35, 30);
            this.btnBack.TabIndex = 2;
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnForwand
            // 
            this.btnForwand.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnForwand.FlatAppearance.BorderSize = 0;
            this.btnForwand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForwand.Image = global::VoxioPlayer.Properties.Resources.ilerisar;
            this.btnForwand.Location = new System.Drawing.Point(423, 25);
            this.btnForwand.Name = "btnForwand";
            this.btnForwand.Size = new System.Drawing.Size(38, 30);
            this.btnForwand.TabIndex = 1;
            this.btnForwand.UseVisualStyleBackColor = true;
            this.btnForwand.Click += new System.EventHandler(this.btnForwand_Click);
            // 
            // btnPause
            // 
            this.btnPause.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnPause.FlatAppearance.BorderSize = 0;
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Image = global::VoxioPlayer.Properties.Resources.pause;
            this.btnPause.Location = new System.Drawing.Point(382, 25);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(38, 30);
            this.btnPause.TabIndex = 0;
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // pctrbxMusic
            // 
            this.pctrbxMusic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pctrbxMusic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.pctrbxMusic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pctrbxMusic.Image = ((System.Drawing.Image)(resources.GetObject("pctrbxMusic.Image")));
            this.pctrbxMusic.Location = new System.Drawing.Point(0, 0);
            this.pctrbxMusic.Name = "pctrbxMusic";
            this.pctrbxMusic.Size = new System.Drawing.Size(800, 435);
            this.pctrbxMusic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctrbxMusic.TabIndex = 2;
            this.pctrbxMusic.TabStop = false;
            // 
            // Player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 503);
            this.Controls.Add(this.pctrbxMusic);
            this.Controls.Add(this.videoView2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(816, 542);
            this.Name = "Player";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Voxio Player -";
            this.SizeChanged += new System.EventHandler(this.MediaPlayer2_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.videoView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctrbxMusic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private LibVLCSharp.WinForms.VideoView videoView2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnForwand;
        private System.Windows.Forms.Button btnFullScreen;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Label lblTotalTime;
        private System.Windows.Forms.Label lblTimeLine1;
        private System.Windows.Forms.Label lblTimeLine2;
        private System.Windows.Forms.Label lblSesDuzeyi;
        private System.Windows.Forms.Label lblSes;
        private System.Windows.Forms.Label lblSes2;
        private System.Windows.Forms.PictureBox pctrbxMusic;
    }
}