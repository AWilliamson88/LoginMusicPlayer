
namespace JMC_Music_Server
{
    partial class MusicServerForm
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
            this.StartBtn = new System.Windows.Forms.Button();
            this.ClientLbl = new System.Windows.Forms.Label();
            this.ClientNumberLbl = new System.Windows.Forms.Label();
            this.StopBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartBtn
            // 
            this.StartBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.StartBtn.Location = new System.Drawing.Point(24, 64);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(132, 100);
            this.StartBtn.TabIndex = 0;
            this.StartBtn.Text = "Start Server";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // ClientLbl
            // 
            this.ClientLbl.AutoSize = true;
            this.ClientLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ClientLbl.Location = new System.Drawing.Point(58, 26);
            this.ClientLbl.Name = "ClientLbl";
            this.ClientLbl.Size = new System.Drawing.Size(61, 20);
            this.ClientLbl.TabIndex = 1;
            this.ClientLbl.Text = "Clients:";
            // 
            // ClientNumberLbl
            // 
            this.ClientNumberLbl.AutoSize = true;
            this.ClientNumberLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ClientNumberLbl.Location = new System.Drawing.Point(125, 26);
            this.ClientNumberLbl.Name = "ClientNumberLbl";
            this.ClientNumberLbl.Size = new System.Drawing.Size(18, 20);
            this.ClientNumberLbl.TabIndex = 2;
            this.ClientNumberLbl.Text = "0";
            // 
            // StopBtn
            // 
            this.StopBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.StopBtn.Location = new System.Drawing.Point(178, 64);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(132, 100);
            this.StopBtn.TabIndex = 3;
            this.StopBtn.Text = "Stop Server";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // MusicServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 195);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.ClientNumberLbl);
            this.Controls.Add(this.ClientLbl);
            this.Controls.Add(this.StartBtn);
            this.Name = "MusicServerForm";
            this.Text = "Music Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MusicServerForm_FormClosing);
            this.Load += new System.EventHandler(this.MusicServerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Label ClientLbl;
        private System.Windows.Forms.Label ClientNumberLbl;
        private System.Windows.Forms.Button StopBtn;
    }
}

