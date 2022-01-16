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
        public string id { get; set; }
        public int studentNum { get; set; }
        public string name { get; set; }
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
