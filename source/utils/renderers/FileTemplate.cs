using Scriban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.utils.renderers
{
    public abstract class FileTemplate
    {
        protected Template template;
        public FileTemplate(Template template)
        {
            this.template = template;
        }
        public abstract void Render(string path, string filename);
    }
}
