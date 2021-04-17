using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LinePlaneCore
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();

        }

        private void Registration_button(object sender, RoutedEventArgs e)
        {
            string login=RegistrationField.Text.ToLower().Trim();
            string password=PasswordField1.Password.Trim();
            string email = EmailField.Text.ToLower().Trim();

            #region установка цвета полей ввода

            RegistrationField.Background = Brushes.Transparent;
            PasswordField1.Background = Brushes.Transparent;
            PasswordField2.Background = Brushes.Transparent;
            EmailField.Background = Brushes.Transparent;

            #endregion

            if (login.Length < 4)
            {
                RegistrationField.ToolTip = "Логин должен содержать минимум 4 символа";
                RegistrationField.Background= (Brush)(new BrushConverter().ConvertFrom("#F15122"));
            }
            else if (password.Length < 5)
            {
                PasswordField1.ToolTip = "Пароль должен содержать минимум 2 символа";
                PasswordField1.Background = (Brush)(new BrushConverter().ConvertFrom("#F15122"));
            }
            else if (password != PasswordField2.Password.Trim())
            {
                PasswordField2.ToolTip = "Пароли должны совпадать";
                PasswordField2.Background = (Brush)(new BrushConverter().ConvertFrom("#F15122"));
            }
            else if( !email.Contains("@") || !email.Contains(".") || email.Length<5)
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

                MessageBox.Show("Зарегистрирован");


            }

            
        }
    }
}
