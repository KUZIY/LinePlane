using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinePlaneCore.Control
{
    class RegistrationWindowShell: Base
    {
        #region Данные пользователя

        private string _UserName = "";
        private string _Password = "";
        private string _SecondPassword = "";
        private string _UserEmail = "";


        public string UserName
        {
            get => UserName;
            set => Set(ref _UserName, value);
        }
        public string Password
        {
            get => Password;
            set => Set(ref _Password, value);
        }
        public string SecondPassword
        {
            get => SecondPassword;
            set => Set(ref _SecondPassword, value);
        }
        public string UserEmail
        {
            get => UserEmail;
            set => Set(ref _UserEmail, value);
        }
        #endregion



    }
}
