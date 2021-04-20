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
        private readonly List<UIElement> object_memory = new List<UIElement>();
        private List<Border> borders = new List<Border>();
        private List<Button> buttons = new List<Button>();

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
        private void SetButtonToolbar()
        {
            buttons.Add(ButAppl);
            buttons.Add(ButBath);
            buttons.Add(ButBedroom);
            buttons.Add(ButGard);
            buttons.Add(ButInterior);
            buttons.Add(ButKitchen);
            buttons.Add(ButMainroom);
        }
        internal Point Get_Cursor_Point(MouseEventArgs e) => Mouse.GetPosition(this);


        #region Пользователь

        private void User_Button(object sender, MouseEventArgs e)
        {
            if (User_Border.Visibility == Visibility.Hidden)
                User_Border.Visibility = Visibility.Visible;
            else
                User_Border.Visibility = Visibility.Hidden;
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

            if (Avtoauthorization != null)
                Avtoauthorization.Close();

            Avtoauthorization = new EnterWindow();


            Avtoauthorization.Show();
        }

        #endregion

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

        #region Tollstrip

        private void Button_NigthDay(object sender, RoutedEventArgs e)
        {


        }
        private void Button_Next(object sender, RoutedEventArgs e)
        {
            Enable_Shapes(false);
            Remove_last_Changes();
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

            {
                object_memory.Add(canvas.Children[cnt - 1]);
                canvas.Children.RemoveAt(cnt - 1);
            }
        }
        private void Remove_last_Changes()
        {
            if (object_memory.Count > 0)
            {
                canvas.Children.Add(object_memory[object_memory.Count - 1]);
                object_memory.RemoveAt(object_memory.Count - 1);
            }
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
        private void Cancel_button(object sender, EventArgs e) => Delete_last_canvas_Obj();
        #endregion

        #region Toolbar

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
            SetButtonToolbar();
            ChangeButtonBackcolorToolbar(ButMainroom);
            SetBorder();
            ChangeBorderVisibilityToolbar(mainroom, ButMainroom);
            
        }
        private void Button_Bedroom(object sender, RoutedEventArgs e)
        {

            Enable_Shapes(false);
            ChangeButtonBackcolorToolbar(ButBedroom);
            SetBorder();
            ChangeBorderVisibilityToolbar(bedroom, ButBedroom);
        }
        private void Button_Kitchen(object sender, RoutedEventArgs e)
        {

            Enable_Shapes(false);
            ChangeButtonBackcolorToolbar(ButKitchen);
            SetBorder();
            ChangeBorderVisibilityToolbar(kitchen, ButKitchen);
        }
        private void Button_Appliances(object sender, RoutedEventArgs e)
        {

            Enable_Shapes(false);
            ChangeButtonBackcolorToolbar(ButAppl);
            SetBorder();
            ChangeBorderVisibilityToolbar(appliances, ButAppl);
        }
        private void Button_Wardrobe(object sender, RoutedEventArgs e)
        {

            Enable_Shapes(false);
            ChangeButtonBackcolorToolbar(ButGard);
            SetBorder();
            ChangeBorderVisibilityToolbar(wardrobe, ButGard);
        }
        private void Button_Bathroom(object sender, RoutedEventArgs e)
        {

            Enable_Shapes(false);
            ChangeButtonBackcolorToolbar(ButBath);
            SetBorder();
            ChangeBorderVisibilityToolbar(bathroom, ButBath);
        }
        private void Button_Interior(object sender, RoutedEventArgs e)
        {

            Enable_Shapes(false);
            ChangeButtonBackcolorToolbar(ButInterior);
            SetBorder();
            ChangeBorderVisibilityToolbar(interior, ButInterior);
        }

        private void ChangeButtonBackcolorToolbar(Button item)
        {
            ButMainroom.Background = new SolidColorBrush(Color.FromArgb(255, 166, 163, 157));
            ButBedroom.Background = new SolidColorBrush(Color.FromArgb(255, 166, 163, 157));
            ButKitchen.Background = new SolidColorBrush(Color.FromArgb(255, 166, 163, 157));
            ButAppl.Background = new SolidColorBrush(Color.FromArgb(255, 166, 163, 157));
            ButGard.Background = new SolidColorBrush(Color.FromArgb(255, 166, 163, 157));
            ButBath.Background = new SolidColorBrush(Color.FromArgb(255, 166, 163, 157));
            ButInterior.Background = new SolidColorBrush(Color.FromArgb(255, 166, 163, 157));
            item.Background = new SolidColorBrush(Color.FromArgb(255, 142, 123, 166));
        }

        #endregion



        private void ChangeBorderVisibilityToolbar(Border itemBr, Button itemBtn)
        {
            SetBorder();

            if (itemBr.Visibility == Visibility.Hidden)
                itemBr.Visibility = Visibility.Visible;
            else
                itemBr.Visibility = Visibility.Hidden;

            foreach (var i in borders.Where(x => x != itemBr))
            {
                i.Visibility = Visibility.Hidden;
            }

            if(itemBr.Visibility == Visibility.Hidden)
                itemBtn.Background = new SolidColorBrush(Color.FromArgb(255, 166, 163, 157));
        }

        private void square_table(object sender, RoutedEventArgs e)
        {
            
            a = new Draw_Square(this, 100, 100);
        }

        private void ellipse_table(object sender, RoutedEventArgs e)
        {
           
            a = new Draw_Ellipse(this, 100, 100);
        }

        private void Enable_Shapes (bool swith)
        {
            Display_Area.Cursor = Cursors.Arrow;
            var s = new Enable(canvas, swith);
        }
        private void Take_elipse (Border g) {
            Enable_Shapes(false);
            a = new Draw_Ellipse(this, 100, 100);
        }

    }
}
