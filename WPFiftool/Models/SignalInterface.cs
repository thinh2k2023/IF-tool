using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WPFiftool.Models
{
    public interface SignalInterface
    {
        //public event PropertyChangedEventHandler PropertyChanged;
        //private void OnPropertyChanged(string p)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(p));
        //    }
        //}
        string Type { get; set; }
        string Channel { get; set; }
        string IO { get; set; }
        string SignalName { get; set; }
        string Element { get; set; }
        string Value { get; set; }
        string Unit { get; set; }
        string MaxLabel { get; set; }
        string MinLabel { get; set; }
        string Resolution { get; set; }
        string Offset { get; set; }
        string VisibleMonitor { get; set; }
        string OrderMonitor { get; set; }
        string VisibleOutput { get; set; }
        string OrderOutput { get; set; }

        string Duty { get; set; }
        string Frequency { get; set; }
        string RMS { get; set; }
        string Phase { get; set; }
        string TypeWave { get; set; }
    }
}
