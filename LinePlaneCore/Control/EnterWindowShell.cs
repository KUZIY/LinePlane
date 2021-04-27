using LinePlaneCore.Control.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LinePlaneCore.Control
{
    class EnterWindowShell:Base
    {

        #region Данные пользователя

        private string _UserName = "";
        private string _Password = "";


        public string UserName
        {
            get => _UserName;
            set => Set(ref _UserName, value);
        }

        #endregion

        #region цвета полей и текст ошибки

        #region цвета полей
        private Brush _UserNameBrush = Brushes.Transparent;
        private Brush _PasswordBrush = Brushes.Transparent;


        public Brush UserNameBrush
        {
            get => _UserNameBrush;
            set => Set(ref _UserNameBrush, value);
        }

        public Brush PasswordBrush
        {
            get => _PasswordBrush;
            set => Set(ref _PasswordBrush, value);
        }

        #endregion

        #region отображение ошибок

        private string _LoginError = "";
        private string _PasswordError = "";

        public string LoginError
        {
            get => _LoginError;
            set => Set(ref _LoginError, value);
        }

        public string PasswordError
        {
            get => _PasswordError;
            set => Set(ref _PasswordError, value);
        }

        #endregion

        #endregion

        #region Команда для регистрации

        public ICommand EnterCommand { get; }

        private void OnEnterCommandExecuted(object p)
        {
            _Password = (p as PasswordBox).Password;

            string login = _UserName.ToLower().Trim();
            string password = _Password.Trim();

            #region установка цвета полей ввода и обнуление текста ошибок

            UserNameBrush = Brushes.Transparent;
            PasswordBrush = Brushes.Transparent;

            LoginError = "";
            PasswordError = "";

            #endregion

            if (login.Length < 4)
            {
                LoginError = "Логин должен содержать минимум 4 символа";
                UserNameBrush = (Brush)(new BrushConverter().ConvertFrom("#F15122"));
            }
            else if (password.Length < 5)
            {
                PasswordError = "Пароль должен содержать минимум 5 символа";
                PasswordBrush = (Brush)(new BrushConverter().ConvertFrom("#F15122"));
            }
            else
            {
                LoginError = "";
                UserNameBrush = Brushes.Transparent;

                PasswordError = "";
                PasswordBrush = Brushes.Transparent;

                int HashPassword = password.GetHashCode();

                User AuthUser = null;


                /*using (UserContext User_DB = new UserContext())
                {
                    AuthUser = User_DB.Users.Where(b => b._Login == login && b._Password == HashPassword).FirstOrDefault();
                }

                if (AuthUser != null)
                {
                    MessageBox.Show("Вход произведён");
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }*/

            }
        }

        private bool CanEnterCommandExecuted(object p) => true;

        #endregion

        public EnterWindowShell()
        {
            EnterCommand = new ActionCommand(OnEnterCommandExecuted, CanEnterCommandExecuted);
        }


    }
}
