using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LinePlaneCore
{
    internal interface Draw
    {
        void Abort(object sender, MouseButtonEventArgs e);
        void Draw(MouseButtonEventArgs e, System.Windows.Controls.Panel canvas);
        void Set(MouseEventArgs e, System.Windows.Controls.Panel canvas);
    }

    internal sealed class Draw_Line : Draw
    {

        private MainWindow _window;

        private Line line;
        private bool First_clic = true;


        public Draw_Line(MainWindow window)
        {
            _window = window;
        }


        public void Abort(object sender, MouseButtonEventArgs e)
        {
            if (line != null)
            {
                _window.canvas.Children.Remove(line);
                line = null;
                First_clic = true;
              
            }
        }

        public void Set(MouseEventArgs e, System.Windows.Controls.Panel canvas)
        {
            Point Cursor = _window.Get_Cursor_Point(e);

            if (line == null) return;

            if (First_clic == false)
            {

                line.X2 = Cursor.X - canvas.Margin.Left;
                line.Y2 = Cursor.Y - canvas.Margin.Top;
               
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

        public void Draw(MouseButtonEventArgs e, System.Windows.Controls.Panel canvas)
        {
            Point Cursor = _window.Get_Cursor_Point(e);

            if (First_clic)
            {
                line = new Line()
                {
                    X1 = (line == null) ? Cursor.X - canvas.Margin.Left : line.X2,
                    Y1 = (line == null) ? Cursor.Y - canvas.Margin.Top : line.Y2,
                    X2 = Cursor.X - canvas.Margin.Left,
                    Y2 = Cursor.Y - canvas.Margin.Top
                };

                line.Stroke = new SolidColorBrush(Colors.Black);

                line.StrokeThickness = 10;

                canvas.Children.Add(line);
            }

            First_clic = !First_clic;
        }
    }

    internal sealed class Draw_Cursor : Draw
    {
        public Draw_Cursor(MainWindow window) { }

        public void Abort(object sender, MouseButtonEventArgs e) { }
        public void Set(MouseEventArgs e, System.Windows.Controls.Panel canvas) { }
        public void Draw(MouseButtonEventArgs e, System.Windows.Controls.Panel canvas) { }
    }

    internal class Draw_Square:Draw {

        private MainWindow _window;
        private double widith;
        private double height;
        private Rectangle shape;


        public Draw_Square(MainWindow window, int size) {

            _window = window;

        switch (size)
            {
                case 1:
                    {
                        widith = 100;
                        height = 100;
                        break;
                    }

                case 2:
                    {
                        widith = 200;
                        height = 200;
                        break;
                    }

                case 3:
                    {
                        widith = 300;
                        height = 300;
                        break;
                    }

            }

            shape = new Rectangle();

            shape.Height = height;
            shape.Width = widith;
            var brash = new BrushConverter();
           

            shape.Fill = (Brush)brash.ConvertFrom("#CC000000");

            window.canvas.Children.Add(shape);
        }

        public void Abort(object sender, MouseButtonEventArgs e)
        {
            _window.canvas.Children.Remove(shape);
            shape = null;
        }

        public void Set(MouseEventArgs e, System.Windows.Controls.Panel canvas) {

            Point Cursor = _window.Get_Cursor_Point(e);


            if (shape == null) return;

            Canvas.SetLeft (shape, Cursor.X - canvas.Margin.Left - widith/2);
            Canvas.SetTop (shape, Cursor.Y - canvas.Margin.Top - height/2);

            

        }
        public void Draw(MouseButtonEventArgs e, System.Windows.Controls.Panel canvas) {

            if (shape != null)
            shape.Fill = new SolidColorBrush(Colors.Black);

            shape = null;
        }



    }
}