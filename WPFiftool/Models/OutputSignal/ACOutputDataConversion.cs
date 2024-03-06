using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFiftool.Models
{
    public partial class DataConversion
    {
        public static event EventHandler ACChangeEvent = delegate { };      //that event is used for ac output channel 0
        //TYPEWAVE
        public static UInt16[] ACTypeWaveOut { get; set; } = new UInt16[4];
        //PHASESHIFT
        public static Int16[] ACPsOut { get; set; } = new Int16[4];
        //FREQUENCY
        public static double[] ACFreqOut = new double[4];
        //RMS
        public static double[] ACRmsOut { get; set; } = new double[4];
        
    }
}
