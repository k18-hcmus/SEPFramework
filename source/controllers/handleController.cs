using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SEPFramework.source.Utils.membership;
using SEPFramework.source.Engines;
using SEPFramework.source.SQLSep.Entities;
using SEPFramework.source.SQLSep.SepORM;
using source.Poco;

namespace SEPFramework.source.Controllers
{
    public class handleController
    {
        private static IDatabase hdl_model; 
        public handleController(string url)
        {
            string CONNECTION_STRING = "Data Source=\"localhost, 1433\";" +
               "Initial Catalog=StudentManagement;User ID=sa;" +
               "Password=DesignPattern@2022;Connect Timeout=30;" +
               "Encrypt=False;TrustServerCertificate=False" +
               ";ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
           hdl_model = new SQLDatabase(CONNECTION_STRING);
           hdl_model.Open();
        }
        public bool Login(string username, string password)
        {
            Members dataLogin = Authen(username, password);
            if (dataLogin != null)
            {
                Members data = dataLogin;
                data.isLogged = true;   
                if(hdl_model.Update<Members>(dataLogin,data))
                {
                    return true;   
                }
            }
            return false;
        }

        public bool Logout(string username)
        {
            var auth = string.Format("SELECT * FROM Members WHERE Username = '{0}'", username);
            Members data = hdl_model.Get<Members>(auth);
            if (data != null)
            {
                Members dataLogout = data;
                dataLogout.isLogged = false;
                if (hdl_model.Update<Members>(data, dataLogout))
                {
                    return true;
                }
            }
            return false;
        }
        public Members Authen(string username, string password)
        {
            var auth = string.Format("SELECT * FROM Members WHERE Username = '{0}'", username);
            Members data = hdl_model.Get<Members>(auth);
            if (data != null)
            {
                string u = data.Username;
                string p = Crypto.Decrypt(data.Password);
                if (username == u && password == p)
                    return data;
            }
            return null;
        }
        public bool isExist(string username)
        {
            var check = string.Format("SELECT * FROM Members WHERE Username = '{0}'", username);
            Members data = hdl_model.Get<Members>(check);
            if (data != null) return true;
            return false;
        }
        public bool Register(string username, string password)
        {
            if (isExist(username)) return false;
            List<Members> memList = hdl_model.GetList<Members>();
            Members m = new Members();
            m.Username = username;
            m.Password = Crypto.Encrypt(password);
            m.isLogged = false;
            var idMem = memList.Count + 1;
            m.MemberId = idMem.ToString();
            bool ok = hdl_model.Insert<Members>(m);
            if (ok)
                return true;
            return false;
        }
    }
}
