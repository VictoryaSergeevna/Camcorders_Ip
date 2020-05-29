using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp17
{
    class Program
    {
        

        static void Main(string[] args)
        {
            try
            {
                IpCam cam1 = IpCam.getInstance("192.168.0.1");
                WriteLine(cam1.IP);
                WriteLine();
                IpCam cam2 = IpCam.getInstance("192.168.1.2");
                WriteLine(cam2.IP);
                WriteLine();
                IpCam cam3 = IpCam.getInstance("192.168.1.3");
                WriteLine(cam3.IP);
                WriteLine();
                ReadKey();
            }
            catch (ArgumentException ex)
            {
                WriteLine(ex.Message);
            }
        }
    }


    class IpCam
    {
       
        private static Dictionary<string, IpCam> camera = new Dictionary<string, IpCam>();

        public string IP { get; private set; }
        private IpCam(string ip)
        {
            this.IP = ip;
        }
        public static IpCam getInstance(string ipAdress)
        {
            IpCam cam = null;
            if (ipAdress== null||(!camera.ContainsKey(ipAdress)&& camera.Count<3))
            {
                cam=new IpCam(ipAdress);
                camera.Add(ipAdress, cam);
            }
            else
            {
                throw new ArgumentException(string.Format("{0} Eror!", ipAdress));
            }
            return cam;

        }
    }
}



