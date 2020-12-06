using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Music_Player.Setup.Helpers;
using Music_Player.Forms;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
namespace Music_Player.Setup
{
    class Setupc
    {
        System.Net.WebClient client;
        public void complete_setup(String __path,SetupManager form)
        {
            var Helper = new DownloadHelpers();
            var client = Helper.DownloadFfmpeg(__path);
            form.updateSetupLabel("Downloading FFmpeg");
            this.client = client;
            client.DownloadProgressChanged += (t, k) =>
            {
                form.updateProgress(k.ProgressPercentage);
            };
            client.DownloadFileCompleted += (k, t) =>
            {
                if (t.Error != null) {
                    MessageBox.Show(t.Error.ToString());
                };
                if (t.Cancelled) return;
                form.updateSetupLabel("Extracting FFmpeg");
                ZipHelpers.ExtractFfmpeg( $@"{__path}/ffmpeg", $@"{__path}/ffmpeg-zip.zip");
                form.onComplete();
            };
        }
        public void clear(String __path) { 
            this.client.CancelAsync();
            this.client.Dispose();
        }
    }
}
