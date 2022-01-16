using Scriban;
using SEPFramework.source.Utils.Renderers.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Utils.Renderers.Factories
{
    public class UtilFactory : ITemplateFactory
    {
        public ITemplate GetTemplate(BaseParameter parameter)
        {
            return new UtilTemplate(
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\Utils\\DataUtils.txt")),
                        parameter.NamespaceString);
        }
    }
}
