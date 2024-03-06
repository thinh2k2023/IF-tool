using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFiftool.Models.InputSignal
{
    internal class PWMInput : SignalModel
    {
        private string _Duty;
        public string Duty
        {
            get { return _Duty; }
            set
            {
                if (_Duty != value)
                {
                    _Duty = value;
                }
            }
        }
        private string _Frequency;
        public string Frequency
        {
            get { return _Frequency; }
            set
            {
                if (_Frequency != value)
                {
                    _Frequency = value;
                }
            }
        }

        public string RMS { get; set; }
        public string Phase { get; set; }
        public string TypeWave { get; set; }
    }
}
