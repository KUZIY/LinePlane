using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace LinePlane
{
    internal interface Draw
    {
        void Abort(object sender, MouseButtonEventArgs e);
        void Draw(MouseButtonEventArgs e, System.Windows.Controls.Panel canvas);
        void Set(MouseEventArgs e,System.Windows.Controls.Panel canvas);
    }

    internal sealed class Draw_Line : Draw
    {
        
        private MainWindow window;

        private Line line;
        private bool First_clic = true;


         public Draw_Line (MainWindow _window)
        {
            window = _window;
        }


        public void Abort (object sender, MouseButtonEventArgs e)
        {
            if (line != null)
            {
                line = null;
                First_clic = true;
            }
        }

        public void Set( MouseEventArgs e, System.Windows.Controls.Panel canvas)
        {
            Point Cursor = window.Get_Cursor_Point(e);

            if (line == null) return;

            if (First_clic == false)
            {

                line.X2 = Cursor.X - canvas.Margin.Left;
                line.Y2 = Cursor.Y - canvas.Margin.Top;
                if (line.X2 - line.X1 < 10)
                {

                }
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

        public void Draw( MouseButtonEventArgs e, System.Windows.Controls.Panel canvas)
        {
            Point Cursor = window.Get_Cursor_Point(e);

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

                //_lines.Add(line);
                canvas.Children.Add(line);
            }

            First_clic = !First_clic;
        }
    }

    internal sealed class Draw_Cursor: Draw
    {
        public Draw_Cursor(MainWindow window) { }

        public void Abort(object sender, MouseButtonEventArgs e) { }
        public void Set(MouseEventArgs e, System.Windows.Controls.Panel canvas) { }
        public void Draw(MouseButtonEventArgs e, System.Windows.Controls.Panel canvas) { }
    }
}
