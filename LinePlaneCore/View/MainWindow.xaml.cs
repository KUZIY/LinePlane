using System;
using System.Windows;
using System.Windows.Input;

namespace LinePlaneCore
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            Move.Move_shape(sender, e);
        }
    }
}
