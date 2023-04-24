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
            this.txtChat = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timerHeartbeat = new System.Windows.Forms.Timer(this.components);
            this.btnSetChatColor = new System.Windows.Forms.Button();
            this.btnSetFontColor = new System.Windows.Forms.Button();
            this.btnSetFontSize = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtChat
            // 
            this.txtChat.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtChat.ForeColor = System.Drawing.Color.Lime;
            this.txtChat.Location = new System.Drawing.Point(35, 27);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.Size = new System.Drawing.Size(355, 186);
            this.txtChat.TabIndex = 0;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtMessage.Location = new System.Drawing.Point(35, 258);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(355, 48);
            this.txtMessage.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(89, 338);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(240, 23);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "SEND";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lstUsers
            // 
            this.lstUsers.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.Location = new System.Drawing.Point(411, 27);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(293, 186);
            this.lstUsers.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(173, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "CHAT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "MESSAGE";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(445, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
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
            this.btnSetChatColor.UseVisualStyleBackColor = true;
            this.btnSetChatColor.Click += new System.EventHandler(this.btnSetChatColor_Click);
            // 
            // btnSetFontColor
            // 
            this.btnSetFontColor.Location = new System.Drawing.Point(499, 272);
            this.btnSetFontColor.Name = "btnSetFontColor";
            this.btnSetFontColor.Size = new System.Drawing.Size(134, 23);
            this.btnSetFontColor.TabIndex = 7;
            this.btnSetFontColor.Text = "SET FONT COLOR";
            this.btnSetFontColor.UseVisualStyleBackColor = true;
            this.btnSetFontColor.Click += new System.EventHandler(this.btnSetFontColor_Click);
            // 
            // btnSetFontSize
            // 
            this.btnSetFontSize.Location = new System.Drawing.Point(499, 314);
            this.btnSetFontSize.Name = "btnSetFontSize";
            this.btnSetFontSize.Size = new System.Drawing.Size(134, 23);
            this.btnSetFontSize.TabIndex = 7;
            this.btnSetFontSize.Text = "SET FONT SIZE";
            this.btnSetFontSize.UseVisualStyleBackColor = true;
            this.btnSetFontSize.Click += new System.EventHandler(this.btnSetFontSize_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(731, 389);
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
            this.Name = "Form1";
            this.Text = "LOCAL CHAT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerHeartbeat;
        private System.Windows.Forms.Button btnSetChatColor;
        private System.Windows.Forms.Button btnSetFontColor;
        private System.Windows.Forms.Button btnSetFontSize;
    }
}

