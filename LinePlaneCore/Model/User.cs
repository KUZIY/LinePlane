using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinePlaneCore
{
    class User
    {
        public int Id { get; set; }



        private string _Login;
        private int _Password;
        private string _Email;


        public string Login
        {
            get { return _Login; }
            set { _Login = value;    }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public int Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public User() { }

        public User(string login, int pass, string email)
        {
            _Login = login;
            _Password = pass;
            _Email = email;
        }


    }
}
