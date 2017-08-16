using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using System.IO;

namespace Yetic_MeLo
{
    public class Mp3Editor
    {

        //inputPath="..\\..\\mp3\\Radiorama - Yeti (album version).mp3"
        //outputPath="..\\..\\mp3\\test.mp3"
        public static Boolean Mp3Trim(string inputPath, string outputPath, TimeSpan? begin, TimeSpan? end)
        {
            if (begin.HasValue && end.HasValue && begin > end)
                throw new ArgumentOutOfRangeException("end", "end should be greater than begin");

            using (var reader = new Mp3FileReader(inputPath))
            using (var writer = File.Create(outputPath))
            {
                Mp3Frame frame;
                while ((frame = reader.ReadNextFrame()) != null)
                    if (reader.CurrentTime >= begin || !begin.HasValue)
                    {
                        if (reader.CurrentTime <= end || !end.HasValue)
                            writer.Write(frame.RawData, 0, frame.RawData.Length);
                        else break;
                    }
            }
            return true; //only for clearer testing, the method can be void
        }

        //mp3Files should contain the path too
        public static Boolean Mp3Concat(string[] mp3Files, string OutputFile)
        {
            using (var w = new BinaryWriter(File.Create(OutputFile)))
            {
                new List<string>(mp3Files).ForEach(f => w.Write(File.ReadAllBytes(f)));
            }
            return true; //only for clearer testing, the method can be void
        }



    }
}
