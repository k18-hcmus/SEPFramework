<<<<<<< HEAD
﻿using SEPFramework.source.views;
using SEPFramework.source.views.template_forms;
=======
﻿using SEPFramework.source.Views.template_forms;
>>>>>>> 93f61f1 (Generate Multiple Table)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEPFramework.source.views;

namespace SEPFramework
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GeneratingForm());
        }
    }
}
