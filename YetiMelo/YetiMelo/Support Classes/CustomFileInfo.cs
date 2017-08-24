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
        public DateTime Creation;
        public DateTime Modification;
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
            Creation = File.GetCreationTime(path);
            Modification = File.GetLastWriteTime(path);
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
            int mag = (int)Math.Log(value, 1024);
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

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

