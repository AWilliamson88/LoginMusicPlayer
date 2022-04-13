
namespace Music_Player
{
    partial class UserView
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
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.MusicPlayerBtn = new System.Windows.Forms.Button();
            this.CreateAccBtn = new System.Windows.Forms.Button();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.MenuHeadPanel = new System.Windows.Forms.Panel();
            this.MenuHeaderLbl = new System.Windows.Forms.Label();
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.DesktopPanel = new System.Windows.Forms.Panel();
            this.MenuPanel.SuspendLayout();
            this.MenuHeadPanel.SuspendLayout();
            this.TitlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.MenuPanel.Controls.Add(this.MusicPlayerBtn);
            this.MenuPanel.Controls.Add(this.CreateAccBtn);
            this.MenuPanel.Controls.Add(this.LoginBtn);
            this.MenuPanel.Controls.Add(this.MenuHeadPanel);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(200, 647);
            this.MenuPanel.TabIndex = 0;
            // 
            // MusicPlayerBtn
            // 
            this.MusicPlayerBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.MusicPlayerBtn.Enabled = false;
            this.MusicPlayerBtn.FlatAppearance.BorderSize = 0;
            this.MusicPlayerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MusicPlayerBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.MusicPlayerBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.MusicPlayerBtn.Location = new System.Drawing.Point(0, 218);
            this.MusicPlayerBtn.Name = "MusicPlayerBtn";
            this.MusicPlayerBtn.Size = new System.Drawing.Size(200, 69);
            this.MusicPlayerBtn.TabIndex = 2;
            this.MusicPlayerBtn.Text = "Music Player";
            this.MusicPlayerBtn.UseVisualStyleBackColor = true;
            this.MusicPlayerBtn.Visible = false;
            // 
            // CreateAccBtn
            // 
            this.CreateAccBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.CreateAccBtn.FlatAppearance.BorderSize = 0;
            this.CreateAccBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateAccBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateAccBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.CreateAccBtn.Location = new System.Drawing.Point(0, 149);
            this.CreateAccBtn.Name = "CreateAccBtn";
            this.CreateAccBtn.Size = new System.Drawing.Size(200, 69);
            this.CreateAccBtn.TabIndex = 3;
            this.CreateAccBtn.Text = "Create Account";
            this.CreateAccBtn.UseVisualStyleBackColor = true;
            this.CreateAccBtn.Click += new System.EventHandler(this.CreateAccBtn_Click);
            // 
            // LoginBtn
            // 
            this.LoginBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.LoginBtn.FlatAppearance.BorderSize = 0;
            this.LoginBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LoginBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.LoginBtn.Location = new System.Drawing.Point(0, 80);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(200, 69);
            this.LoginBtn.TabIndex = 1;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // MenuHeadPanel
            // 
            this.MenuHeadPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(122)))), ((int)(((byte)(73)))));
            this.MenuHeadPanel.Controls.Add(this.MenuHeaderLbl);
            this.MenuHeadPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuHeadPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuHeadPanel.Name = "MenuHeadPanel";
            this.MenuHeadPanel.Size = new System.Drawing.Size(200, 80);
            this.MenuHeadPanel.TabIndex = 0;
            // 
            // MenuHeaderLbl
            // 
            this.MenuHeaderLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MenuHeaderLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuHeaderLbl.ForeColor = System.Drawing.Color.Gainsboro;
            this.MenuHeaderLbl.Location = new System.Drawing.Point(0, 0);
            this.MenuHeaderLbl.Name = "MenuHeaderLbl";
            this.MenuHeaderLbl.Size = new System.Drawing.Size(200, 80);
            this.MenuHeaderLbl.TabIndex = 1;
            this.MenuHeaderLbl.Text = "WELCOME";
            this.MenuHeaderLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(183)))), ((int)(((byte)(110)))));
            this.TitlePanel.Controls.Add(this.TitleLbl);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TitlePanel.Location = new System.Drawing.Point(200, 0);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(771, 80);
            this.TitlePanel.TabIndex = 1;
            // 
            // TitleLbl
            // 
            this.TitleLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLbl.ForeColor = System.Drawing.Color.Gainsboro;
            this.TitleLbl.Location = new System.Drawing.Point(0, 0);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(771, 80);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "HOME";
            this.TitleLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DesktopPanel
            // 
            this.DesktopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DesktopPanel.Location = new System.Drawing.Point(200, 80);
            this.DesktopPanel.Name = "DesktopPanel";
            this.DesktopPanel.Size = new System.Drawing.Size(771, 567);
            this.DesktopPanel.TabIndex = 2;
            // 
            // UserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 647);
            this.Controls.Add(this.DesktopPanel);
            this.Controls.Add(this.TitlePanel);
            this.Controls.Add(this.MenuPanel);
            this.Name = "UserView";
            this.Text = "JMC Music Player";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UserView_FormClosing);
            this.Load += new System.EventHandler(this.UserView_Load);
            this.MenuPanel.ResumeLayout(false);
            this.MenuHeadPanel.ResumeLayout(false);
            this.TitlePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.Panel MenuHeadPanel;
        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Button CreateAccBtn;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Label MenuHeaderLbl;
        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.Panel DesktopPanel;
        private System.Windows.Forms.Button MusicPlayerBtn;
    }
}

