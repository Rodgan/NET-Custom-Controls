namespace NET__Custom_Controls.Panel
{
    partial class Panel
    {
        /// <summary> 
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione componenti

        /// <summary> 
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare 
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mailSender1 = new NET__Custom_Controls.Email.MailSender(this.components);
            this.SuspendLayout();
            // 
            // mailSender1
            // 
            this.mailSender1.Attachments = null;
            this.mailSender1.AuthenticationType = NET_Email_Sender.SMTP.AuthType.Login;
            this.mailSender1.EnableAuthentication = true;
            this.mailSender1.IPAddress = null;
            this.mailSender1.LogFilePath = "C:\\net_email_sender_log.txt";
            this.mailSender1.Password = null;
            this.mailSender1.Port = 0;
            this.mailSender1.SaveLogFile = true;
            this.mailSender1.SSL = false;
            this.mailSender1.SSLAlwaysSecure = false;
            this.mailSender1.Username = null;
            // 
            // Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Panel";
            this.Size = new System.Drawing.Size(46, 45);
            this.ResumeLayout(false);

        }

        #endregion

        private Email.MailSender mailSender1;
    }
}
