namespace project
{
    partial class LoginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.logtext = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.passtext = new MetroFramework.Controls.MetroTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // logtext
            // 
            // 
            // 
            // 
            this.logtext.CustomButton.Image = null;
            this.logtext.CustomButton.Location = new System.Drawing.Point(92, 2);
            this.logtext.CustomButton.Name = "";
            this.logtext.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.logtext.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.logtext.CustomButton.TabIndex = 1;
            this.logtext.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.logtext.CustomButton.UseSelectable = true;
            this.logtext.CustomButton.Visible = false;
            this.logtext.Lines = new string[0];
            this.logtext.Location = new System.Drawing.Point(118, 96);
            this.logtext.MaxLength = 32767;
            this.logtext.Name = "logtext";
            this.logtext.PasswordChar = '\0';
            this.logtext.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.logtext.SelectedText = "";
            this.logtext.SelectionLength = 0;
            this.logtext.SelectionStart = 0;
            this.logtext.ShortcutsEnabled = true;
            this.logtext.Size = new System.Drawing.Size(120, 30);
            this.logtext.TabIndex = 0;
            this.logtext.UseSelectable = true;
            this.logtext.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.logtext.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.logtext.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.logtext_KeyPress);
            // 
            // metroButton1
            // 
            this.metroButton1.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.metroButton1.FontWeight = MetroFramework.MetroButtonWeight.Light;
            this.metroButton1.Location = new System.Drawing.Point(127, 244);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(99, 46);
            this.metroButton1.TabIndex = 1;
            this.metroButton1.Text = "Вход";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(52, 96);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(60, 25);
            this.metroLabel1.TabIndex = 2;
            this.metroLabel1.Text = "Логин";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(42, 177);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(70, 25);
            this.metroLabel2.TabIndex = 3;
            this.metroLabel2.Text = "Пароль";
            // 
            // passtext
            // 
            // 
            // 
            // 
            this.passtext.CustomButton.Image = null;
            this.passtext.CustomButton.Location = new System.Drawing.Point(92, 2);
            this.passtext.CustomButton.Name = "";
            this.passtext.CustomButton.Size = new System.Drawing.Size(25, 25);
            this.passtext.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.passtext.CustomButton.TabIndex = 1;
            this.passtext.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.passtext.CustomButton.UseSelectable = true;
            this.passtext.CustomButton.Visible = false;
            this.passtext.Lines = new string[0];
            this.passtext.Location = new System.Drawing.Point(118, 177);
            this.passtext.MaxLength = 32767;
            this.passtext.Name = "passtext";
            this.passtext.PasswordChar = '*';
            this.passtext.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.passtext.SelectedText = "";
            this.passtext.SelectionLength = 0;
            this.passtext.SelectionStart = 0;
            this.passtext.ShortcutsEnabled = true;
            this.passtext.Size = new System.Drawing.Size(120, 30);
            this.passtext.TabIndex = 4;
            this.passtext.UseSelectable = true;
            this.passtext.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.passtext.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.passtext.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passtext_KeyPress);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(244, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(244, 177);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 319);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.passtext);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.logtext);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Text = "Авторизация";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox logtext;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox passtext;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

