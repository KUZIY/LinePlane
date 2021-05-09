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

    public partial class EnterWindow : Window
    {

        public EnterWindow()
        {
            InitializeComponent();

        }

                /*User AuthUser = null;

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
                }*/

    }
}
