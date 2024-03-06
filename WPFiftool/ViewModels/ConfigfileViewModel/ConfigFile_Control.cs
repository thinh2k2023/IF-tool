using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using WPFiftool.Command;
using WPFiftool.Views;

namespace WPFiftool.ViewModels.ConfigfileViewModel
{
    public class ConfigFile_Control:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private string greeting;
        public string Greeting
        {
            get { return greeting; }
            set
            {
                greeting = value;
                NotifyPropertyChanged("Greeting");
            }
        }

        public ICommand cmdSubmitName { get; set; }
        public bool CanExecuteSubmit
        {
            get { return !string.IsNullOrEmpty(Name); }

        }

        public ConfigFile_Control()
        {
            cmdSubmitName = new Prism.Commands.DelegateCommand(ProcessSubmit, () => CanExecuteSubmit);
        }

        private void ProcessSubmit()
        {
            Greeting = $"Hello {Name}";
        }

        
    }

}
