namespace MulticastChat
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtChat = new MetroFramework.Controls.MetroTextBox();
            this.txtMessage = new MetroFramework.Controls.MetroTextBox();
            this.btnSend = new MetroFramework.Controls.MetroButton();
            this.lstUsers = new MetroFramework.Controls.MetroComboBox();
            this.label1 = new MetroFramework.Controls.MetroLabel();
            this.label2 = new MetroFramework.Controls.MetroLabel();
            this.label3 = new MetroFramework.Controls.MetroLabel();
            this.timerHeartbeat = new System.Windows.Forms.Timer(this.components);
            this.btnSetChatColor = new MetroFramework.Controls.MetroButton();
            this.btnSetFontColor = new MetroFramework.Controls.MetroButton();
            this.btnSetFontSize = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // txtChat
            // 
            this.txtChat.BackColor = System.Drawing.SystemColors.InactiveBorder;
            // 
            // 
            // 
            this.txtChat.CustomButton.Image = null;
            this.txtChat.CustomButton.Location = new System.Drawing.Point(171, 2);
            this.txtChat.CustomButton.Name = "";
            this.txtChat.CustomButton.Size = new System.Drawing.Size(181, 181);
            this.txtChat.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtChat.CustomButton.TabIndex = 1;
            this.txtChat.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtChat.CustomButton.UseSelectable = true;
            this.txtChat.CustomButton.Visible = false;
            this.txtChat.ForeColor = System.Drawing.Color.Lime;
            this.txtChat.Lines = new string[0];
            this.txtChat.Location = new System.Drawing.Point(23, 29);
            this.txtChat.MaxLength = 32767;
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.PasswordChar = '\0';
            this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtChat.SelectedText = "";
            this.txtChat.SelectionLength = 0;
            this.txtChat.SelectionStart = 0;
            this.txtChat.ShortcutsEnabled = true;
            this.txtChat.Size = new System.Drawing.Size(355, 186);
            this.txtChat.TabIndex = 0;
            this.txtChat.UseSelectable = true;
            this.txtChat.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtChat.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.SystemColors.InactiveBorder;
            // 
            // 
            // 
            this.txtMessage.CustomButton.Image = null;
            this.txtMessage.CustomButton.Location = new System.Drawing.Point(309, 2);
            this.txtMessage.CustomButton.Name = "";
            this.txtMessage.CustomButton.Size = new System.Drawing.Size(43, 43);
            this.txtMessage.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtMessage.CustomButton.TabIndex = 1;
            this.txtMessage.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtMessage.CustomButton.UseSelectable = true;
            this.txtMessage.CustomButton.Visible = false;
            this.txtMessage.Lines = new string[0];
            this.txtMessage.Location = new System.Drawing.Point(27, 258);
            this.txtMessage.MaxLength = 32767;
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.PasswordChar = '\0';
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtMessage.SelectedText = "";
            this.txtMessage.SelectionLength = 0;
            this.txtMessage.SelectionStart = 0;
            this.txtMessage.ShortcutsEnabled = true;
            this.txtMessage.Size = new System.Drawing.Size(355, 48);
            this.txtMessage.TabIndex = 1;
            this.txtMessage.UseSelectable = true;
            this.txtMessage.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtMessage.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.txtMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessage_KeyPress);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(83, 338);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(240, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "SEND";
            this.btnSend.UseSelectable = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lstUsers
            // 
            this.lstUsers.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 23;
            this.lstUsers.Location = new System.Drawing.Point(411, 32);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(293, 29);
            this.lstUsers.TabIndex = 3;
            this.lstUsers.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "CHAT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "MESSAGE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(445, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "ACTIVE USERS";
            // 
            // timerHeartbeat
            // 
            this.timerHeartbeat.Tick += new System.EventHandler(this.timerHeartbeat_Tick);
            // 
            // btnSetChatColor
            // 
            this.btnSetChatColor.Location = new System.Drawing.Point(499, 231);
            this.btnSetChatColor.Name = "btnSetChatColor";
            this.btnSetChatColor.Size = new System.Drawing.Size(134, 23);
            this.btnSetChatColor.TabIndex = 7;
            this.btnSetChatColor.Text = "SET CHAT COLOR";
            this.btnSetChatColor.UseSelectable = true;
            this.btnSetChatColor.Click += new System.EventHandler(this.btnSetChatColor_Click);
            // 
            // btnSetFontColor
            // 
            this.btnSetFontColor.Location = new System.Drawing.Point(499, 272);
            this.btnSetFontColor.Name = "btnSetFontColor";
            this.btnSetFontColor.Size = new System.Drawing.Size(134, 23);
            this.btnSetFontColor.TabIndex = 7;
            this.btnSetFontColor.Text = "SET FONT COLOR";
            this.btnSetFontColor.UseSelectable = true;
            this.btnSetFontColor.Click += new System.EventHandler(this.btnSetFontColor_Click);
            // 
            // btnSetFontSize
            // 
            this.btnSetFontSize.Location = new System.Drawing.Point(499, 314);
            this.btnSetFontSize.Name = "btnSetFontSize";
            this.btnSetFontSize.Size = new System.Drawing.Size(134, 23);
            this.btnSetFontSize.TabIndex = 7;
            this.btnSetFontSize.Text = "SET FONT SIZE";
            this.btnSetFontSize.UseSelectable = true;
            this.btnSetFontSize.Click += new System.EventHandler(this.btnSetFontSize_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 427);
            this.Controls.Add(this.btnSetFontSize);
            this.Controls.Add(this.btnSetFontColor);
            this.Controls.Add(this.btnSetChatColor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstUsers);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtChat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(747, 427);
            this.MinimumSize = new System.Drawing.Size(426, 427);
            this.Name = "Form1";
            this.Text = "LOCAL CHAT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtChat;
        private MetroFramework.Controls.MetroTextBox txtMessage;
        private MetroFramework.Controls.MetroButton btnSend;
        private MetroFramework.Controls.MetroComboBox lstUsers;
        private MetroFramework.Controls.MetroLabel label1;
        private MetroFramework.Controls.MetroLabel label2;
        private MetroFramework.Controls.MetroLabel label3;
        private System.Windows.Forms.Timer timerHeartbeat;
        private MetroFramework.Controls.MetroButton btnSetChatColor;
        private MetroFramework.Controls.MetroButton btnSetFontColor;
        private MetroFramework.Controls.MetroButton btnSetFontSize;
    }
}

