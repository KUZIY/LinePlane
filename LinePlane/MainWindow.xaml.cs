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
        public Line line;
        private bool First_clic = true;
        private RegistrationWindow Registration;
        private EnterWindow Avtoauthorization;

        private readonly List<Line> _lines = new List<Line>();
        public MainWindow()
        {
            InitializeComponent();

        }




        private void Button_registration_Click(object sender, RoutedEventArgs e)
        {
            if (Registration == null)
            {
                Registration = new RegistrationWindow();
            }
            Registration.Show();

        }

        private void Button_enter_Click(object sender, RoutedEventArgs e)
        {
            if (Avtoauthorization == null)
            {
                Avtoauthorization = new EnterWindow();
            }

            Avtoauthorization.Show();
        }


        private void SetLinePosition(MouseEventArgs e)
        {
            if(line == null) return;

            if (First_clic == false)
            {

                line.X2 = Mouse.GetPosition(this).X - canvas.Margin.Left;
                line.Y2 = Mouse.GetPosition(this).Y - canvas.Margin.Top;
                if (line.X2 - line.X1 < 10)
                {
                   
                }
            }
            else
            {
                int rounding_value = (int)Math.Sqrt(Math.Pow(line.X2 - line.X1, 2) + Math.Pow(line.Y2 - line.Y1, 2))/5;

                if (rounding_value > 50)
                {
                    rounding_value = 50;
                }

                if (rounding_value < 4)
                {
                    rounding_value = 4;
                }


                if (line.X2 - line.X1 < rounding_value && line.X2 - line.X1> -rounding_value)
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

        

        private void Canvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            if (First_clic)
            {
                line = new Line()
                {
                    X1 = (line == null) ? Mouse.GetPosition(this).X - canvas.Margin.Left : line.X2,
                    Y1 = (line == null) ? Mouse.GetPosition(this).Y - canvas.Margin.Top : line.Y2,
                    X2 = Mouse.GetPosition(this).X - canvas.Margin.Left,
                    Y2 = Mouse.GetPosition(this).Y - canvas.Margin.Top
                };

                line.Stroke = new SolidColorBrush(Colors.Black);

                line.StrokeThickness = 10;

                _lines.Add(line);
                canvas.Children.Add(line);
            }

            First_clic = !First_clic;
        }

        private void Abort_Line(object sender, MouseButtonEventArgs e)
        {
            if (line != null)
            {
                line = null;
                Delete_last_canvas_Obj();
                First_clic = true;
            }
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            SetLinePosition(e); //обновляем линию
        }

        private void User_Button(object sender, MouseEventArgs e) {
            if (User_Border.Visibility == Visibility.Hidden)
                User_Border.Visibility = Visibility.Visible;
            else
                User_Border.Visibility = Visibility.Hidden;
        }

        private void Cancel(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Control) > 0)
            {
                if (e.Key == Key.Z)
                {
                    Delete_last_canvas_Obj();
                }
            }
        }

        private void Delete_last_canvas_Obj()
        {
            int cnt = canvas.Children.Count;

            if(cnt>0)
            canvas.Children.RemoveAt(cnt - 1);
        }
        
        private void ToolBar_Button(object sender, EventArgs e)
        {
            DoubleAnimation buttonAnim = new DoubleAnimation();

           


            if (Tool_grid.Width==20)
            {
                buttonAnim.From = 20;
                buttonAnim.To = 125;
                buttonAnim.Duration = TimeSpan.FromSeconds(2);
                Tool_grid.BeginAnimation(Grid.WidthProperty, buttonAnim);
                buttonAnim.From = 0;
                buttonAnim.To = 105;
                ToolBAr_Border.BeginAnimation(Button.WidthProperty, buttonAnim);
               
            }
            else
            {
                buttonAnim.From = 125;
                buttonAnim.To = 20;
                buttonAnim.Duration = TimeSpan.FromSeconds(2);
                Tool_grid.BeginAnimation(Grid.WidthProperty, buttonAnim);

                buttonAnim.From = 105;
                buttonAnim.To = 0;
                buttonAnim.Duration = TimeSpan.FromSeconds(3);
                ToolBAr_Border.BeginAnimation(Button.WidthProperty, buttonAnim);
            }

        }
        
    }
}
