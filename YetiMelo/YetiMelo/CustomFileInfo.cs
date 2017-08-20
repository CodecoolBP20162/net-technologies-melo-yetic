using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YetiMelo
{
    class CustomFileInfo
    {
        public FileInfo fileInfo { get; set; }
        public string FileSize { get; set; }
        public DateTime creation;
        public DateTime modification;
        public string extension;
        static readonly string[] SizeSuffixes =
                   { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        public CustomFileInfo(FileInfo file)
        {
            this.fileInfo = file;
            FileSize = getSize();
        }

        public CustomFileInfo(String path)
        {
            this.fileInfo = new FileInfo(path);
            FileSize = getSize();
            creation = File.GetCreationTime(path);
            modification = File.GetLastWriteTime(path);
            extension = Path.GetExtension(path);
        }

        private string getSize()
        {
            long size = this.fileInfo.Length;
            string strsize = SizeSuffix(size);
            return strsize;
        }

        internal static string SizeSuffix(long value, int decimalPlaces = 1)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return "0.0 bytes"; }

            // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
            int mag = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag) 
            // [i.e. the number of bytes in the unit corresponding to mag]
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            // make adjustment when the value is large enough that
            // it would round up to 1000 or more
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }
    }
}

