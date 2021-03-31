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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Timers;

namespace LinePlane
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Window_Menu_Click(object sender, RoutedEventArgs e)
        {
            

            if (MenuButton.FontSize!=10)
            {
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = 0;
                animation.To = 90;
                animation.Duration = TimeSpan.FromSeconds(0.1);
                RotateTransform rt = new RotateTransform() { CenterX = 0, CenterY = 0 };
                MenuButton.RenderTransform = rt;
                rt.BeginAnimation(RotateTransform.AngleProperty, animation);
                MenuButton.FontSize = 10;
                MenyStrip.Visibility = Visibility.Visible;
            }   
            else
            {
                DoubleAnimation animation = new DoubleAnimation();
                animation.From = 90;
                animation.To = 0;
                animation.Duration = TimeSpan.FromSeconds(0.1);
                RotateTransform rt = new RotateTransform() { CenterX = 0, CenterY = 0 };
                MenuButton.RenderTransform = rt;
                rt.BeginAnimation(RotateTransform.AngleProperty, animation);
                MenuButton.FontSize = 20;
                MenyStrip.Visibility = Visibility.Hidden;
            }
        }

        private void Button_registration_Click(object sender, RoutedEventArgs e)
        {
            RegistrationWindow Avtoauthorization = new RegistrationWindow();
            Avtoauthorization.Show();
        }

        private void Button_enter_Click(object sender, RoutedEventArgs e)
        {
           EnterWindow Avtoauthorization = new EnterWindow();
            Avtoauthorization.Show();
        }
    }
}
