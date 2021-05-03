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

        private void CanvasLeftMouseClickDown(object sender, MouseEventArgs e) { }
        private void CanvasLeftMouseClickUp(object sender, MouseEventArgs e) { }
        private void CanvasRightMouseClick(object sender, MouseEventArgs e) { }
        private void CanvasDragMouse(object sender, MouseEventArgs e) { }


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
        #endregion

        #region bedroom
        private void Button_Bedroom(object sender, RoutedEventArgs e)
        {

            Enable_Shapes(false);
            ChangeButtonBackcolorToolbar(ButBedroom);
            SetBorder();
            ChangeBorderVisibilityToolbar(bedroom, ButBedroom);
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
        #endregion

        #region appliances
        private void Button_Appliances(object sender, RoutedEventArgs e)
        {

            Enable_Shapes(false);
            ChangeButtonBackcolorToolbar(ButAppl);
            SetBorder();
            ChangeBorderVisibilityToolbar(appliances, ButAppl);
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
        #endregion

        #region bathroom
        private void Button_Bathroom(object sender, RoutedEventArgs e)
        {

            Enable_Shapes(false);
            ChangeButtonBackcolorToolbar(ButBath);
            SetBorder();
            ChangeBorderVisibilityToolbar(bathroom, ButBath);
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
        #endregion
        private void ChangeButtonBackcolorToolbar(Button item)
        {
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

            if (itemBr.Visibility == Visibility.Hidden) ;
        }

        private void Enable_Shapes (bool swith)
        {
            Display_Area.Cursor = Cursors.Arrow;
            var s = new Enable(canvas, swith);
        }
       

    }
}
