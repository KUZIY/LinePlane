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

    class DrawWalls
    {


        private Line line;
        private bool First_clic = true;
        private Canvas _MainCanvas;

        internal Point Cursor
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
        public DrawWalls(Canvas value)
        {
            _MainCanvas = value;
        }


        private void Draw ()
        {
            line.X2 = Cursor.X - _MainCanvas.Margin.Left;
            line.Y2 = Cursor.Y - _MainCanvas.Margin.Top;

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

        }
        public void StartEndWall ()
        {
            if (First_clic)
            {
                line = new Line()
                {
                    X1 =  Cursor.X - _MainCanvas.Margin.Left,
                    Y1 =  Cursor.Y - _MainCanvas.Margin.Top,
                    X2 =  Cursor.X,
                    Y2 =  Cursor.Y
                };

                set_events(line);
                line.IsEnabled = false;



                line.Stroke = new SolidColorBrush(Colors.Black);
                line.StrokeThickness = 10;


                _MainCanvas.Children.Add(line);

                First_clic = false;
            }
            else
            {
                line = null;
                First_clic = true;
            }
        }
        internal void MouseMove(MouseEventArgs e)
        {
            if (line == null)
                return;

            Cursor = e.GetPosition(_MainCanvas);
            Draw();
        }

        internal bool BrakePaint()
        {
            if (line == null) return false;

            line = null;
            First_clic = true;
            return true;
        }

        public void Choise_Shape(object sender, MouseButtonEventArgs e)
        {

        }

        public void Free_Shape(object sender, MouseButtonEventArgs e)
        {

        }

        public void Shape_Menu(object sender, MouseButtonEventArgs e)
        {

        }



    }
}
