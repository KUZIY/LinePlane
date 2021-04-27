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
    
    public partial class RegistrationWindow : Window
    {   
        public RegistrationWindow()
        {
            InitializeComponent();
        }


       /* private void Registration_button(object sender, RoutedEventArgs e)
        {
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
        }*/
    }
}
