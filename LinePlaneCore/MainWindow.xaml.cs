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
            //Show_Ander_Strip.Show_button_strip_menu(this);
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
        #region mainroom
        private void Button_Mainroom(object sender, RoutedEventArgs e)
        {
            Enable_Shapes(false);
            SetButtonToolbar();
            ChangeButtonBackcolorToolbar(ButMainroom);
            SetBorder();
            ChangeBorderVisibilityToolbar(mainroom, ButMainroom);
            
        }
        private void sofa2(object sender, RoutedEventArgs e)
        {
           (double,double)size = SearchDBClass.Search_in_DB("Hall", "sofa2");
            square(size.Item1, size.Item2);
        }
        private void sofa3(object sender, RoutedEventArgs e)
        {
            (double, double) size = SearchDBClass.Search_in_DB("Hall", "sofa3");
            square(size.Item1, size.Item2);
        }
        private void sofacorner(object sender, RoutedEventArgs e)
        {
            (double, double) size = SearchDBClass.Search_in_DB("Hall", "SofaAngle");
            square(size.Item1, size.Item2);
        }
        private void armchar(object sender, RoutedEventArgs e)
        {
            (double, double) size = SearchDBClass.Search_in_DB("Hall", "Armchair");
            square(size.Item1, size.Item2);
        }
        private void coffeetable(object sender, RoutedEventArgs e)
        {
            (double, double) size = SearchDBClass.Search_in_DB("Hall", "Bookcase");
            square(size.Item1, size.Item2);
        }
        private void TVstand(object sender, RoutedEventArgs e)
        {
            (double, double) size = SearchDBClass.Search_in_DB("Hall", "TV stand");
            square(size.Item1, size.Item2);
        }
        private void desctop(object sender, RoutedEventArgs e)
        {
            (double, double) size = SearchDBClass.Search_in_DB("Hall", "Desktop");
            square(size.Item1, size.Item2);
        }
        private void officechair(object sender, RoutedEventArgs e)
        {
            (double, double) size = SearchDBClass.Search_in_DB("Hall", "Office chair");
            ellipse(size.Item1, size.Item2);
        }
        #endregion

        #region bedroom
        private void Button_Bedroom(object sender, RoutedEventArgs e)
        {

            Enable_Shapes(false);
            ChangeButtonBackcolorToolbar(ButBedroom);
            SetBorder();
            ChangeBorderVisibilityToolbar(bedroom, ButBedroom);
        }
        private void bed1(object sender, RoutedEventArgs e)
        {

        }
        private void bed2(object sender, RoutedEventArgs e)
        {

        }
        private void bedsidetable(object sender, RoutedEventArgs e)
        {

        }
        private void cosmetictable(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region kitchen
        private void Button_Kitchen(object sender, RoutedEventArgs e)
        {

            Enable_Shapes(false);
            ChangeButtonBackcolorToolbar(ButKitchen);
            SetBorder();
            ChangeBorderVisibilityToolbar(kitchen, ButKitchen);
        }
        private void kitchencabinet(object sender, RoutedEventArgs e)
        {

        }
        private void cabinetwithsink(object sender, RoutedEventArgs e)
        {

        }
        private void squaretable(object sender, RoutedEventArgs e)
        {

        }
        private void rectangulartable(object sender, RoutedEventArgs e)
        {

        }
        private void roundtable(object sender, RoutedEventArgs e)
        {

        }
        private void chair(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region appliances
        private void Button_Appliances(object sender, RoutedEventArgs e)
        {

            Enable_Shapes(false);
            ChangeButtonBackcolorToolbar(ButAppl);
            SetBorder();
            ChangeBorderVisibilityToolbar(appliances, ButAppl);
        }
        private void TV(object sender, RoutedEventArgs e)
        {

        }
        private void freezer1(object sender, RoutedEventArgs e)
        {

        }
        private void freezer2(object sender, RoutedEventArgs e)
        {

        }
        private void stove(object sender, RoutedEventArgs e)
        {

        }
        private void washingmashing(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region wardrobe
        private void Button_Wardrobe(object sender, RoutedEventArgs e)
        {

            Enable_Shapes(false);
            ChangeButtonBackcolorToolbar(ButGard);
            SetBorder();
            ChangeBorderVisibilityToolbar(wardrobe, ButGard);
        }
        private void wardrobe1(object sender, RoutedEventArgs e)
        {

        }
        private void wardrobekype(object sender, RoutedEventArgs e)
        {

        }
        private void bookswardrobe(object sender, RoutedEventArgs e)
        {

        }
        private void sideboard(object sender, RoutedEventArgs e)
        {

        }
        private void shoespedestal(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region bathroom
        private void Button_Bathroom(object sender, RoutedEventArgs e)
        {

            Enable_Shapes(false);
            ChangeButtonBackcolorToolbar(ButBath);
            SetBorder();
            ChangeBorderVisibilityToolbar(bathroom, ButBath);
        }
        private void sinq(object sender, RoutedEventArgs e)
        {

        }
        private void bath(object sender, RoutedEventArgs e)
        {

        }
        private void shower(object sender, RoutedEventArgs e)
        {

        }
        private void toilet(object sender, RoutedEventArgs e)
        {

        }
        private void hottub(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region interior
        private void Button_Interior(object sender, RoutedEventArgs e)
        {

            Enable_Shapes(false);
            ChangeButtonBackcolorToolbar(ButInterior);
            SetBorder();
            ChangeBorderVisibilityToolbar(interior, ButInterior);
        }
        private void mirror(object sender, RoutedEventArgs e)
        {

        }
        private void plant(object sender, RoutedEventArgs e)
        {

        }
        private void fireplace(object sender, RoutedEventArgs e)
        {

        }
        private void ikonostas(object sender, RoutedEventArgs e)
        {

        }
        private void aquarium(object sender, RoutedEventArgs e)
        {

        }
        private void piano(object sender, RoutedEventArgs e)
        {

        }
        #endregion
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

        private void square(double widith, double height)
        {
            
            a = new Draw_Square(this, widith, height);
        }

        private void ellipse(double widith, double height)
        {
           
            a = new Draw_Ellipse(this, widith, height);
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
