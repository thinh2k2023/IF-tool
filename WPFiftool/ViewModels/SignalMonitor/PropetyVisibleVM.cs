using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFiftool.Models.InputSignal;

namespace WPFiftool.ViewModels.SignalMonitor
{
    public class PropetyVisibleVM
    {
        private static ObservableCollection<PropetyVisible> _PropetiesVisible;

        public static ObservableCollection<PropetyVisible> PropetiesVisible
        {
            get { return _PropetiesVisible; }
            set { _PropetiesVisible = value; }
        }


        //constructor
        public PropetyVisibleVM()
        {
            _PropetiesVisible = new ObservableCollection<PropetyVisible>() 
            { 
                new PropetyVisible() { IsPropetyVisible = true, PropetyName = "Signal name" },
                new PropetyVisible() { IsPropetyVisible = true, PropetyName = "Type" },
                new PropetyVisible() { IsPropetyVisible = true, PropetyName = "Channel" },
                new PropetyVisible() { IsPropetyVisible = true, PropetyName = "I/O" },
                new PropetyVisible() { IsPropetyVisible = true, PropetyName = "Raw value" },
                new PropetyVisible() { IsPropetyVisible = true, PropetyName = "Value" },
                new PropetyVisible() { IsPropetyVisible = true, PropetyName = "Unit" },
                new PropetyVisible() { IsPropetyVisible = true, PropetyName = "Min" },
                new PropetyVisible() { IsPropetyVisible = true, PropetyName = "Max" },
                new PropetyVisible() { IsPropetyVisible = true, PropetyName = "Offset" },
                new PropetyVisible() { IsPropetyVisible = true, PropetyName = "Resolution" },
            };
        }
    };
}
