using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Runtime;
namespace Music_Player.Setup.Helpers
{
    class DownloadHelpers
    {
        public WebClient DownloadFfmpeg(String __path)
        {
            String x64bit = "https://github.com/BtbN/FFmpeg-Builds/releases/download/autobuild-2020-12-04-13-04/ffmpeg-n4.3.1-26-gca55240b8c-win64-gpl-shared-4.3.zip";
            String savename = $@"{__path}/ffmpeg-zip.zip";
            var client = new WebClient();
            client.DownloadFileAsync(new Uri(x64bit), @savename);
            return client;
        }
    }
}
