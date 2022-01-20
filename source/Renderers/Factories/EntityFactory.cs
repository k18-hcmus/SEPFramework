using Scriban;
using SEPFramework.source.Utils.Renderers.Parameters;
using SEPFramework.source.Utils.Renderers.Templates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Utils.Renderers.Factories
{
    public class EntityFactory : ITemplateFactory
    {
        public ITemplate GetTemplate(BaseParameter parameter)
        {
            EntityParameter entityParam = parameter as EntityParameter;
            return new EntityTemplate(
                        Template.Parse(System.IO.File.ReadAllText("..\\..\\source\\Templates\\Entity\\EntityTemplate.txt")),
                        entityParam.Data,
                        entityParam.NamespaceString);
        }
    }
}
