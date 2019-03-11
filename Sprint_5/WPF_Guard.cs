using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Sprint_5
{
    public class WPF_Guard : DependencyObject, INotifyPropertyChanged
    {
        private Guard guard;

        public ICommand ClockIn { get; set; }

        public WPF_Guard(Guard g)
        {
            this.guard = g;
            this.ClockIn = new WPFGuardCommand(ExecuteCommandClockIn, CanExecuteCommanyClockIn);
        }

        private bool CanExecuteCommanyClockIn(object parameter)
        {
            return true;
        }

        private void ExecuteCommandClockIn(object parameter)
        {
            this.guard.ClockIn();
            RaisePropertyChanged("Hours");
        }


        public float Hours
        {
            get
            {
                return this.guard.Hours;
            }
        }

        public string Name
        {
            get
            {
                return this.guard.Name;
            }

            set
            {
                if (Name != value)
                {
                    this.guard.Name = value;
                    RaisePropertyChanged();

                    RaisePropertyChanged("LogHours");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class WPFGuardCommand : ICommand
    {

        public delegate void ICommandOnExecute(object parameter);
        public delegate bool ICommandOnCanExecute(object parameter);

        private ICommandOnExecute _execute;
        private ICommandOnCanExecute _canExecute;

        public WPFGuardCommand(ICommandOnExecute onExecuteMethod, ICommandOnCanExecute onCanExecuteMethod)
        {
            _execute = onExecuteMethod;
            _canExecute = onCanExecuteMethod;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }
    }
}
