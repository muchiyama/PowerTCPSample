using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PoweTCP.Vert.Classes
{
    public class PowerTCPFtpSample
    {
        public static PowerTCPFtpSample Create() => new PowerTCPFtpSample();
        private PowerTCPFtpSample() => Dart.Ftp.License.Set(PoweTCP.Vert.Classes.Shared.LicenseKey.FTP);

        public void Put()
        {
            using (var ftp = PowerTCPFtpBuilder.CreateDefault().Build())
            {
                //ftp.Session.ConnectType = Dart.Ftp.DataConnectType.Port; // successed
                //ftp.Session.ConnectType = Dart.Ftp.DataConnectType.PassiveOverrideAddress; // successed
                //ftp.Session.ConnectType = Dart.Ftp.DataConnectType.Passive; // failed ※default

                var resposne = ftp.Connect();
                var responsies = ftp.Authenticate();

                var response = ftp.Put(MockAttachmentCreator.CreateSingleTextFile(), $"file_{DateTime.Now.ToString("HHmmss")}", Dart.Ftp.Synchronize.Off); // Put SIngle File
                System.Diagnostics.Debug.WriteLine(response.Status);
            }
        }
        public void Get()
        {
            using (var ftp = PowerTCPFtpBuilder.CreateDefault().Build())
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                ftp.Encoding = Encoding.GetEncoding("Shift_JIS");

                ftp.Connect();
                ftp.Authenticate();

                ftp.SetDirectory("/child");

                var targetFiles = ftp.ListDirectoryTree(ftp.GetDirectory(), "*.txt", true);
                targetFiles.ForEach(f =>
                {
                    System.Diagnostics.Debug.WriteLine(f.Name);
                    System.Diagnostics.Debug.WriteLine(f.Text);
                });


                ftp.Get(targetFiles, 
                        ftp.GetDirectory() + "User", @"C:\Users\muchiyama\Documents\project\POLARIS\検証作業\ftp_stored", 
                        Dart.Ftp.Synchronize.Off
                        );
            }
        }

        public void SamplePut()
        {
            Dart.Ftp.License.Set(PoweTCP.Vert.Classes.Shared.LicenseKey.FTP);
            using (var ftp = new Dart.Ftp.Ftp())
            {
                ftp.Session.RemoteEndPoint = new Dart.Ftp.IPEndPoint()
                {
                    HostNameOrAddress = "host",
                    Port = 21 // port
                };
                ftp.Session.Username = "user";
                ftp.Session.Username = "anonymouse"; // anonymouse
                ftp.Session.Password = "pass";

                ftp.Connect(); // Connetct FTP Server
                ftp.Authenticate(); // Connetct FTP Server

                ftp.GetDirectory(); // Get Current Directory on FTP Server
                ftp.SetDirectory("/TargetPath"); // CWD

                ftp.SetType(Dart.Ftp.FileType.Ascii); // set file type
                var response = ftp.Put("target file path", "copy name", Dart.Ftp.Synchronize.Off); // Put SIngle File

                System.Diagnostics.Debug.WriteLine($"Local path {response.LocalPath} / Remote path{response.RemotePath}");
            }
        }
    }
}
