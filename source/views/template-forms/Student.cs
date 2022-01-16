using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Views.template_forms
{
    public class Student
    {
        public string id { get; set; }
        public string name { get; set; }
        public string mssv { get; set; }
        public Student(string id, string name, string mssv)
        {
            this.id = id;
            this.name = name;
            this.mssv = mssv;
        }
        public Student(DataRow row)
        {
            this.id = (string)row["id"];
            this.name = (string)row["name"];
            this.mssv = (string)row["mssv"];
        }
    }
}
