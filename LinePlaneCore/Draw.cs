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

    internal interface IDraw
    {
        void Abort(object sender, MouseButtonEventArgs e);
        void Draw(MouseButtonEventArgs e);
        void Set(MouseEventArgs e);

    }

    internal interface ISelectable
    {
        void Shape_Menu(object sender, MouseButtonEventArgs e);
        void Choise_Shape(object sender, MouseButtonEventArgs e);
        void Free_Shape(object sender, MouseButtonEventArgs e);
    }

    abstract internal class Shape {

        protected MainWindow _window;
        protected Point Offset;
        protected UIElement dragObject;

        abstract protected Image _shape_image
        {
            get;
            set;
        }

        protected Shape(MainWindow window)
        {
            _window = window;
        }
    }

    internal sealed class Draw_Line : Shape, IDraw, ISelectable
    {

        private Line line;
        private bool First_clic = true;

        override protected Image _shape_image
        {
            get { return null; }
            set { }
        }
        private void set_events(Line shape)
        {
            shape.MouseRightButtonDown += Shape_Menu;
            shape.PreviewMouseLeftButtonDown += Choise_Shape;
            shape.PreviewMouseLeftButtonUp += Free_Shape;
            shape.IsEnabled = false;
        }
        public Draw_Line(MainWindow window) : base(window) {
            line = new Line();

        }


        #region выполнение IDraw

        public void Abort(object sender, MouseButtonEventArgs e)
        {
            if (line != null)
            {
                _window.canvas.Children.Remove(line);
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

    internal sealed class Draw_Cursor : Shape, IDraw
    {
        override protected Image _shape_image
        {
            get { return null; }
            set { }
        }
        public Draw_Cursor(MainWindow window) : base(window) { }

        #region заглущки для IDraw
        public void Abort(object sender, MouseButtonEventArgs e) { }
        public void Set(MouseEventArgs e) { }
        public void Draw(MouseButtonEventArgs e) { }
        #endregion
    }

    internal class Draw_Square : Shape, IDraw, ISelectable
    {

        private Rectangle shape;
        override protected Image _shape_image
        {
            get;
            set;
        }
        private void set_events(Rectangle shape)
        {
            //shape.MouseRightButtonDown += Shape_Menu;
            shape.PreviewMouseLeftButtonDown += Choise_Shape;
            shape.PreviewMouseLeftButtonUp += Free_Shape;
            shape.IsEnabled = false;
        }

        #region конструкторы
        public Draw_Square(MainWindow window, double widith, double height) : base(window) {

            shape = new Rectangle();

            set_events(shape);

            shape.Height = height;
            shape.Width = widith;
            var brash = new BrushConverter();
            shape.Fill = (Brush)brash.ConvertFrom("#CC000000");

            window.canvas.Children.Add(shape);
        }
        public Draw_Square(MainWindow window, double widith, double height, Image _shape_png) : base(window)
        {

            shape = new Rectangle();

            set_events(shape);

            _shape_image = _shape_png;


            shape.Height = height;
            shape.Width = widith;
            var brash = new BrushConverter();


            shape.Fill = (Brush)brash.ConvertFrom("#CC000000");

            window.canvas.Children.Add(shape);
        }

        #endregion

        #region исполнение IDrow

        public void Abort(object sender, MouseButtonEventArgs e)
        {
            _window.canvas.Children.Remove(shape);
            shape = null;
        }

        public void Set(MouseEventArgs e) {


            Point Cursor = _window.Get_Cursor_Point(e);


            if (shape == null) return;


            Canvas.SetLeft(shape, Cursor.X - _window.canvas.Margin.Left - shape.Width / 2);
            Canvas.SetTop(shape, Cursor.Y - _window.canvas.Margin.Top - shape.Height / 2);

        }
        public void Draw(MouseButtonEventArgs e) {

            if (shape != null)

                shape.Fill = new SolidColorBrush(Colors.Black);

            shape = null;
        }
        #endregion

        #region исполнение ISelectable
        public void Choise_Shape(object sender, MouseButtonEventArgs e)

        {
            dragObject = sender as UIElement;
            Offset = e.GetPosition(_window.canvas);
            Offset.X -= Canvas.GetTop(dragObject);

            Offset.Y -= Canvas.GetLeft(dragObject);
            //_window.canvas.CaptureMouse();



            ((Rectangle)dragObject).Stroke = new SolidColorBrush(Colors.Gray);
            ((Rectangle)dragObject).StrokeThickness = 6;
            ((Rectangle)dragObject).StrokeDashCap = PenLineCap.Round;
            ((Rectangle)dragObject).StrokeDashArray.Add(2);
        }

        public void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragObject == null)
                return;

            var position = e.GetPosition(sender as IInputElement);
            Canvas.SetTop(dragObject, position.Y - Offset.Y);
            Canvas.SetLeft(dragObject, position.X - Offset.X);
        }
        public void Free_Shape(object sender, MouseButtonEventArgs e)
        {
            ((Rectangle)dragObject).StrokeThickness = 0;
            dragObject = null;
            _window.canvas.ReleaseMouseCapture();
        }

        public void Shape_Menu(object sender, MouseButtonEventArgs e)
        {

        }
        #endregion

    }



    internal class Enable
    {
        public Enable(Panel canvas, bool selector)
        {
            for (int i = 0; i < canvas.Children.Count; ++i)
            {
                    var s = canvas.Children[i];
                    s.IsEnabled = selector;
            }
        }
    }


}