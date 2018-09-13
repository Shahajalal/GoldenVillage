namespace Golden_Village
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.username = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.password = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.jFlatButton1 = new FlatButton.JFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.loginbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(76, 420);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(49, 39);
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(76, 371);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 39);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(100, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(258, 264);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // username
            // 
            this.username.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.username.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.username.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.username.HintText = "Username";
            this.username.isPassword = false;
            this.username.LineFocusedColor = System.Drawing.Color.DodgerBlue;
            this.username.LineIdleColor = System.Drawing.Color.Gray;
            this.username.LineMouseHoverColor = System.Drawing.Color.DodgerBlue;
            this.username.LineThickness = 3;
            this.username.Location = new System.Drawing.Point(132, 371);
            this.username.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(226, 39);
            this.username.TabIndex = 11;
            this.username.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.username.OnValueChanged += new System.EventHandler(this.username_OnValueChanged);
            this.username.KeyDown += new System.Windows.Forms.KeyEventHandler(this.username_KeyDown);
            // 
            // password
            // 
            this.password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.password.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.password.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.password.HintText = "Password";
            this.password.isPassword = true;
            this.password.LineFocusedColor = System.Drawing.Color.DeepSkyBlue;
            this.password.LineIdleColor = System.Drawing.Color.Gray;
            this.password.LineMouseHoverColor = System.Drawing.Color.DeepSkyBlue;
            this.password.LineThickness = 3;
            this.password.Location = new System.Drawing.Point(132, 420);
            this.password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.password.Name = "password";
            this.password.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.password.Size = new System.Drawing.Size(226, 39);
            this.password.TabIndex = 12;
            this.password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.password.OnValueChanged += new System.EventHandler(this.password_OnValueChanged);
            this.password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.password_KeyDown);
            // 
            // jFlatButton1
            // 
            this.jFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.jFlatButton1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.jFlatButton1.ButtonText = "X";
            this.jFlatButton1.CausesValidation = false;
            this.jFlatButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.jFlatButton1.ErrorImageLeft = ((System.Drawing.Image)(resources.GetObject("jFlatButton1.ErrorImageLeft")));
            this.jFlatButton1.ErrorImageRight = ((System.Drawing.Image)(resources.GetObject("jFlatButton1.ErrorImageRight")));
            this.jFlatButton1.FocusBackground = System.Drawing.Color.Empty;
            this.jFlatButton1.FocusFontColor = System.Drawing.Color.Empty;
            this.jFlatButton1.ForeColors = System.Drawing.Color.DeepSkyBlue;
            this.jFlatButton1.HoverBackground = System.Drawing.Color.Empty;
            this.jFlatButton1.HoverFontColor = System.Drawing.Color.Empty;
            this.jFlatButton1.ImageLeft = null;
            this.jFlatButton1.ImageRight = null;
            this.jFlatButton1.LeftPictureColor = System.Drawing.Color.Transparent;
            this.jFlatButton1.Location = new System.Drawing.Point(413, -1);
            this.jFlatButton1.Name = "jFlatButton1";
            this.jFlatButton1.PaddingLeftPicture = new System.Windows.Forms.Padding(0);
            this.jFlatButton1.PaddingRightPicture = new System.Windows.Forms.Padding(0);
            this.jFlatButton1.RightPictureColor = System.Drawing.Color.Transparent;
            this.jFlatButton1.Size = new System.Drawing.Size(33, 32);
            this.jFlatButton1.SizeModeLeft = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.jFlatButton1.SizeModeRight = System.Windows.Forms.PictureBoxSizeMode.Normal;
            this.jFlatButton1.TabIndex = 14;
            this.jFlatButton1.Click += new System.EventHandler(this.jFlatButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(112, 298);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 40);
            this.label1.TabIndex = 15;
            this.label1.Text = "Golden Village";
            // 
            // loginbtn
            // 
            this.loginbtn.FlatAppearance.BorderSize = 0;
            this.loginbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginbtn.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginbtn.ForeColor = System.Drawing.Color.White;
            this.loginbtn.Location = new System.Drawing.Point(142, 478);
            this.loginbtn.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.loginbtn.Name = "loginbtn";
            this.loginbtn.Size = new System.Drawing.Size(173, 54);
            this.loginbtn.TabIndex = 16;
            this.loginbtn.Text = "Login";
            this.loginbtn.UseVisualStyleBackColor = true;
            this.loginbtn.Click += new System.EventHandler(this.loginbtn_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(25)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(447, 557);
            this.Controls.Add(this.loginbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.jFlatButton1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Bunifu.Framework.UI.BunifuMaterialTextbox username;
        private Bunifu.Framework.UI.BunifuMaterialTextbox password;
        private FlatButton.JFlatButton login;
        private FlatButton.JFlatButton jFlatButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button loginbtn;
    }
}

