using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFiftool.Models.InputSignal
{
    public class PropetyVisible:INotifyPropertyChanged
    {
        public  event PropertyChangedEventHandler PropertyChanged;
        private String _PropetyName;
        public String PropetyName
        {
            get 
            { 
                return _PropetyName; 
            }
            set 
            {
                _PropetyName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PropetyName)));
            }
        }


        private bool _IsPropetyVisible = true;


        public bool IsPropetyVisible
        {  
            get 
            {
                return _IsPropetyVisible;
            } 
            set 
            {
                _IsPropetyVisible = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsPropetyVisible)));
            } 
        }
    }
}
