using Scriban;
using SEPFramework.source.Utils.renderers.Parameters;
using SEPFramework.source.Utils.renderers.Templates;
using SEPFramework.source.Utils.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Utils.renderers.Factories
{
    public class SQLFactory : ITemplateFactory
    {
        public ITemplate GetTemplate(BaseParameter parameter)
        {
            SQLParameter sqlParam = parameter as SQLParameter;
            ITemplate fileTemplate = null;
            switch (sqlParam.SQLType)
            {
                case SQLParameter.Type.SQLServer:
                    fileTemplate = new SQLTemplate(
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\SepORM\\SQLServerDatabase.txt")),
                        sqlParam.NamespaceString);
                    break;
            }
            return fileTemplate;
        }
    }
}
