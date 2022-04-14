
namespace JMC_Music_Player.GUI
{
    partial class CreateAccountForm
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
            this.CreateAccountBtn = new System.Windows.Forms.Button();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.UsernameTB = new System.Windows.Forms.TextBox();
            this.PasswordLbl = new System.Windows.Forms.Label();
            this.UsernameLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CreateAccountBtn
            // 
            this.CreateAccountBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.CreateAccountBtn.AutoSize = true;
            this.CreateAccountBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(183)))), ((int)(((byte)(110)))));
            this.CreateAccountBtn.Cursor = System.Windows.Forms.Cursors.Default;
            this.CreateAccountBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CreateAccountBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateAccountBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CreateAccountBtn.Location = new System.Drawing.Point(250, 283);
            this.CreateAccountBtn.Name = "CreateAccountBtn";
            this.CreateAccountBtn.Size = new System.Drawing.Size(254, 32);
            this.CreateAccountBtn.TabIndex = 9;
            this.CreateAccountBtn.Text = "Create Account";
            this.CreateAccountBtn.UseVisualStyleBackColor = false;
            this.CreateAccountBtn.Click += new System.EventHandler(this.CreateAccountBtn_Click);
            // 
            // PasswordTB
            // 
            this.PasswordTB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordTB.Location = new System.Drawing.Point(250, 219);
            this.PasswordTB.MaxLength = 50;
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.PasswordChar = 'O';
            this.PasswordTB.Size = new System.Drawing.Size(254, 26);
            this.PasswordTB.TabIndex = 8;
            this.PasswordTB.UseSystemPasswordChar = true;
            this.PasswordTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PasswordTB_KeyPress);
            // 
            // UsernameTB
            // 
            this.UsernameTB.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UsernameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameTB.Location = new System.Drawing.Point(250, 156);
            this.UsernameTB.MaxLength = 50;
            this.UsernameTB.Name = "UsernameTB";
            this.UsernameTB.Size = new System.Drawing.Size(254, 26);
            this.UsernameTB.TabIndex = 7;
            // 
            // PasswordLbl
            // 
            this.PasswordLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PasswordLbl.AutoSize = true;
            this.PasswordLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.PasswordLbl.Location = new System.Drawing.Point(246, 196);
            this.PasswordLbl.Name = "PasswordLbl";
            this.PasswordLbl.Size = new System.Drawing.Size(82, 20);
            this.PasswordLbl.TabIndex = 6;
            this.PasswordLbl.Text = "Password:";
            // 
            // UsernameLbl
            // 
            this.UsernameLbl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UsernameLbl.AutoSize = true;
            this.UsernameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.UsernameLbl.Location = new System.Drawing.Point(246, 133);
            this.UsernameLbl.Name = "UsernameLbl";
            this.UsernameLbl.Size = new System.Drawing.Size(87, 20);
            this.UsernameLbl.TabIndex = 5;
            this.UsernameLbl.Text = "Username:";
            // 
            // CreateAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 528);
            this.Controls.Add(this.CreateAccountBtn);
            this.Controls.Add(this.PasswordTB);
            this.Controls.Add(this.UsernameTB);
            this.Controls.Add(this.PasswordLbl);
            this.Controls.Add(this.UsernameLbl);
            this.Name = "CreateAccountForm";
            this.Text = "Create A New Account";
            this.Load += new System.EventHandler(this.CreateAccountForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateAccountBtn;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.TextBox UsernameTB;
        private System.Windows.Forms.Label PasswordLbl;
        private System.Windows.Forms.Label UsernameLbl;
    }
}