using LinePlaneCore.Control.Commands;
using LinePlaneCore.Logic;
using LinePlaneCore.Manger;
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
using System.IO;
using System.Windows.Media.Imaging;
using System.Reflection;

namespace LinePlaneCore.Control
{
    internal class MainWindowShell : Base
    {
        #region Cursor
        private Cursor _WindowCursor = Cursors.Arrow;
        public Cursor WindowCursor
        {
            get => _WindowCursor;
            set => Set(ref _WindowCursor, value);
        }
        #endregion

        #region UserButton
        private Visibility _UserButton = Visibility.Hidden;

        /// <summary>
        /// UserButtonClick
        /// </summary>
        public Visibility UserButton
        {
            get => _UserButton;
            set => Set(ref _UserButton, value);
        }

        #endregion

        #region CanvasData
        private Canvas _MainCanvas;

        private DrawWalls _Wall = null;

        private DrawWalls Wall
        {
            get => _Wall;
            set
            {
                _Wall = value;
                Move.Wall = value;
            }
        }

        #region прорисовка мебели
        private static UIElement _MoveShapeObj = null;
        static internal void TakeShape(UIElement value) 
        {
            _MoveShapeObj = value;
            if (value == null) Move.ArgsClear();
        }
        #endregion

        public Canvas MainCanvas
        {
            get => _MainCanvas;
            set 
            {
                Set(ref _MainCanvas, value);
                Move.canvas = value;
            }
        }

        private List<UIElement> ShapeMemory = new List<UIElement>();
        #endregion

        #region Toolbar Background

        Brush _MainroomBrush = Brushes.Transparent;
        Brush _BedroomBrush = Brushes.Transparent;
        Brush _KitchenBrush = Brushes.Transparent;
        Brush _ApplBrush = Brushes.Transparent;
        Brush _GarderobeBrush = Brushes.Transparent;
        Brush _BathBrush = Brushes.Transparent;
        Brush _InteriorBrush = Brushes.Transparent;


        #region привязка цветов

        private void SetTransparentBrush()
        {
            MainroomBrush = Brushes.Transparent;
            BedroomBrush = Brushes.Transparent;
            KitchenBrush = Brushes.Transparent;
            ApplBrush = Brushes.Transparent;
            GarderobeBrush = Brushes.Transparent;
            BathBrush = Brushes.Transparent;
            InteriorBrush = Brushes.Transparent;

        }
        private Brush ChangeColor(Brush value)
        {
            SetTransparentBrush();
            if (value == Brushes.Transparent) return (Brush)(new BrushConverter().ConvertFrom("#77673AB7"));
            else return Brushes.Transparent;
        }

         public Brush MainroomBrush
        {
            get => _MainroomBrush;
            set => Set(ref _MainroomBrush, value);
        }

        public Brush BedroomBrush
        {
            get => _BedroomBrush;
            set => Set(ref _BedroomBrush, value);
        }

        public Brush KitchenBrush
        {
            get => _KitchenBrush;
            set => Set(ref _KitchenBrush, value);
        }

        public Brush ApplBrush
        {
            get => _ApplBrush;
            set => Set(ref _ApplBrush, value);
        }

        public Brush GarderobeBrush
        {
            get => _GarderobeBrush;
            set => Set(ref _GarderobeBrush, value);
        }

        public Brush BathBrush
        {
            get => _BathBrush;
            set => Set(ref _BathBrush, value);
        }

        public Brush InteriorBrush
        {
            get => _InteriorBrush;
            set => Set(ref _InteriorBrush, value);
        }
        #endregion
        #endregion

        #region Toolbar Border Visibility

        Visibility _MainroomBoder = Visibility.Hidden;
        Visibility _BedroomBoder = Visibility.Hidden;
        Visibility _KitchenBoder = Visibility.Hidden;
        Visibility _ApplBoder = Visibility.Hidden;
        Visibility _GarderobeBoder = Visibility.Hidden;
        Visibility _BathBoder = Visibility.Hidden;
        Visibility _InteriorBoder = Visibility.Hidden;

        private void ReshowBorders()
        {
            MainroomBoder = Visibility.Hidden;
            BedroomBoder = Visibility.Hidden;
            KitchenBoder = Visibility.Hidden;
            ApplBoder = Visibility.Hidden;
            GarderobeBoder = Visibility.Hidden;
            BathBoder = Visibility.Hidden;
            InteriorBoder = Visibility.Hidden;

            if (_MainroomBrush != Brushes.Transparent) MainroomBoder = Visibility.Visible;
            if (_BedroomBrush != Brushes.Transparent) BedroomBoder = Visibility.Visible;
            if (_KitchenBrush != Brushes.Transparent) KitchenBoder = Visibility.Visible;
            if (_ApplBrush != Brushes.Transparent) ApplBoder = Visibility.Visible;
            if (_GarderobeBrush != Brushes.Transparent) GarderobeBoder = Visibility.Visible;
            if (_BathBrush != Brushes.Transparent) BathBoder = Visibility.Visible;
            if (_InteriorBrush != Brushes.Transparent) InteriorBoder = Visibility.Visible;
        }

