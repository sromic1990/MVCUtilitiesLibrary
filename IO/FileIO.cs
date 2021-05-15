using System.IO;
using UnityEngine;

namespace UtilitiesLibrary.IO
{
    public static class FileIO
    {
        private static readonly string Path = Application.persistentDataPath + "/";
        private static string _filename = "gameData.sou";

        public static void SetFileName(string filename)
        {
            _filename = filename;
        }
        
        public static void WriteData(string dataStream)
        {
            var path = Path + _filename;
            File.WriteAllText(path, dataStream);
        }

        public static string ReadData()
        {
            if (FileExists())
            {
                string str = File.ReadAllText(Path + _filename);
                return str;
            }
            else
            {
                return "";
            }
        }

        public static bool FileExists()
        {
            if(File.Exists(Path + _filename))
            {
                return true;
            }

            return false;
        }

        public static string GetSavePath()
        {
            return Path + _filename;
        }
    }
}