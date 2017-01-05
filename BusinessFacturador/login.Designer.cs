namespace HostelSystem
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.BtnSession = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TxtPassword
            // 
            this.TxtPassword.BackColor = System.Drawing.Color.White;
            this.TxtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtPassword.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPassword.ForeColor = System.Drawing.Color.DimGray;
            this.TxtPassword.Location = new System.Drawing.Point(109, 220);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(182, 28);
            this.TxtPassword.TabIndex = 5;
            this.TxtPassword.Text = "******";
            this.TxtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtPassword.Enter += new System.EventHandler(this.TxtPassword_Enter);
            this.TxtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPassword_KeyPress);
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.BackColor = System.Drawing.Color.White;
            this.TxtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtUsuario.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUsuario.ForeColor = System.Drawing.Color.DimGray;
            this.TxtUsuario.Location = new System.Drawing.Point(110, 182);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(182, 28);
            this.TxtUsuario.TabIndex = 4;
            this.TxtUsuario.Text = "usuario";
            this.TxtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtUsuario.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TxtUsuario_MouseClick);
            this.TxtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtUsuario_KeyPress);
            // 
            // BtnSession
            // 
            this.BtnSession.BackColor = System.Drawing.SystemColors.Control;
            this.BtnSession.ForeColor = System.Drawing.Color.White;
            this.BtnSession.Location = new System.Drawing.Point(98, 258);
            this.BtnSession.Name = "BtnSession";
            this.BtnSession.Size = new System.Drawing.Size(207, 42);
            this.BtnSession.TabIndex = 6;
            this.BtnSession.Text = "&Entrar";
            this.BtnSession.UseVisualStyleBackColor = false;
            this.BtnSession.Click += new System.EventHandler(this.BtnSession_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.IndianRed;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 21);
            this.button1.TabIndex = 7;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::HostelSystem.Properties.Resources.login3;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(400, 326);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.TxtUsuario);
            this.Controls.Add(this.BtnSession);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "login";
            this.Text = "login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.Button BtnSession;
        private System.Windows.Forms.Button button1;
    }
}