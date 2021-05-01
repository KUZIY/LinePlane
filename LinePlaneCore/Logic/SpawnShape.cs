using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LinePlaneCore.Logic
{
    internal interface IDraw
    {
        void Abort(object sender, MouseButtonEventArgs e);
        void Draw(object sender, MouseButtonEventArgs e);
        void Set(object sender, MouseEventArgs e);

    }

    internal interface ISelectable
    {
        void Shape_Menu(object sender, MouseButtonEventArgs e);
        void Choise_Shape(object sender, MouseButtonEventArgs e);
        void Free_Shape(object sender, MouseButtonEventArgs e);
    }

    class SpawnShape
    {
        public Canvas _ShapeCanvas=null;
        public Canvas ShapeCanvas
        {
            get;
            set;
        }

        class SpawnLine
        {

            private Line line;
            private bool First_clic = true;


            protected BitmapImage _shape_image
            {
                get;
                set;
            }
            private void set_events(Line shape)
            {
                shape.MouseRightButtonDown += Shape_Menu;
                shape.PreviewMouseLeftButtonDown += Choise_Shape;
                shape.PreviewMouseLeftButtonUp += Free_Shape;
                shape.IsEnabled = false;

            }
            public SpawnLine()
            {
                line = new Line();
            }


            #region выполнение IDraw
            public void Abort(object sender, MouseButtonEventArgs e)
            {
                if (line != null)
                {
                    _ShapeCanvas.Children.Remove(line);
                    line = null;
                    First_clic = true;


                }
            }

            public void Set(MouseEventArgs e)

            {
                Point Cursor = _window.Get_Cursor_Point(e);

                if (line == null) return;

                if (First_clic == false)
                {

                    line.X2 = Cursor.X - _window.canvas.Margin.Left;
                    line.Y2 = Cursor.Y - _window.canvas.Margin.Top;


                }
                else
                {
                    int rounding_value = (int)Math.Sqrt(Math.Pow(line.X2 - line.X1, 2) + Math.Pow(line.Y2 - line.Y1, 2)) / 5;

                    if (rounding_value > 50)
                    {
                        rounding_value = 50;
                    }

                    if (rounding_value < 4)
                    {
                        rounding_value = 4;
                    }


                    if (line.X2 - line.X1 < rounding_value && line.X2 - line.X1 > -rounding_value)
                    {
                        line.X2 = line.X1;
                    }
                    if (line.Y2 - line.Y1 < rounding_value && line.Y2 - line.Y1 > -rounding_value)
                    {
                        line.Y2 = line.Y1;
                    }

                    line = null;

                }
            }


            public void Draw(MouseButtonEventArgs e)

            {
                Point Cursor = _window.Get_Cursor_Point(e);

                if (First_clic)
                {
                    line = new Line()
                    {

                        X1 = (line == null) ? Cursor.X - _window.canvas.Margin.Left : line.X2,
                        Y1 = (line == null) ? Cursor.Y - _window.canvas.Margin.Top : line.Y2,
                        X2 = Cursor.X - _window.canvas.Margin.Left,
                        Y2 = Cursor.Y - _window.canvas.Margin.Top
                    };

                    set_events(line);
                    line.IsEnabled = false;



                    line.Stroke = new SolidColorBrush(Colors.Black);

                    line.StrokeThickness = 10;


                    _window.canvas.Children.Add(line);

                }

                First_clic = !First_clic;
            }

            #endregion

            #region выполнение ISelectable
            public void Choise_Shape(object sender, MouseButtonEventArgs e)
            {
                dragObject = sender as UIElement;
                Offset = e.GetPosition(_window.canvas);
                Offset.X -= Canvas.GetTop(dragObject);
                Offset.Y -= Canvas.GetLeft(dragObject);
                //_window.canvas.CaptureMouse();



                ((Line)dragObject).Stroke = new SolidColorBrush(Colors.Gray);
                ((Line)dragObject).StrokeThickness = 10;
                ((Line)dragObject).StrokeDashCap = PenLineCap.Round;
                ((Line)dragObject).StrokeDashArray.Add(1.5);
            }

            public void Free_Shape(object sender, MouseButtonEventArgs e)
            {
                ((Line)dragObject).StrokeThickness = 10;
                ((Line)dragObject).StrokeDashArray.Clear();
                ((Line)dragObject).Stroke = new SolidColorBrush(Colors.Black);

                dragObject = null;
                _window.canvas.ReleaseMouseCapture();
            }

            public void Canvas_MouseMove(object sender, MouseEventArgs e)
            {
                if (dragObject == null)
                    return;

                var position = e.GetPosition(sender as IInputElement);
                Canvas.SetTop(dragObject, position.Y - Offset.Y);
                Canvas.SetLeft(dragObject, position.X - Offset.X);
            }

            public void Shape_Menu(object sender, MouseButtonEventArgs e)
            {

            }
            #endregion
        }
    }
}