        public Visibility MainroomBoder
        {
            get => _MainroomBoder;
            set => Set(ref _MainroomBoder, value);
        }

        public Visibility BedroomBoder
        {
            get => _BedroomBoder;
            set => Set(ref _BedroomBoder, value);
        }

        public Visibility KitchenBoder
        {
            get => _KitchenBoder;
            set => Set(ref _KitchenBoder, value);
        }

        public Visibility ApplBoder
        {
            get => _ApplBoder;
            set => Set(ref _ApplBoder, value);
        }

        public Visibility GarderobeBoder
        {
            get => _GarderobeBoder;
            set => Set(ref _GarderobeBoder, value);
        }

        public Visibility BathBoder
        {
            get => _BathBoder;
            set => Set(ref _BathBoder, value);
        }

        public Visibility InteriorBoder
        {
            get => _InteriorBoder;
            set => Set(ref _InteriorBoder, value);
        }
        #endregion

        #region border Save
        private Visibility _SaveBorder = Visibility.Hidden;
        public Visibility SaveBorder
        {
            get => _SaveBorder;
            set => Set(ref _SaveBorder, value);
        }
        #endregion

        #region Команды

        #region User Interactions
        #region команда кнопки User
        public ICommand ShowUserPanelCommand { get; }

        private void OnShowUserPanelCommandExecuted(object p)
        {
            if (_UserButton == Visibility.Hidden) UserButton = Visibility.Visible;
            else UserButton = Visibility.Hidden;
        }

        private bool CanShowUserPanelCommandExecuted(object p) => true;
        #endregion

        #region команда перердачи Canvas
        public ICommand CanvasTransportCommand { get; }

        private void OnCanvasTransportCommandExecuted(object p)
        {
            MainCanvas =(System.Windows.Controls.Canvas) p;
        }

        private bool CanCanvasTransportCommandExecuted(object p) => true;
        #endregion

        #region команды следующее\пердидущее действие

        public ICommand DeleteLastCanvasObjCmommand { get; }

        private void OnDeleteLastCanvasObjExecuted(object p)
        {
            int cnt = _MainCanvas.Children.Count;
            ShapeMemory.Add(_MainCanvas.Children[cnt - 1]);
            _MainCanvas.Children.RemoveAt(cnt - 1);

        }

        private bool CanDeleteLastCanvasObjExecuted(object p) 
        {
            if (_MainCanvas.Children.Count > 0) return true;
            else return false;
        }



        public ICommand BackDeleteCanvasObjCmommand { get; }

        private void OnBackDeleteCanvasObjExecuted(object p)
        {
            _MainCanvas.Children.Add(ShapeMemory[ShapeMemory.Count - 1]);
            ShapeMemory.RemoveAt(ShapeMemory.Count - 1);

        }

        private bool CanBackDeleteCanvasObjExecuted(object p)
        {
            if (ShapeMemory.Count > 0) return true;
            else return false;
        }


        #endregion

        #endregion

        #region команда кнопки Save

        public ICommand SaveCommand { get; }

        private void OnSaveCommandExecuted(object p)
        {
            Microsoft.Win32.SaveFileDialog saveimg = new Microsoft.Win32.SaveFileDialog();



            saveimg.Filter = "(.PNG)|*.PNG|(.JPEG)|*.JPEG ; *.jpg|(.BMP)|*.bmp" +
                "|All Files|*.*";

            saveimg.DefaultExt = saveimg.Filter;

            if (saveimg.ShowDialog() == true)
            {
                LinePlaneCore.Logic.SaveCanvasAsImage.Save(_MainCanvas, saveimg.FileName);
            }
        }

        private bool CanSaveCommandExecuted(object p) => true;

        #endregion

        #region Рисование объектов

        #region команда спавна примитива

        public ICommand SpawnShapeCommand { get; }

        private void OnSpawnShapeCommandExecuted(object p)
        {
            (string ,Point,string)parametrs = ShapeManager.SearchShape(p as string);

            var Shape=new FrameworkElement();

            BitmapImage Image = null;
            var dir = AppDomain.CurrentDomain.BaseDirectory;
            dir = dir.Remove(dir.IndexOf("\\bin\\Debug\\net5.0-windows")) + parametrs.Item3;

            try
            {
                 Image = new BitmapImage(new Uri(dir, UriKind.RelativeOrAbsolute));
            }
            catch
            {
                Image = null;
            }


            if (parametrs.Item1 == null)
            {
                var Square = new Logic.SpawnShape.Draw_Square(30, 30);
                Shape = Square.shape;
            }
            else
            {
                if (parametrs.Item1.ToLower() == "square")
                {
                    var Square = new Logic.SpawnShape.Draw_Square(parametrs.Item2.X, parametrs.Item2.Y, Image);
                    Shape = Square.shape;
                }
                else if (parametrs.Item1.ToLower() == "ellipse")
                {
                    var Ellipse = new Logic.SpawnShape.Draw_Ellipse(parametrs.Item2.X, parametrs.Item2.Y, Image);
                    Shape = Ellipse.shape;
                }
            }


            _MainCanvas.Children.Add(Shape);
            Move.dragObject = Shape;

        }

