using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.SQLSep.SepDataType
{
    public interface ISchemaByType
    {
        string GenerateSchema(PropertyInfo prop);
    }
}
