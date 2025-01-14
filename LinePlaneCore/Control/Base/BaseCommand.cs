﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LinePlaneCore.Control.Comands
{
    internal abstract class  BaseCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter) { throw new NotImplementedException(); }

        public virtual void Execute(object parameter) { throw new NotImplementedException(); }
    }
}