        private bool CanSpawnShapeCommandExecuted(object p) => true;

        #endregion

        #region команда выставление\взятие обЪекта
        public ICommand InteractShapeCommand { get; }

        private void OnInteractShapeCommandExecuted(object p)
        {
            if (_MoveShapeObj == null)Move.ArgsClear();
            else Move.dragObject = _MoveShapeObj;
            if (Wall != null) { Wall.StartEndWall(); }
        }

        private bool CanInteractShapeCommandExecuted(object p) => true;
        #endregion

        #region Команда прервания рисования предмета

        public ICommand CancelShapeCommand { get; }

        private void OnCancelShapeCommandExecuted(object p)
        {
            if (_MoveShapeObj == null && Move.dragObject!=null)
            {
                Move.ArgsClear();
                OnDeleteLastCanvasObjExecuted(null);
            }
            if (Wall != null)
            {
                if (Wall.BrakePaint())
                {
                    OnDeleteLastCanvasObjExecuted(null);
                }
            }
        }

        private bool CanCancelShapeCommandExecuted(object p) => true;

        #endregion

        #endregion

        #region команды кнопок Toolbar
        public ICommand EventButtonCommand { get; }

        private void OnEventButtonCommandExecuted(object p)
        {
            SwitchStateShapes.ChangeShapeState(_MainCanvas,false);
            WindowCursor = Cursors.Arrow;
            Wall = null;

            switch (p as string)
            {
                case "Arrow": { break; }
                case "Hand": { SetTransparentBrush(); SwitchStateShapes.ChangeShapeState(_MainCanvas, true); WindowCursor = Cursors.SizeAll; break; }
                case "Edit": { SetTransparentBrush(); Wall = new DrawWalls(_MainCanvas); WindowCursor = Cursors.Cross; break; }
                case "Mainroom": { MainroomBrush=ChangeColor(MainroomBrush) ; break; }
                case "Bedroom": { BedroomBrush = ChangeColor(BedroomBrush); break; }
                case "Kitchen": { KitchenBrush = ChangeColor(KitchenBrush); break; }
                case "Appl": { ApplBrush = ChangeColor(ApplBrush); break; }
                case "Garderobe": { GarderobeBrush = ChangeColor(GarderobeBrush); break; }
                case "Bath": { BathBrush = ChangeColor(BathBrush); break; }
                case "Interior": { InteriorBrush = ChangeColor(InteriorBrush); break; }
            }

            ReshowBorders();
        }

        private bool CanEventButtonCommandExecuted(object p) => true;
        #endregion

        #region команда кнопки Save
        public ICommand SaveButtonCommand { get; }

        private void OnSaveButtonCommandExecuted(object p)
        {
            if (SaveBorder == Visibility.Hidden) SaveBorder = Visibility.Visible;
            else SaveBorder = Visibility.Hidden;
        }

        private bool CanSaveButtonCommandExecuted(object p) => true;
        #endregion

        #endregion

        public MainWindowShell()
        {
            #region Canvas Control Command
            CanvasTransportCommand = new ActionCommand(OnCanvasTransportCommandExecuted, CanCanvasTransportCommandExecuted);
            DeleteLastCanvasObjCmommand = new ActionCommand(OnDeleteLastCanvasObjExecuted, CanDeleteLastCanvasObjExecuted);
            BackDeleteCanvasObjCmommand = new ActionCommand(OnBackDeleteCanvasObjExecuted, CanBackDeleteCanvasObjExecuted);
            SaveButtonCommand = new ActionCommand(OnSaveButtonCommandExecuted, CanSaveButtonCommandExecuted);
            #endregion

            #region команда для кнопки User
            ShowUserPanelCommand = new ActionCommand(OnShowUserPanelCommandExecuted, CanShowUserPanelCommandExecuted);
            #endregion

            #region команда кнопки Save
            SaveCommand = new ActionCommand(OnSaveCommandExecuted, CanSaveCommandExecuted);
            #endregion

            #region Команды для рисования объектов
            SpawnShapeCommand = new ActionCommand(OnSpawnShapeCommandExecuted, CanSpawnShapeCommandExecuted);
            InteractShapeCommand = new ActionCommand(OnInteractShapeCommandExecuted, CanInteractShapeCommandExecuted);
            CancelShapeCommand = new ActionCommand(OnCancelShapeCommandExecuted, CanCancelShapeCommandExecuted);

            EventButtonCommand = new ActionCommand(OnEventButtonCommandExecuted, CanEventButtonCommandExecuted);
            #endregion
        }

    }
}
