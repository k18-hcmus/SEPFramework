using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SEPFramework.source.SQLSep.Entities;
using SEPFramework.source.SQLSep.SepORM;
using SEPFramework.source.Utils.IoCContainer;
using SEPFramework.source.Utils.membership;
using SEPFramework.source.Utils.Renderers;
using SEPFramework.source.Utils.Renderers.Factories;
using SEPFramework.source.Utils.Renderers.Parameters;

namespace SEPFramework.source.views
{
    public partial class Home : Form
    {
        private string username;
        private SignIn signIn;
        public Home()
        {
            InitializeComponent();
        }
        public Home(SignIn signIn)
        {
            InitializeComponent();
            this.signIn = signIn;
            this.username = signIn.getUsername();
        }

        private void logout_btn_Click(object sender, EventArgs e)
        {
            if (this.signIn.member.Logout(this.username))
            {
                this.signIn.Show();
                this.Close();
            }
        }

        private void generate_btn_Click(object sender, EventArgs e)
        {
            try
            {
                //IIoC IoCContainer = new IoCImpl();
                //IoCContainer.RegisterType<DataProvider>(
                //    new InjectionConstructor().AddParameter<string>(CONNECTION_STRING));
                //List<TableMapper> tableMappers = IoCContainer.Resolve<DataProvider>().getTables();
                DataProvider provider = DataProvider.GetInstance();
                provider.Catalog = "StudentManagement";
                List <TableMapper> tableMappers = provider.getTables();
                string rootPath = "SampleSource";
                string formPath = ".\\SampleSource\\Forms";
                string entityPath = ".\\SampleSource\\Entities";
                string utilPath = ".\\SampleSource\\Utils";
                string sqlPath = ".\\SampleSource\\SepORM";

                DirectoryInfo d = Directory.CreateDirectory(rootPath);
                string namespaceString = "SEPFramework.SampleSource";

                ITemplateFactory formfactory = new FormFactory();

                ITemplate homeFormTemplate = formfactory.GetTemplate(
                    new FormParameter(FormParameter.Type.HomeForm,
                    namespaceString, tableMappers));
                ITemplate baseFormTemplate = formfactory.GetTemplate(
                    new FormParameter(FormParameter.Type.BaseForm,
                    namespaceString, tableMappers));
                ITemplate actionFormTemplate = formfactory.GetTemplate(
                    new FormParameter(FormParameter.Type.ActionForm,
                    namespaceString));
                ITemplate addFormTemplate = formfactory.GetTemplate(
                    new FormParameter(FormParameter.Type.AddForm,
                    namespaceString));
                ITemplate editFormTemplate = formfactory.GetTemplate(
                    new FormParameter(FormParameter.Type.EditForm,
                    namespaceString));
                DirectoryInfo df = Directory.CreateDirectory(formPath);
                homeFormTemplate.Render(formPath, "HomeForm");
                baseFormTemplate.Render(formPath, "BaseForm");
                actionFormTemplate.Render(formPath, "ActionForm");
                addFormTemplate.Render(formPath, "AddForm");
                editFormTemplate.Render(formPath, "EditForm");

                DirectoryInfo de = Directory.CreateDirectory(entityPath);
                ITemplateFactory entityFactory = new EntityFactory();
                foreach (TableMapper table in tableMappers)
                {
                    ITemplate entityTemplate = entityFactory.GetTemplate(
                        new EntityParameter(table, namespaceString));
                    entityTemplate.Render(entityPath, table.name);
                }

                DirectoryInfo di = Directory.CreateDirectory(utilPath);
                ITemplateFactory utilFactory = new UtilFactory();
                ITemplate utilTemplate = utilFactory.GetTemplate(
                    new BaseParameter(namespaceString));
                utilTemplate.Render(utilPath, "DataUtils");

                DirectoryInfo ds = Directory.CreateDirectory(sqlPath);
                ITemplateFactory sqlFactory = new SQLFactory();
                ITemplate sqlTemplate = sqlFactory.GetTemplate(
                    new SQLParameter(SQLParameter.Type.SQLServer, namespaceString));
                sqlTemplate.Render(sqlPath, "SQLDatabase");

                MessageBox.Show("Generate source successfully");
            }
            catch (Exception exp)
            {
                MessageBox.Show("Generate source failed " + exp.Message);
            }
        }
    }
}
