using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Music_Player.Forms;

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
            if (args.Length > 0)
            {
                if(args[0] != null)
                {
                   PlayerView spawnPlayer = new PlayerView(args[0]);
                   Application.Run(spawnPlayer);
                }
            }
            else
            {
                Application.Run(new MainView());
            }
        }
    }
}
