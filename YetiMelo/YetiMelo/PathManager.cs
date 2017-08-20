using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YetiMelo
{
    public class PathManager
    {

        public static void SaveToFile(List<string> FilePaths)
        {
            TextWriter tw = new StreamWriter("C:\\Users\\Dodo\\Desktop\\test\\Folders.txt");

            foreach (String s in FilePaths)
                tw.WriteLine(s);

            tw.Close();
        }
    }
}
