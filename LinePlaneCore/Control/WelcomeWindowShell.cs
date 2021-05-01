using LinePlaneCore.Control.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LinePlaneCore.Control
{
    class WelcomeWindowShell : Base
    {
        #region Windows
        private RegistrationWindow Registration;
        private EnterWindow Enter;
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
            if (Enter != null) Enter.Close();

            Enter = new EnterWindow();

            Enter.Show();
        }

        private bool CanAuthorizationWindowCommandExecuted(object p) => true;
        #endregion

        public WelcomeWindowShell()
        {
            #region команда для кнопки Registration
            RegistrationWindowCommand = new ActionCommand(OnRegistrationWindowCommandExecuted, CanRegistrationWindowCommandExecuted);
            #endregion

            #region команда для кнопки Authorization
            AuthorizationWindowCommand = new ActionCommand(OnAuthorizationWindowCommandExecuted, CanAuthorizationWindowCommandExecuted);
            #endregion
        }

    }
}
