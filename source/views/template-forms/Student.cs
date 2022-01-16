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
        public string id;
        public string name;
        public string mssv;
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
