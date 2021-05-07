using LinePlaneCore.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LinePlaneCore.Logic
{
    internal interface ISelectable
    {
        void Shape_Menu(object sender, MouseButtonEventArgs e);
        void Choise_Shape(object sender, MouseButtonEventArgs e);
        void Free_Shape(object sender, MouseButtonEventArgs e);
    }

    internal class SpawnShape
    {
        public Canvas _ShapeCanvas=null;
        public Canvas ShapeCanvas
        {
            get;
            set;
        }


        internal class Draw_Square : ISelectable
        {

            private Rectangle _shape;

            internal Rectangle shape
            {
                get => _shape;
            }

             protected BitmapImage _shape_image
            {
                get;
                set;
            }
            

            private void set_events(Rectangle shape)
            {
                shape.MouseRightButtonDown += Shape_Menu;
                shape.PreviewMouseLeftButtonUp += Free_Shape;
                shape.PreviewMouseLeftButtonDown += Choise_Shape;
                shape.IsEnabled = false;
            }

      
            public Draw_Square(double widith, double height, BitmapImage _shape_png = null)
            {

                _shape = new Rectangle();

                set_events(shape);

                shape.Height = height;
                shape.Width = widith;
                var brash = new BrushConverter();
                if (_shape_png == null) shape.Fill = new SolidColorBrush(Colors.Black);
                else shape.Fill= new ImageBrush(_shape_png);

            }


            #region исполнение ISelectable
            public void Choise_Shape(object sender, MouseButtonEventArgs e)
            {
                MainWindowShell.TakeShape(_shape);
            }
            public void Free_Shape(object sender, MouseButtonEventArgs e)
            {
                MainWindowShell.TakeShape(null);
            }
            public void Shape_Menu(object sender, MouseButtonEventArgs e)
            {
              
            }

            #endregion

        }


        internal class Draw_Ellipse : ISelectable
        {

            private Ellipse _shape;

            internal Ellipse shape
            {
                get => _shape;
            }

            protected BitmapImage _shape_image
            {
                get;
                set;
            }

            private void set_events(Ellipse shape)
            {
                shape.MouseRightButtonDown += Shape_Menu;
                shape.PreviewMouseLeftButtonUp += Free_Shape;
                shape.PreviewMouseLeftButtonDown += Choise_Shape;
                shape.IsEnabled = false;
            }


            public Draw_Ellipse(double widith, double height, BitmapImage _shape_png = null)
            {

                _shape = new Ellipse();

                set_events(shape);

                shape.Height = height;
                shape.Width = widith;
                var brash = new BrushConverter();
                if (_shape_image == null) shape.Fill = new SolidColorBrush(Colors.Black);
                else shape.Fill = new ImageBrush(_shape_png);

            }


            #region исполнение ISelectable
            public void Choise_Shape(object sender, MouseButtonEventArgs e)
            {
                MainWindowShell.TakeShape(_shape);
            }
            public void Free_Shape(object sender, MouseButtonEventArgs e)
            {
                Move.ArgsClear();
            }

            public void Shape_Menu(object sender, MouseButtonEventArgs e)
            {
                Binding myBinding = new Binding("MyDataProperty");
                myBinding.Source = _shape;
            }
            #endregion

        }


    }
}
