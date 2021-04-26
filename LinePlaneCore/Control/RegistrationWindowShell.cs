using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

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
            get => _UserName;
            set => Set(ref _UserName, value);
        }
        public string Password
        {
            get => _Password;
            set => Set(ref _Password, value);
        }
        public string SecondPassword
        {
            get => _SecondPassword;
            set => Set(ref _SecondPassword, value);
        }
        public string UserEmail
        {
            get => _UserEmail;
            set => Set(ref _UserEmail, value);
        }
        #endregion

        #region цвета полей
        #endregion

        #region Команда для регистрации

        public ICommand RegistrationCommand { get; }

        private void OnRegistrationCommandExecuted(object p)
        {
            {
                string login = _UserName.ToLower().Trim();
                string password = _Password.Trim();
                string secondpassword = _SecondPassword.Trim();
                string email = _UserEmail.ToLower().Trim();

                #region установка цвета полей ввода

                /*RegistrationField.Background = Brushes.Transparent;
                PasswordField1.Background = Brushes.Transparent;
                PasswordField2.Background = Brushes.Transparent;
                EmailField.Background = Brushes.Transparent;*/

                #endregion

                if (login.Length < 4)
                {
                    RegistrationField.ToolTip = "Логин должен содержать минимум 4 символа";
                    RegistrationField.Background = (Brush)(new BrushConverter().ConvertFrom("#F15122"));
                }
                else if (password.Length < 5)
                {
                    PasswordField1.ToolTip = "Пароль должен содержать минимум 5 символа";
                    PasswordField1.Background = (Brush)(new BrushConverter().ConvertFrom("#F15122"));
                }
                else if (password != PasswordField2.Password.Trim())
                {
                    PasswordField2.ToolTip = "Пароли должны совпадать";
                    PasswordField2.Background = (Brush)(new BrushConverter().ConvertFrom("#F15122"));
                }
                else if (!email.Contains("@") || !email.Contains(".") || email.Length < 5)
                {
                    EmailField.ToolTip = "Неверно введён Email";
                    EmailField.Background = (Brush)(new BrushConverter().ConvertFrom("#F15122"));
                }
                else
                {
                    RegistrationField.ToolTip = "";
                    RegistrationField.Background = Brushes.Transparent;

                    PasswordField1.ToolTip = "";
                    PasswordField1.Background = Brushes.Transparent;

                    PasswordField2.ToolTip = "";
                    PasswordField2.Background = Brushes.Transparent;

                    EmailField.ToolTip = "";
                    EmailField.Background = Brushes.Transparent;

                    int HashPassword = password.GetHashCode();

                    User client = new User();

                    client._Email = email;
                    client._Password = HashPassword;
                    client._Login = login;


                    try
                    {
                        UserDB.Add(client);
                        UserDB.SaveChanges();
                        this.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Такой пользователь уже существует");

                    }

                }

                private bool CanRegistrationCommandExecuted(object p) => true;

        #endregion

    }
}
