using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.SQLSep.SepDataType
{
    public interface DataType
    {
        string GenCreateQuery(PropertyInfo prop);
        string GenSQLValue(object value);
    }
}
