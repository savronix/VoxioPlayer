using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using VoxioPlayer.Forms;

namespace VoxioPlayer
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string[] args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                string programLocation = args[1];
                string fileName = Path.GetFileName(args[1]);
                Application.Run(new Player(fileName, programLocation));
            }
            else
            {
                Application.Run(new Player("Standart Değer", "https://tv-trt1.medya.trt.com.tr/master.m3u8"));
            }
        }
    }
}
