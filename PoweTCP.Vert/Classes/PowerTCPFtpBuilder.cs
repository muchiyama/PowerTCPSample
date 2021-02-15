using System;
using System.Collections.Generic;
using System.Text;

namespace PoweTCP.Vert.Classes
{
    public class PowerTCPFtpBuilder
    {
        private Dart.Ftp.Ftp ftp = new Dart.Ftp.Ftp();
        private PowerTCPFtpBuilder() => Dart.Ftp.License.Set(PoweTCP.Vert.Classes.Shared.LicenseKey.FTP);
        public static PowerTCPFtpBuilder Create() => new PowerTCPFtpBuilder();

        public static PowerTCPFtpBuilder CreateDefault()
            => new PowerTCPFtpBuilder().AddHostAndPort()
                                       .AddUserName()
                                       .AddPassword();

        public PowerTCPFtpBuilder AddHostAndPort(string host = null, int port = 21)
        {
            if (host is null)
                ftp.Session.RemoteEndPoint = new Dart.Ftp.IPEndPoint("ftpserver", 21);
            else
                ftp.Session.RemoteEndPoint = new Dart.Ftp.IPEndPoint(host, port);
            return this;
        }

        public PowerTCPFtpBuilder AddUserName(string userName = "admin")
        {
            ftp.Session.Username = userName;
            return this;
        }

        public PowerTCPFtpBuilder AddPassword(string password = "p@ss")
        {
            ftp.Session.Password = password;
            return this;
        }

        public Dart.Ftp.Ftp Build()
        {
            return ftp;
        }
    }
}
