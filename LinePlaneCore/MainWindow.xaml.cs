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

        private RegistrationWindow Registration;
        private EnterWindow Avtoauthorization;

        private readonly List<Line> _lines = new List<Line>();


        private List<Border> borders = new List<Border>();



        public MainWindow()
        {
            InitializeComponent();
            a =null;
        }


        private void SetBorder()
        {
            borders.Add(mainroom);
            borders.Add(kitchen);
            borders.Add(bathroom);
            borders.Add(wardrobe);
            borders.Add(interior);
            borders.Add(appliances);
            borders.Add(bedroom);
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

            if (Avtoauthorization!=null)
                Avtoauthorization.Close();

                Avtoauthorization = new EnterWindow();


            Avtoauthorization.Show();
        }

        #region Прорисовка объектов
        private void SetLinePosition(MouseEventArgs e)
        {
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
        private void Button_Save(object sender, RoutedEventArgs e)
        {
            Enable_Shapes(false);

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
            Enable_Shapes(false);
        }

        private void Button_Cursor(object sender, RoutedEventArgs e)
        {
            Enable_Shapes(false);
            a = null;
            Display_Area.Cursor = Cursors.Arrow;
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            Enable_Shapes(false);
            a = new Draw_Line(this);
            Display_Area.Cursor = Cursors.Cross;
        }

        private void Button_Hand(object sender, RoutedEventArgs e)
        {
            Enable_Shapes(true);
            Display_Area.Cursor = Cursors.SizeAll;
            a = null;
           
        }

        private void Button_Mainroom(object sender, RoutedEventArgs e)
        {
            Enable_Shapes(false);
            SetBorder();
            Button_Room(mainroom);
        }

        private void Button_Bedroom(object sender, RoutedEventArgs e)
        {
            Enable_Shapes(false);
            SetBorder();
            Button_Room(bedroom);
        }

        private void Button_Kitchen(object sender, RoutedEventArgs e)
        {
            Enable_Shapes(false);
            SetBorder();
            Button_Room(kitchen);
        }

        private void Button_Appliances(object sender, RoutedEventArgs e)
        {
            Enable_Shapes(false);
            SetBorder();
            Button_Room(appliances);
        }

        private void Button_Wardrobe(object sender, RoutedEventArgs e)
        {
            Enable_Shapes(false);
            SetBorder();
            Button_Room(wardrobe);
        }

        private void Button_Bathroom(object sender, RoutedEventArgs e)
        {
            Enable_Shapes(false);
            SetBorder();
            Button_Room(bathroom);
        }

        private void Button_Interior(object sender, RoutedEventArgs e)
        {
            Enable_Shapes(false);
            SetBorder();
            Button_Room(interior);
        }

        private void Button_Room(Border item)
        {
            SetBorder();

            if (item.Visibility == Visibility.Hidden)
                item.Visibility = Visibility.Visible;
            else
                item.Visibility = Visibility.Hidden;

            foreach (var i in borders.Where(x => x != item))
            {
                i.Visibility = Visibility.Hidden;
            }
        }

        private void square_table(object sender, RoutedEventArgs e)
        {
            Enable_Shapes(false);
            a = new Draw_Square(this, 100, 100);
        }

        private void ellipse_table(object sender, RoutedEventArgs e)
        {
            Enable_Shapes(false);
            a = new Draw_Ellipse(this, 100, 100);
        }

        private void Enable_Shapes (bool swith)
        {
            Display_Area.Cursor = Cursors.Arrow;
            var s = new Enable(canvas, swith);
        }

    }
}
