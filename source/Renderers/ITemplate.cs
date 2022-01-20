using Scriban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.Utils.Renderers
{
    public interface ITemplate
    {
        void Render(string path, string filename);
    }
}
