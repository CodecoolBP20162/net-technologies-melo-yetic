using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YetiMelo
{
    class InputCheck
    {

        public static Boolean Mergable(string Path1, string Path2, string NewFile, string Path3)
        {
            if (Path1 == "Select #1 mp3" || Path1=="" || Path2 == "Select #2 mp3" || Path2 == "" || NewFile == "Please enter the new file's name" || NewFile=="" || Path3 == "Select destination folder" || Path3 == "")
            {
                return false;
            }
            return true;
        }

        public static Boolean Mp3Format(string Path)
        {
            if (Path.Length<4 || Path.Substring(Path.Length - 4) != ".mp3")
            {
                return false;
            }
            return true;
        }

        public static string CreateMp3Format(string FileName)
        {
            if (!Mp3Format(FileName))
            {
                return FileName+".mp3";
            }
            return FileName;
        }

        public static Boolean Trimmable(string Path, string NewFile, string Path2)
        {
            if (Path== "Select mp3 path" || Path=="" || NewFile== "Please enter the new file's name" || NewFile=="" ||
                Path2== "Select destination folder" || Path2=="")
            {
                return false;
            }
            return true;
        }

        public static Boolean IsNumber(string Number)
        {
            //TryParse doesn't work with . or ,

            try
            {
                float Numb = Convert.ToInt32(Number);
            }
            catch (FormatException)
            {
                return false;
            }
            
            return true;
        }


    }
}
