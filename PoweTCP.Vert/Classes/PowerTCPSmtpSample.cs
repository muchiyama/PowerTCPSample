using System;
using System.Collections.Generic;
using System.Text;
using Dart.Mail;

namespace PoweTCP.Vert.Classes
{
    public class PowerTCPSmtpSample
    {
        public static PowerTCPSmtpSample CreateInsance() {
            return new PowerTCPSmtpSample();
        }

        //private Dart.PowerTCP.SecureMail.Smtp smtp = null;
        private MailMessage message = null;

        private PowerTCPSmtpSample() 
        { 
            Dart.Mail.License.Set(PoweTCP.Vert.Classes.Shared.LicenseKey.MAIL);
        }

        public void VertifyMethod()
        {
            using (var _smtp = new Dart.Mail.Smtp())
            using (var _message = new Dart.Mail.MailMessage())
            {
                // IPEndPointのコンストラクタ引数 -> ドメイン名, port番号
                _smtp.Session.RemoteEndPoint = new Dart.Mail.IPEndPoint("domein", 25);
                _smtp.Session.Username = "param";
                _smtp.Session.Password = "param";

                _message.From = "param";
                _message.Subject = "param";
                _message.Text = "param";
                _message.To = "param";

                _smtp.Send(_message);
            }

        }

        public void Send()
        {
            (var fromMailDto, var toMailDto) = CreateMockDtos();

            using (var smtp = new Dart.Mail.Smtp())
            {
                message = new Dart.Mail.MailMessage();

                SetFromByMailDto(fromMailDto);
                SetToByMailDto(toMailDto);

                smtp.Session.RemoteEndPoint = CreateIPEndopointByToMailDto(toMailDto, smtp);
                SetUserNameAndPassToSession(smtp);

                smtp.Connect();
                smtp.Send(message);

                smtp.Close();
            }
        }

        private (FromMailDto, ToMailDto) CreateMockDtos()
        {
            return (new FromMailDto(), new ToMailDto());
        }

        private Dart.Mail.Smtp SetUserNameAndPassToSession(Dart.Mail.Smtp smtp)
        {
            smtp.Session.Username = MyMailSetver.UserName();
            smtp.Session.Password = MyMailSetver.Password();
            return smtp;
        }

        private Dart.Mail.IPEndPoint CreateIPEndopointByToMailDto(ToMailDto dto, Dart.Mail.Smtp smtp)
        {
            return new Dart.Mail.IPEndPoint(System.Net.Dns.GetHostName().Equals("W1003848N182") ? "localhost" : "host.docker.internal", 587);
        }

        private FromMailDto SetFromByMailDto(FromMailDto dto)
        {
            message.From = dto.From();
            message.Subject = dto.Subject();
            message.Text = dto.Text();

            return dto;
        }

        private ToMailDto SetToByMailDto(ToMailDto dto)
        {
            message.To = dto.To();
            return dto;
        }
    }

    public class FromMailDto
    {
        public string From() { return "powerTCP@jbs.com"; }
        public string Subject() { return "TestMail"; }
        public string Text() { return "TestText"; }
    }


    public class ToMailDto
    {
        private static System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient();
        public string To() { return "masatomo.uchiyama@jbs.com"; }
        public string Host() { return "localhost"; }
        public int Port() { return smtpClient.Port; }

    }

    public class MyMailSetver
    {
        public static string UserName() { return "admin@jbs.com"; }
        public static string Password() { return "p@ss1234"; }
    }
}
