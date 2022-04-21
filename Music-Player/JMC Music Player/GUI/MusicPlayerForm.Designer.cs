
namespace JMC_Music_Player.GUI
{
    partial class MusicPlayerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MusicPlayerForm));
            this.NextBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.PreviousBtn = new System.Windows.Forms.Button();
            this.PlayPauseBtn = new System.Windows.Forms.Button();
            this.SongDisplayListBox = new System.Windows.Forms.ListBox();
            this.MusicPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.AddBtn = new System.Windows.Forms.Button();
            this.SearchTB = new System.Windows.Forms.TextBox();
            this.SearchBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MusicPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // NextBtn
            // 
            this.NextBtn.Enabled = false;
            this.NextBtn.Location = new System.Drawing.Point(116, 206);
            this.NextBtn.Name = "NextBtn";
            this.NextBtn.Size = new System.Drawing.Size(105, 34);
            this.NextBtn.TabIndex = 4;
            this.NextBtn.Text = "Next";
            this.NextBtn.UseVisualStyleBackColor = true;
            this.NextBtn.Click += new System.EventHandler(this.NextBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(9, 166);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(212, 34);
            this.StopBtn.TabIndex = 2;
            this.StopBtn.Text = "Stop";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // PreviousBtn
            // 
            this.PreviousBtn.Enabled = false;
            this.PreviousBtn.Location = new System.Drawing.Point(9, 206);
            this.PreviousBtn.Name = "PreviousBtn";
            this.PreviousBtn.Size = new System.Drawing.Size(105, 34);
            this.PreviousBtn.TabIndex = 3;
            this.PreviousBtn.Text = "Previous";
            this.PreviousBtn.UseVisualStyleBackColor = true;
            this.PreviousBtn.Click += new System.EventHandler(this.PreviousBtn_Click);
            // 
            // PlayPauseBtn
            // 
            this.PlayPauseBtn.Location = new System.Drawing.Point(12, 99);
            this.PlayPauseBtn.Name = "PlayPauseBtn";
            this.PlayPauseBtn.Size = new System.Drawing.Size(212, 61);
            this.PlayPauseBtn.TabIndex = 1;
            this.PlayPauseBtn.Text = "Play / Pause";
            this.PlayPauseBtn.UseVisualStyleBackColor = true;
            this.PlayPauseBtn.Click += new System.EventHandler(this.PlayPauseBtn_Click);
            // 
            // SongDisplayListBox
            // 
            this.SongDisplayListBox.FormattingEnabled = true;
            this.SongDisplayListBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SongDisplayListBox.Location = new System.Drawing.Point(230, 99);
            this.SongDisplayListBox.Name = "SongDisplayListBox";
            this.SongDisplayListBox.Size = new System.Drawing.Size(513, 342);
            this.SongDisplayListBox.TabIndex = 30;
            this.SongDisplayListBox.TabStop = false;
            this.SongDisplayListBox.UseTabStops = false;
            // 
            // MusicPlayer
            // 
            this.MusicPlayer.CausesValidation = false;
            this.MusicPlayer.Enabled = true;
            this.MusicPlayer.Location = new System.Drawing.Point(12, 33);
            this.MusicPlayer.Name = "MusicPlayer";
            this.MusicPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MusicPlayer.OcxState")));
            this.MusicPlayer.Size = new System.Drawing.Size(0, 0);
            this.MusicPlayer.TabIndex = 24;
            this.MusicPlayer.Visible = false;
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(9, 379);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(212, 61);
            this.AddBtn.TabIndex = 7;
            this.AddBtn.Text = "Add Songs";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // SearchTB
            // 
            this.SearchTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTB.Location = new System.Drawing.Point(9, 275);
            this.SearchTB.Name = "SearchTB";
            this.SearchTB.Size = new System.Drawing.Size(212, 26);
            this.SearchTB.TabIndex = 5;
            this.SearchTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchTB_KeyPress);
            // 
            // SearchBtn
            // 
            this.SearchBtn.Location = new System.Drawing.Point(9, 307);
            this.SearchBtn.Name = "SearchBtn";
            this.SearchBtn.Size = new System.Drawing.Size(212, 61);
            this.SearchBtn.TabIndex = 6;
            this.SearchBtn.Text = "Search";
            this.SearchBtn.UseVisualStyleBackColor = true;
            this.SearchBtn.Click += new System.EventHandler(this.SearchBtn_Click);
            // 
            // MusicPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 528);
            this.Controls.Add(this.SearchBtn);
            this.Controls.Add(this.SearchTB);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.MusicPlayer);
            this.Controls.Add(this.SongDisplayListBox);
            this.Controls.Add(this.PreviousBtn);
            this.Controls.Add(this.PlayPauseBtn);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.NextBtn);
            this.Name = "MusicPlayerForm";
            this.Text = "Music Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MusicPlayerForm_FormClosing);
            this.Load += new System.EventHandler(this.MusicPlayerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MusicPlayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Button PreviousBtn;
        private System.Windows.Forms.Button PlayPauseBtn;
        private System.Windows.Forms.ListBox SongDisplayListBox;
        private AxWMPLib.AxWindowsMediaPlayer MusicPlayer;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.TextBox SearchTB;
        private System.Windows.Forms.Button SearchBtn;
    }
}