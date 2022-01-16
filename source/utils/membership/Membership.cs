using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEPFramework.source.utils.membership
{
    public class Member
    {

        //public member(string cnnstring)
        //{
        //    controller = new handlecontroller(cnnstring);
        //    controller.createsessiontable();
        //}
        public Member()
        {

        }
        public bool Login(string username, string password)
        {
            return true;
        }

        public bool Register(string username, string password)
        {
            return true;
        }

        public bool Logout(string username)
        {
            return true;
        }
    }
}
