namespace AzureOpenAIWinForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSendMsg = new System.Windows.Forms.Button();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.txtRichChat = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnSendMsg
            // 
            this.btnSendMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSendMsg.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnSendMsg.Location = new System.Drawing.Point(713, 415);
            this.btnSendMsg.Name = "btnSendMsg";
            this.btnSendMsg.Size = new System.Drawing.Size(75, 23);
            this.btnSendMsg.TabIndex = 0;
            this.btnSendMsg.Text = "发送";
            this.btnSendMsg.UseVisualStyleBackColor = true;
            this.btnSendMsg.Click += new System.EventHandler(this.btnSendMsg_Click);
            // 
            // txtMsg
            // 
            this.txtMsg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsg.Location = new System.Drawing.Point(12, 415);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(695, 23);
            this.txtMsg.TabIndex = 1;
            // 
            // txtRichChat
            // 
            this.txtRichChat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRichChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRichChat.Font = new System.Drawing.Font("Microsoft YaHei UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRichChat.HideSelection = false;
            this.txtRichChat.Location = new System.Drawing.Point(12, 12);
            this.txtRichChat.Name = "txtRichChat";
            this.txtRichChat.ReadOnly = true;
            this.txtRichChat.Size = new System.Drawing.Size(776, 397);
            this.txtRichChat.TabIndex = 2;
            this.txtRichChat.Text = "";
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSendMsg;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtRichChat);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.btnSendMsg);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AI聊天机器人";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnSendMsg;
        private TextBox txtMsg;
        private RichTextBox txtRichChat;
    }
}