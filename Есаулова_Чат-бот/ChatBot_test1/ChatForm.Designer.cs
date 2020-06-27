namespace ChatBot_test1
{
    partial class ChatForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatForm));
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.TextBoxChat = new System.Windows.Forms.TextBox();
            this.TextBoxSendMsg = new System.Windows.Forms.TextBox();
            this.buttonSendMsg = new System.Windows.Forms.Button();
            this.labelRef = new System.Windows.Forms.Label();
            this.buttonUserLogout = new System.Windows.Forms.Button();
            this.lblCurrentUserLogin = new System.Windows.Forms.Label();
            this.buttonRef = new System.Windows.Forms.Button();
            this.buttonClearAll = new System.Windows.Forms.Button();
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
            this.buttonExit.Location = new System.Drawing.Point(537, 0);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(35, 35);
            this.buttonExit.TabIndex = 1;
            this.buttonExit.Text = "X";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            this.buttonExit.MouseEnter += new System.EventHandler(this.buttonExit_MouseEnter);
            this.buttonExit.MouseLeave += new System.EventHandler(this.buttonExit_MouseLeave);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Mistral", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.labelTitle.Location = new System.Drawing.Point(228, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(128, 44);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "ЧАТ-БОТ";
            this.labelTitle.MouseEnter += new System.EventHandler(this.labelTitle_MouseEnter);
            this.labelTitle.MouseLeave += new System.EventHandler(this.labelTitle_MouseLeave);
            // 
            // TextBoxChat
            // 
            this.TextBoxChat.BackColor = System.Drawing.SystemColors.Window;
            this.TextBoxChat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxChat.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxChat.ForeColor = System.Drawing.Color.Black;
            this.TextBoxChat.Location = new System.Drawing.Point(12, 79);
            this.TextBoxChat.Multiline = true;
            this.TextBoxChat.Name = "TextBoxChat";
            this.TextBoxChat.ReadOnly = true;
            this.TextBoxChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxChat.Size = new System.Drawing.Size(547, 221);
            this.TextBoxChat.TabIndex = 6;
            // 
            // TextBoxSendMsg
            // 
            this.TextBoxSendMsg.BackColor = System.Drawing.SystemColors.Window;
            this.TextBoxSendMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextBoxSendMsg.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxSendMsg.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.TextBoxSendMsg.Location = new System.Drawing.Point(12, 306);
            this.TextBoxSendMsg.Multiline = true;
            this.TextBoxSendMsg.Name = "TextBoxSendMsg";
            this.TextBoxSendMsg.Size = new System.Drawing.Size(506, 90);
            this.TextBoxSendMsg.TabIndex = 7;
            this.TextBoxSendMsg.Text = "Напишите сообщение...";
            this.TextBoxSendMsg.Click += new System.EventHandler(this.TextBoxSendMsg_Click);
            this.TextBoxSendMsg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxSendMsg_KeyPress);
            this.TextBoxSendMsg.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TextBoxSendMsg_KeyUp);
            // 
            // buttonSendMsg
            // 
            this.buttonSendMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSendMsg.BackColor = System.Drawing.Color.PaleTurquoise;
            this.buttonSendMsg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSendMsg.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonSendMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSendMsg.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.buttonSendMsg.Location = new System.Drawing.Point(524, 306);
            this.buttonSendMsg.Name = "buttonSendMsg";
            this.buttonSendMsg.Size = new System.Drawing.Size(35, 50);
            this.buttonSendMsg.TabIndex = 8;
            this.buttonSendMsg.Text = ">";
            this.buttonSendMsg.UseVisualStyleBackColor = false;
            this.buttonSendMsg.Click += new System.EventHandler(this.buttonSendMsg_Click);
            this.buttonSendMsg.MouseEnter += new System.EventHandler(this.buttonSendMsg_MouseEnter);
            this.buttonSendMsg.MouseLeave += new System.EventHandler(this.buttonSendMsg_MouseLeave);
            // 
            // labelRef
            // 
            this.labelRef.BackColor = System.Drawing.Color.Transparent;
            this.labelRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelRef.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRef.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.labelRef.Location = new System.Drawing.Point(12, 44);
            this.labelRef.Name = "labelRef";
            this.labelRef.Size = new System.Drawing.Size(547, 26);
            this.labelRef.TabIndex = 9;
            this.labelRef.Text = "...";
            this.labelRef.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonUserLogout
            // 
            this.buttonUserLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUserLogout.BackColor = System.Drawing.Color.Teal;
            this.buttonUserLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUserLogout.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonUserLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUserLogout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonUserLogout.Location = new System.Drawing.Point(150, 0);
            this.buttonUserLogout.Name = "buttonUserLogout";
            this.buttonUserLogout.Size = new System.Drawing.Size(54, 35);
            this.buttonUserLogout.TabIndex = 11;
            this.buttonUserLogout.Text = "выйти";
            this.buttonUserLogout.UseVisualStyleBackColor = false;
            this.buttonUserLogout.Click += new System.EventHandler(this.buttonUserLogout_Click);
            this.buttonUserLogout.MouseEnter += new System.EventHandler(this.buttonUserLogout_MouseEnter);
            this.buttonUserLogout.MouseLeave += new System.EventHandler(this.buttonUserLogout_MouseLeave);
            // 
            // lblCurrentUserLogin
            // 
            this.lblCurrentUserLogin.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentUserLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblCurrentUserLogin.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurrentUserLogin.ForeColor = System.Drawing.Color.DarkCyan;
            this.lblCurrentUserLogin.Location = new System.Drawing.Point(12, 0);
            this.lblCurrentUserLogin.Name = "lblCurrentUserLogin";
            this.lblCurrentUserLogin.Size = new System.Drawing.Size(144, 35);
            this.lblCurrentUserLogin.TabIndex = 12;
            this.lblCurrentUserLogin.Text = "Пользователь";
            this.lblCurrentUserLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonRef
            // 
            this.buttonRef.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRef.BackColor = System.Drawing.Color.DarkBlue;
            this.buttonRef.Cursor = System.Windows.Forms.Cursors.Help;
            this.buttonRef.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonRef.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRef.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonRef.Location = new System.Drawing.Point(496, 0);
            this.buttonRef.Name = "buttonRef";
            this.buttonRef.Size = new System.Drawing.Size(35, 35);
            this.buttonRef.TabIndex = 13;
            this.buttonRef.Text = "?";
            this.buttonRef.UseVisualStyleBackColor = false;
            this.buttonRef.Click += new System.EventHandler(this.buttonRef_Click);
            this.buttonRef.MouseEnter += new System.EventHandler(this.buttonRef_MouseEnter);
            this.buttonRef.MouseLeave += new System.EventHandler(this.buttonRef_MouseLeave);
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClearAll.BackColor = System.Drawing.Color.Teal;
            this.buttonClearAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClearAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonClearAll.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonClearAll.Location = new System.Drawing.Point(524, 362);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(35, 34);
            this.buttonClearAll.TabIndex = 14;
            this.buttonClearAll.Text = "CA";
            this.buttonClearAll.UseVisualStyleBackColor = false;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            this.buttonClearAll.MouseEnter += new System.EventHandler(this.buttonClearAll_MouseEnter);
            this.buttonClearAll.MouseLeave += new System.EventHandler(this.buttonClearAll_MouseLeave);
            // 
            // ChatForm
            // 
            this.AcceptButton = this.buttonSendMsg;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(571, 408);
            this.ControlBox = false;
            this.Controls.Add(this.buttonClearAll);
            this.Controls.Add(this.buttonRef);
            this.Controls.Add(this.lblCurrentUserLogin);
            this.Controls.Add(this.buttonUserLogout);
            this.Controls.Add(this.labelRef);
            this.Controls.Add(this.buttonSendMsg);
            this.Controls.Add(this.TextBoxSendMsg);
            this.Controls.Add(this.TextBoxChat);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.buttonExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChatForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Чат-бот";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox TextBoxChat;
        private System.Windows.Forms.TextBox TextBoxSendMsg;
        private System.Windows.Forms.Button buttonSendMsg;
        private System.Windows.Forms.Label labelRef;
        private System.Windows.Forms.Button buttonUserLogout;
        public System.Windows.Forms.Label lblCurrentUserLogin;
        private System.Windows.Forms.Button buttonRef;
        private System.Windows.Forms.Button buttonClearAll;
    }
}