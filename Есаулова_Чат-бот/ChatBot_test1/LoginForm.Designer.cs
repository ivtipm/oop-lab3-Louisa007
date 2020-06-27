namespace ChatBot_test1
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
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonEnter = new System.Windows.Forms.Button();
            this.TextBoxLogin = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelAuthorization = new System.Windows.Forms.Label();
            this.labelRef = new System.Windows.Forms.Label();
            this.buttonRef = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.BackColor = System.Drawing.Color.Brown;
            this.buttonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonExit.Location = new System.Drawing.Point(298, 0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(35, 35);
            this.buttonExit.TabIndex = 0;
            this.buttonExit.Text = "X";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            this.buttonExit.MouseEnter += new System.EventHandler(this.buttonExit_MouseEnter);
            this.buttonExit.MouseLeave += new System.EventHandler(this.buttonExit_MouseLeave);
            // 
            // buttonEnter
            // 
            this.buttonEnter.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonEnter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonEnter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEnter.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEnter.ForeColor = System.Drawing.Color.Black;
            this.buttonEnter.Location = new System.Drawing.Point(34, 165);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(261, 35);
            this.buttonEnter.TabIndex = 6;
            this.buttonEnter.Text = "Войти";
            this.buttonEnter.UseVisualStyleBackColor = false;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            this.buttonEnter.MouseEnter += new System.EventHandler(this.buttonEnter_MouseEnter);
            this.buttonEnter.MouseLeave += new System.EventHandler(this.buttonEnter_MouseLeave);
            // 
            // TextBoxLogin
            // 
            this.TextBoxLogin.BackColor = System.Drawing.SystemColors.Window;
            this.TextBoxLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxLogin.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxLogin.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.TextBoxLogin.Location = new System.Drawing.Point(34, 130);
            this.TextBoxLogin.Name = "TextBoxLogin";
            this.TextBoxLogin.Size = new System.Drawing.Size(261, 29);
            this.TextBoxLogin.TabIndex = 5;
            this.TextBoxLogin.Text = "Логин";
            this.TextBoxLogin.Click += new System.EventHandler(this.TextBoxLogin_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Mistral", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.labelTitle.Location = new System.Drawing.Point(102, 14);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(128, 44);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "ЧАТ-БОТ";
            this.labelTitle.MouseEnter += new System.EventHandler(this.labelTitle_MouseEnter);
            this.labelTitle.MouseLeave += new System.EventHandler(this.labelTitle_MouseLeave);
            // 
            // labelAuthorization
            // 
            this.labelAuthorization.AutoSize = true;
            this.labelAuthorization.BackColor = System.Drawing.Color.Transparent;
            this.labelAuthorization.Font = new System.Drawing.Font("Forte", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthorization.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelAuthorization.Location = new System.Drawing.Point(95, 90);
            this.labelAuthorization.Name = "labelAuthorization";
            this.labelAuthorization.Size = new System.Drawing.Size(135, 26);
            this.labelAuthorization.TabIndex = 7;
            this.labelAuthorization.Text = "Авторизация";
            // 
            // labelRef
            // 
            this.labelRef.BackColor = System.Drawing.Color.Transparent;
            this.labelRef.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRef.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelRef.Location = new System.Drawing.Point(2, 58);
            this.labelRef.Name = "labelRef";
            this.labelRef.Size = new System.Drawing.Size(331, 26);
            this.labelRef.TabIndex = 8;
            this.labelRef.Text = "\"???\"";
            this.labelRef.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelRef.Visible = false;
            // 
            // buttonRef
            // 
            this.buttonRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRef.BackColor = System.Drawing.Color.DarkBlue;
            this.buttonRef.Cursor = System.Windows.Forms.Cursors.Help;
            this.buttonRef.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRef.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonRef.Location = new System.Drawing.Point(260, 89);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(35, 35);
            this.buttonRef.TabIndex = 9;
            this.buttonRef.Text = "?";
            this.buttonRef.UseVisualStyleBackColor = false;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            this.buttonRef.MouseEnter += new System.EventHandler(this.buttonRef_MouseEnter);
            this.buttonRef.MouseLeave += new System.EventHandler(this.buttonRef_MouseLeave);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.buttonEnter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(335, 213);
            this.ControlBox = false;
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.labelRef);
            this.Controls.Add(this.labelAuthorization);
            this.Controls.Add(this.buttonEnter);
            this.Controls.Add(this.TextBoxLogin);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonExit);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Чат-бот";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelAuthorization;
        private System.Windows.Forms.Label labelRef;
        private System.Windows.Forms.Button buttonRef;
        public System.Windows.Forms.TextBox TextBoxLogin;
    }
}

