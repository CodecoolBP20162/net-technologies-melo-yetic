using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YetiMelo
{
    internal class TaglibWrapper
    {
        internal TimeSpan time;
        internal string album;

        public TaglibWrapper(string path)
        {
            TagLib.File f = TagLib.File.Create(path, TagLib.ReadStyle.Average);
            var duration = (int)f.Properties.Duration.TotalSeconds;
            this.time = TimeSpan.FromSeconds(duration);
            this.album = f.Tag.Album;
            f.Dispose();
        }
    }
}
