using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Views.template_forms
{
    public class Class
    {
        public string id;
        public int studentNum;
        public string name;
        public Class(string id, int studentNum, string name)
        {
            this.id = id;
            this.studentNum = studentNum;
            this.name = name;
        }
        public Class(DataRow row)
        {
            this.id = (string)row["id"];
            this.studentNum = (int)row["studentNum"];
            this.name = (string)row["name"];
        }
    }
}
