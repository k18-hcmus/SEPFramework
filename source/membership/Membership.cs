using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEPFramework.source.Controllers;
using SEPFramework.source.Utils.IoCContainer;

namespace SEPFramework.source.Utils.membership
{
    public class Membership
    {
        private static handleController controller;
        public Membership()
        {
            controller = IoC.Resolve<handleController>();
        }
        public bool Login(string username, string password)
        {
            if (controller.Login(username,password))
                return true;
            return false;
        }

        public bool Register(string username, string password)
        {
            if (controller.Register(username, password))
                return true;
            return false;
        }

        public bool Logout(string username)
        {
            if(controller.Logout(username))
                return true;
            return false;
        }
    }
}
