using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace NET__Custom_Controls.Email
{
    public partial class MailSender : Component
    {
        public MailSender()
        {
            InitializeComponent();
        }

        public MailSender(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region Server
        [Category("Server")]
        public string IPAddress { get; set; }

        [Category("Server")]
        public int Port { get; set; } = 25;

        [Category("Server")]
        public bool SSL { get; set; } = false;

        [Category("Server")]
        public bool SSLAlwaysSecure { get; set; } = false;
        #endregion

        #region Authentication
        [Category("Authentication")]
        public bool EnableAuthentication { get; set; } = true;

        [Category("Authentication")]
        public NET_Email_Sender.SMTP.AuthType AuthenticationType { get; set; } = NET_Email_Sender.SMTP.AuthType.Login;

        [Category("Authentication")]
        public string Username { get; set; }

        [PasswordPropertyText(true)]
        [Category("Authentication")]
        public string Password { get; set; }
        #endregion

        #region Email
        [Category("Email")]
        [Browsable(true)]
        public NET_Email_Sender.Attachment[] Attachments { get; set; }

        [Category("Email")]
        public string From { get; set; }

        [Category("Email")]
        [Browsable(true)]
        public string[] To { get; set; }

        [Category("Email")]
        [Browsable(true)]
        public string[] Cc { get; set; }

        [Category("Email")]
        [Browsable(true)]
        public string[] Bcc { get; set; }

        [Category("Email")]
        [Browsable(true)]
        public string ReplyTo { get; set; }

        [Category("Email")]
        [Browsable(true)]
        public string Subject { get; set; }
        
        [Category("Email")]
        [Browsable(true)]
        public string Body { get; set; }

        [Category("Email")]
        public bool UseHTML { get; set; } = true;
        #endregion

        [Category("Logs")]
        public bool SaveLogFile { get; set; } = true;
        [Category("Logs")]
        public string LogFilePath { get; set; } = @"C:\net_email_sender_log.txt";

        public bool Send()
        {
            NET_Email_Sender.SMTP smtp_server;
            NET_Email_Sender.Email email;

            var emailType = UseHTML ? NET_Email_Sender.Email.EmailContentType.HTML : NET_Email_Sender.Email.EmailContentType.Text;

            if (EnableAuthentication)
                smtp_server = new NET_Email_Sender.SMTP(IPAddress, Port, Username, Password, AuthenticationType, SSL, SSLAlwaysSecure);
            else
                smtp_server = new NET_Email_Sender.SMTP(IPAddress, Port, SSL, SSLAlwaysSecure);


            email = new NET_Email_Sender.Email(From, 
                To != null ? string.Join(";", To) : null,
                Cc != null ? string.Join(";", Cc) : null,
                Bcc != null ? string.Join(";", Bcc) : null, 
                ReplyTo, Subject, Body, emailType);

            if (Attachments != null && Attachments.Length > 0)
                email.AddAttachment(Attachments);

            var emailSent = smtp_server.SendEmail(email);

            if (SaveLogFile)
                smtp_server.SaveLogFile(LogFilePath);

            return emailSent;
        }
    }
}
