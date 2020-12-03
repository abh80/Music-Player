using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Music_Player.Forms
{
    public partial class MainView : Form
    {
        private PlayerView spawnPlayer;
        public MainView()
        {
                InitializeComponent();
            
        }

        private OpenFileDialog openFileDialog1;
        private void handle_browse(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse MP3 Files";
            openFileDialog1.DefaultExt = "mp3";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            string FileName = openFileDialog1.FileName;
            if (!(FileName.EndsWith(".mp3")))
            {
                MessageBox.Show("The selected file must be mp3");
                return;
            }
            this.Hide();
            spawnPlayer = new PlayerView(this);
            spawnPlayer.Show();
            spawnPlayer.play(FileName);


        }
    }
}
