using System;
using System.Collections.Generic;
using System.Text;

namespace PoweTCP.Vert.Classes.Shared
{
    public static class ServerParameters
    {
        /// <summary>
        /// default host name using docker containers to host computers
        /// </summary>
        /// <returns></returns>
        public static string HostName() => "host.docker.internal";

        /// <summary>
        /// type connect port
        /// </summary>
        /// <returns></returns>
        public static int Port() => throw new Exception("FTPのportうって");
    }
}
