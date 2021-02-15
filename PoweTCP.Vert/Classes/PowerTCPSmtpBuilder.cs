using System;
using System.Collections.Generic;
using System.Text;

namespace PoweTCP.Vert.Classes
{
    public class PowerTCPSmtpBuilder
    {
        private Dart.Mail.Smtp smtp = new Dart.Mail.Smtp();
        private PowerTCPSmtpBuilder() => Dart.Mail.License.Set(PoweTCP.Vert.Classes.Shared.LicenseKey.MAIL);
        public static PowerTCPSmtpBuilder Create() => new PowerTCPSmtpBuilder();

        public static PowerTCPSmtpBuilder CreateDefault()
            => new PowerTCPSmtpBuilder().AddHostAndPort()
                                        .AddUserName()
                                        .AddPassword();


        public PowerTCPSmtpBuilder AddHostAndPort(string host = "smtp.mailtrap.io", int port = 587)
        {
            smtp.Session.RemoteEndPoint = new Dart.Mail.IPEndPoint(host, port);
            return this;
        }
        public PowerTCPSmtpBuilder AddUserName(string userName = "3e5973ff153fe1")
        {
            smtp.Session.Username = userName;
            return this;
        }
        public PowerTCPSmtpBuilder AddPassword(string password = "21e4a64936b4e1")
        {
            smtp.Session.Password = password;
            return this;
        }

        public Dart.Mail.Smtp Build()
        {
            return smtp;
        }
    }

    public class PowerTCPMessageBuilder
    {
        private Dart.Mail.MailMessage message = new Dart.Mail.MailMessage();
        private PowerTCPMessageBuilder() => Dart.Mail.License.Set(PoweTCP.Vert.Classes.Shared.LicenseKey.MAIL);

        public static PowerTCPMessageBuilder Create() => new PowerTCPMessageBuilder();
        public static PowerTCPMessageBuilder CreateDefault()
            => new PowerTCPMessageBuilder().AddFrom()
                                           .AddFrom()
                                           .AddTo()
                                           .AddCc()
                                           .AddBcc();

        public PowerTCPMessageBuilder AddSubjectAndText(string subject = "subject", string text = "text\r\ntext\r\ntext") 
        {
            message.Subject = subject;
            message.Text = text;
            return this;
        }

        public PowerTCPMessageBuilder AddFrom(string from = "sample@from.com")
        {
            message.From = from;
            return this;
        }

        public PowerTCPMessageBuilder AddTo(List<string> to = null) 
        {
            if (to is null || to.Count.Equals(0)) to = new List<string> { "to1_dummy@dummy.com", "to2_dummy@dummy.com", "to3_dummy@dummy.com" };
            message.To = string.Join(",", to);
            return this;
        }

        public PowerTCPMessageBuilder AddCc(List<string> cc = null)
        {
            if (cc is null || cc.Count.Equals(0)) cc = new List<string> { "cc1_dummy@dummy.com", "cc2_dummy@dummy.com", "cc3_dummy@dummy.com" };
            message.To = string.Join(",", cc);
            return this;
        }
        public PowerTCPMessageBuilder AddBcc(List<string> bcc = null)
        {
            if (bcc is null || bcc.Count.Equals(0)) bcc = new List<string> { "bcc1_dummy@dummy.com", "bcc2_dummy@dummy.com", "bcc3_dummy@dummy.com" };
            message.To = string.Join(",", bcc);
            return this;
        }

        public Dart.Mail.MailMessage Build() 
        {
            return message;
        }
    }
}
