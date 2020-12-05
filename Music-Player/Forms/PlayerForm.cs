using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Media;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using NAudio;
using NAudio.Wave;
using System.IO;
using System.Media;
using System.Windows.Media.Imaging;

namespace Music_Player.Forms
{
    public partial class PlayerView : Form
    {
        private Form mform;
        IWavePlayer waveOutDevice;
        bool isPlaying;
        public PlayerView(Form mainform) //the path to music ofcourse
        {
            InitializeComponent();
            waveOutDevice = new WaveOut();
            this.mform = mainform;
            this.FormClosed += onWindowClosed2;
        }
        public PlayerView(String arg)
        {
            InitializeComponent();
            waveOutDevice = new WaveOut();
            try
            {
                this.play(arg);
            }
            catch (Exception E) { MessageBox.Show(E.ToString()); }
            this.FormClosed += onWindowClosed1;
        }
        public void play(string music)
        { 
            var __path = Path.GetDirectoryName(Application.ExecutablePath);
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
            //delete old file
            if (File.Exists($"{__path}tmp.mp3"))
            {
                File.Delete($"{__path}tmp.mp3");
            }
            AudioFileReader audioFileReader = new AudioFileReader(@music);
            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Play();
            isPlaying = true;
        }
        private void onWindowClosed1(object sender, EventArgs e)
        {
            waveOutDevice.Stop();
            waveOutDevice.Dispose();
            Application.Exit();
        }
        private void onWindowClosed2(object sender, EventArgs e)
        {
            waveOutDevice.Stop();
            waveOutDevice.Dispose();
            this.mform.Show();
        }

        private void pausePlayer(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                waveOutDevice.Pause();
                isPlaying = false;
            }else
            {
                waveOutDevice.Play();
                isPlaying = true;
            }
        }
    }
}
