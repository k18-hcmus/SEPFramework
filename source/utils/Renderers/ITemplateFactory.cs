using Scriban;
using SEPFramework.source.EntityMeta;
using SEPFramework.source.Utils.Renderers;
using SEPFramework.source.views.template_forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEPFramework.source.Utils.Renderers
{
    public interface ITemplateFactory
    {
        ITemplate GetTemplate(BaseParameter parameter);
    }
}
