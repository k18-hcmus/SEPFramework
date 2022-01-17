using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Utils
{
    public class FileUtils
    {
        private static FileUtils instance = null;
        private FileUtils() { }
        public static FileUtils GetInstance()
        {
            if (instance == null)
            {
                instance = new FileUtils();
            }
            return instance;
        }
        public void CreateFile(string path, string data)
        {
            File.WriteAllText(path, data);
        }
    }
}
