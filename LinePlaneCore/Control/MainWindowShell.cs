using LinePlaneCore.Control.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace LinePlaneCore.Control
{
    internal class MainWindowShell : Base
    {
        #region Windows
        private RegistrationWindow Registration;
        private EnterWindow Enter;
        #endregion

        #region UserButton
        private Visibility _UserButton = Visibility.Hidden;

        /// <summary>
        /// UserButtonClick
        /// </summary>
        public Visibility UserButton
        {
            get => _UserButton;
            set=> Set(ref _UserButton, value);
        }

        #endregion

        #region CanvasData
        Canvas _MainCanvas;

        public Canvas MainCanvas
        {
            get => _MainCanvas;
            set => Set(ref _MainCanvas, value);
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
            Rectangle a=new Rectangle();
            a.Width = 100;
            a.Height = 1000;
            //CanvasObject.Add(a);
        }

        private bool CanShowUserPanelCommandExecuted(object p) => true;
        #endregion

        #region команда кнопки Registration
        public ICommand RegistrationWindowCommand { get; }

        private void OnRegistrationWindowCommandExecuted(object p)
        {
            if (Enter != null) Enter.Close();
            if (Registration != null) Registration.Close();

            Registration = new RegistrationWindow();

            Registration.Show();
        }

        private bool CanRegistrationWindowCommandExecuted(object p) => true;
        #endregion

        #region команда кнопки Authorization
        public ICommand AuthorizationWindowCommand { get; }

        private void OnAuthorizationWindowCommandExecuted(object p)
        {
            if (Registration != null) Registration.Close();
            if (Enter != null)  Enter.Close();

            Enter = new EnterWindow();

            Enter.Show();
        }

        private bool CanAuthorizationWindowCommandExecuted(object p) => true;
        #endregion

        #region команда перердача Canvas
        public ICommand CanvasTransportCommand { get; }

        private void OnCanvasTransportCommandExecuted(object p)
        {
            MainCanvas =(System.Windows.Controls.Canvas) p;
        }

        private bool CanCanvasTransportCommandExecuted(object p) => true;
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

        #endregion

        public MainWindowShell()
        {
            CanvasTransportCommand = new ActionCommand(OnCanvasTransportCommandExecuted, CanCanvasTransportCommandExecuted);

            #region user command

            #region команда для кнопки User
            ShowUserPanelCommand = new ActionCommand(OnShowUserPanelCommandExecuted, CanShowUserPanelCommandExecuted);
            #endregion

            #region команда для кнопки Registration
            RegistrationWindowCommand = new ActionCommand(OnRegistrationWindowCommandExecuted, CanRegistrationWindowCommandExecuted);
            #endregion

            #region команда для кнопки Authorization
            AuthorizationWindowCommand = new ActionCommand(OnAuthorizationWindowCommandExecuted, CanAuthorizationWindowCommandExecuted);
            #endregion

            #endregion

            #region команда кнопки Save
            SaveCommand = new ActionCommand(OnSaveCommandExecuted, CanSaveCommandExecuted);
            #endregion


        }

    }
}
