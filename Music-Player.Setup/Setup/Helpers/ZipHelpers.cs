using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace Music_Player.Setup.Helpers
{
    class ZipHelpers
    {
        public static void ExtractFfmpeg(String __toExtract,String __fromExtract) {
            ZipFile.ExtractToDirectory(__fromExtract,__toExtract);
        }
    }
}
