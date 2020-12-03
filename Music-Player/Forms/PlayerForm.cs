using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;
using TagLib;
using System.IO;
using System.Windows.Media.Imaging;

namespace Music_Player.Forms
{
    public partial class PlayerView : Form
    {
        private Form mform;
        public PlayerView(Form mainform) //the path to music ofcourse
        {
            InitializeComponent();
            this.mform = mainform;
        }
        public PlayerView(String arg)
        {
            InitializeComponent();
            this.play(arg);
        }
        public void play(string music)
        {
            TagLib.File file = TagLib.File.Create(@music);
            try
            {
                var img = file.Tag.Pictures[0]; // first pic
                byte[] dataArr = img.Data.Data;
                var stream = new MemoryStream();
                stream.Write(dataArr, 0, Convert.ToInt32(dataArr.Length));
                var image1 = new Bitmap(stream, false);
                stream.Dispose();
                backgroundimg.Image = image1;
            }
            catch
            {
                var title = file.Tag.Title;
                if (title == null)
                {
                    stitle.Text = "Now Playing : Unnamed";
                }
                else
                {
                    stitle.Text = "Now Playing : " + title;
                }
            }
            IWavePlayer waveOutDevice = new WaveOut();
            AudioFileReader audioFileReader = new AudioFileReader(@music);
            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Play();
            this.FormClosed += onWindowClosed;
            void onWindowClosed(object sender, EventArgs e)
            {
                waveOutDevice.Stop();
                this.mform?.Show();
            }
        }
    }
}
