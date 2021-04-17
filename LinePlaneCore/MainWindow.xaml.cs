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
        private Draw a;

        private RegistrationWindow Registration;
        private EnterWindow Avtoauthorization;

        private readonly List<Line> _lines = new List<Line>();
        public MainWindow()
        {
            InitializeComponent();
            a = new Draw_Cursor(this);
        }

        internal Point Get_Cursor_Point(MouseEventArgs e) => Mouse.GetPosition(this);


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

        #region Прорисовка объектов
        private void SetLinePosition(MouseEventArgs e)
        {
            a.Set(e, canvas);

        }
        private void Canvas_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            a.Draw(e, canvas);

        }

        private void Abort_Paint(object sender, MouseButtonEventArgs e)
        {
            a.Abort(sender, e);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            SetLinePosition(e);
            
        }

        #endregion

        private void Cancel_button(object sender, EventArgs e) => Delete_last_canvas_Obj();

        private void User_Button(object sender, MouseEventArgs e)
        {
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

            if (cnt > 0)
                canvas.Children.RemoveAt(cnt - 1);
        }

        private void ToolBar_Button(object sender, EventArgs e)
        {
            DoubleAnimation buttonAnim = new DoubleAnimation();




            if (Tool_grid.Width == 20)
            {
                buttonAnim.From = 20;
                buttonAnim.To = 420;
                buttonAnim.Duration = TimeSpan.FromSeconds(0.2);
                Tool_grid.BeginAnimation(Grid.WidthProperty, buttonAnim);
                buttonAnim.From = 0;
                buttonAnim.To = 200;
                ToolBAr_Border.BeginAnimation(Border.WidthProperty, buttonAnim);

            }
            else
            {
                buttonAnim.From = 420;
                buttonAnim.To = 20;
                buttonAnim.Duration = TimeSpan.FromSeconds(0.2);
                Tool_grid.BeginAnimation(Grid.WidthProperty, buttonAnim);

                buttonAnim.From = 200;
                buttonAnim.To = 0;
                buttonAnim.Duration = TimeSpan.FromSeconds(0.2);
                ToolBAr_Border.BeginAnimation(Button.WidthProperty, buttonAnim);
            }

        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveimg = new Microsoft.Win32.SaveFileDialog();



            saveimg.Filter = "(.PNG)|*.PNG|(.JPEG)|*.JPEG ; *.jpg|(.BMP)|*.bmp" +
                "|All Files|*.*";

            saveimg.DefaultExt = saveimg.Filter;

            if (saveimg.ShowDialog() == true)
            {
                ToImageSource(canvas, saveimg.FileName);
            }
        }
        public static void ToImageSource(Canvas canvas, string filename)
        {
            RenderTargetBitmap bmp = new RenderTargetBitmap((int)canvas.ActualWidth, (int)canvas.ActualHeight, 96d, 96d, PixelFormats.Pbgra32);

            canvas.Measure(new Size((int)canvas.ActualWidth, (int)canvas.ActualHeight));
            canvas.Arrange(new Rect(new Size((int)canvas.ActualWidth, (int)canvas.ActualHeight)));

            bmp.Render(canvas);

            PngBitmapEncoder encoder = new PngBitmapEncoder();

            encoder.Frames.Add(BitmapFrame.Create(bmp));

            using (FileStream file = File.Create(filename))
            {
                encoder.Save(file);
            }
        }
        private void Button_NigthDay(object sender, RoutedEventArgs e)
        {

        }


        private void Button_Next(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Cursor(object sender, RoutedEventArgs e)
        {
            a = new Draw_Cursor(this);
            Display_Area.Cursor = Cursors.Arrow;
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            a = new Draw_Line(this);
            Display_Area.Cursor = Cursors.Cross;
        }

        private void Button_Hand(object sender, RoutedEventArgs e)
        {
            a = new Draw_Square(this,3);
            Display_Area.Cursor = Cursors.Hand;
        }
    }
}
