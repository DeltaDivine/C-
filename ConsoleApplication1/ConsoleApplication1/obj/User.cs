using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpMysql
{
    class User
    {
        private string name;
        private string password;
        private string phone;

        public User()
        {

        }

        //proppull
        public User(string name, string password, string phone)
        {
            this.name = name;
            this.password = password;
            this.phone = phone;
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }


        public string Password
        {
            get { return password; }
            set { password = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
