using LinePlaneCore.Control.Commands;
using LinePlaneCore.Logic;
using LinePlaneCore.Manger;
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
    class RegistrationWindowShell : Base
    {
        #region Данные пользователя

        private string _UserName = "";
        private string _Password = "";
        private string _UserEmail = "";


        public string UserName
        {
            get => _UserName;
            set => Set(ref _UserName, value);
        }
        public string UserEmail
        {
            get => _UserEmail;
            set => Set(ref _UserEmail, value);
        }
        #endregion

        #region цвета полей и текст ошибки

        #region цвета полей
        private Brush _UserNameBrush = Brushes.Transparent;
        private Brush _PasswordBrush = Brushes.Transparent;
        private Brush _EmailBrush = Brushes.Transparent;


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

        public Brush EmailBrush
        {
            get => _EmailBrush;
            set => Set(ref _EmailBrush, value);
        }
        #endregion

        #region отображение ошибок

        private string _LoginError = "";
        private string _PasswordError = "";
        private string _EmailError = "";

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

        public string EmailError
        {
            get => _EmailError;
            set => Set(ref _EmailError, value);
        }

        #endregion

        #endregion

        #region Команда для регистрации

        public ICommand RegistrationCommand { get; }

        private void OnRegistrationCommandExecuted(object p)
        {
            _Password = (p as PasswordBox).Password;

            string login = _UserName.ToLower().Trim();
            string password = _Password.Trim();
            string email = _UserEmail.ToLower().Trim();

            #region установка цвета полей ввода и обнуление текста ошибок

            UserNameBrush = Brushes.Transparent;
            PasswordBrush = Brushes.Transparent;
            EmailBrush = Brushes.Transparent;

            LoginError = "";
            PasswordError = "";
            _EmailError = "";

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
            else if (!email.Contains("@") || !email.Contains(".") || email.Length < 5)
            {
                EmailError = "Неверно введён Email";
                EmailBrush = (Brush)(new BrushConverter().ConvertFrom("#F15122"));
            }
            else
            {
                LoginError = "";
                UserNameBrush = Brushes.Transparent;

                PasswordError = "";
                PasswordBrush = Brushes.Transparent;

                EmailError = "";
                EmailBrush = Brushes.Transparent;

                string HashPassword = PasswordHash.GetHashCode(password);

                if (UserManager.AddUser(login, HashPassword , email))
                {
                    UserData.Username = login;
                    var MainWindow = new MainWindow();
                    MainWindow.Show();

                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window is RegistrationWindow or WelcomeWindow)
                        {
                            window.Close();
                        }
                    }
                }
                else MessageBox.Show("Такой пользователь уже существует");

            }
        }

        private bool CanRegistrationCommandExecuted(object p) => true;

        #endregion

        public RegistrationWindowShell()
        {
            RegistrationCommand = new ActionCommand(OnRegistrationCommandExecuted, CanRegistrationCommandExecuted);
        }

    }
}
