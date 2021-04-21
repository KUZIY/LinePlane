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
    /// Логика взаимодействия для EnterWindow.xaml
    /// </summary>
    public partial class EnterWindow : Window
    {
        

        public EnterWindow()
        {
            InitializeComponent();

        }

        private void EnterButtonClic(object sender, RoutedEventArgs e)
        {
            string Login = LoginField.Text.ToLower().Trim();
            string password = PasswordField.Password.Trim();

            #region установка цвета полей ввода

            PasswordField.Background = Brushes.Transparent;
            LoginField.Background = Brushes.Transparent;

            #endregion

            if (Login.Length < 4)
            {
                LoginField.ToolTip = "Логин должен содержать минимум 4 символа";
                LoginField.Background = (Brush)(new BrushConverter().ConvertFrom("#F15122"));
            }
            else if (password.Length < 5)
            {
                PasswordField.ToolTip = "Пароль должен содержать минимум 5 символа";
                PasswordField.Background = (Brush)(new BrushConverter().ConvertFrom("#F15122"));
            }
            else
            {
                LoginField.ToolTip = "";
                LoginField.Background = Brushes.Transparent;

                PasswordField.ToolTip = "";
                PasswordField.Background = Brushes.Transparent;


                int HashPassword = password.GetHashCode();

                User AuthUser = null;

                 using (UserContext User_DB = new UserContext())
                {
                    AuthUser = User_DB.Users.Where(b => b._Login==Login && b._Password == HashPassword).FirstOrDefault();
                }

                 if (AuthUser != null)
                {
                    MessageBox.Show("Вход произведён");
                    this.Close();
                }
                 else
                {
                    MessageBox.Show("Пользователь не найден");
                }



            }

        }
    }
}
