using LinePlaneCore.Control.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LinePlaneCore.Control
{
    internal class MainWindowShell : Base
    {

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

        private RegistrationWindow Registration;

        #region Команды

        #region команда кнопки User
        public ICommand ShowUserPanelCommand { get; }

        private void OnShowUserPanelCommandExecuted(object p)
        {
            if (_UserButton == Visibility.Hidden) UserButton = Visibility.Visible;
            else UserButton = Visibility.Hidden;
        }

        private bool CanShowUserPanelCommandExecuted(object p) => true;
        #endregion

        #region команда кнопки Registration
        public ICommand RegistrationWindowCommand { get; }

        private void OnRegistrationWindowCommandExecuted(object p)
        {
            if (Registration != null)
                Registration.Close();

            Registration = new RegistrationWindow();

            Registration.Show();
        }

        private bool CanRegistrationWindowCommandExecuted(object p) => true;
        #endregion

        #endregion

        public MainWindowShell()
        {
            #region команда для кнопки User
            ShowUserPanelCommand = new ActionCommand(OnShowUserPanelCommandExecuted, CanShowUserPanelCommandExecuted);
            #endregion
            #region команда для кнопки Registration
            RegistrationWindowCommand = new ActionCommand(OnRegistrationWindowCommandExecuted, CanRegistrationWindowCommandExecuted);
            #endregion
        }

    }
}
