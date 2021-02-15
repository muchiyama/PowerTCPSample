using PoweTCP.Vert.Classes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PoweTCP.Vert
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                PowerTCPFtpSample.Create().Put();
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
        }
    }
}
