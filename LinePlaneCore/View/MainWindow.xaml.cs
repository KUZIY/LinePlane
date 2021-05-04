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
using System.Windows.Markup;
using System.IO;

namespace LinePlaneCore
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        private IDraw a;

        public MainWindow()
        {
            InitializeComponent();

            a =null;

        }

        internal Point Get_Cursor_Point(MouseEventArgs e) => Mouse.GetPosition(this);


        #region Прорисовка объектов
        private void SetLinePosition(MouseEventArgs e)
        {
            //Show_Ander_Strip.Show_button_strip_menu(this);
            if (a!=null)

            a.Set(e);


        }
        private void Canvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (a != null)
                a.Draw(e);


        }

        private void Abort_Paint(object sender, MouseButtonEventArgs e)
        {

            if (a != null)
                a.Abort(sender, e);

        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {

            if (a != null)
                SetLinePosition(e);

            Move.Move_shape(sender, e);

        }

        private void CanvasLeftMouseClickDown(object sender, MouseEventArgs e) { }
        private void CanvasLeftMouseClickUp(object sender, MouseEventArgs e) { }
        private void CanvasRightMouseClick(object sender, MouseEventArgs e) { }
        private void CanvasDragMouse(object sender, MouseEventArgs e) { }


        #endregion

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            a = new Draw_Line(this);
            Display_Area.Cursor = Cursors.Cross;
        }

    }
}
