using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Utils
{
    public static class FileUtils
    {
        public static void CreateFile(string path, string data)
        {
            File.WriteAllText(path, data);
        }
    }
}
