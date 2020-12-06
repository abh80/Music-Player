using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Music_Player.Forms;
using System.Diagnostics;
using System.IO;

namespace Music_Player
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var __path = Path.GetDirectoryName(Application.ExecutablePath);
            if (((args.Length > 0) && args[0] != "force" ) && System.Diagnostics.Process.GetProcessesByName(System.Diagnostics.Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                MessageBox.Show("Another instance of this app is already running please close it to start this");
                Application.Exit();
                return;
            }
            var ffmpegExists = File.Exists($@"{__path}/ffmpeg/ffmpeg-n4.3.1-26-gca55240b8c-win64-gpl-shared-4.3/bin/ffmpeg.exe");
            if (!ffmpegExists)
            {
                Process.Start($@"{__path}/Music-Player.Setup.exe");
                Application.Exit();
            }
            else if(args.Length > 0)
            {
                if(args[0] != null && args[0] != "force")
                {
                    try
                    {
                        if (!args[0].EndsWith(".mp3")) {
                            MessageBox.Show("Only Mp3 is supported");
                            return;
                        }
                        PlayerView spawnPlayer = new PlayerView(args[0]);
                        Application.Run(spawnPlayer);
                    }
                    catch (Exception e) { MessageBox.Show(e.ToString()); }
                }
            }
            else
            {
                Application.Run(new MainView());
            }
        }
    }
}
