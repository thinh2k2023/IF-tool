using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFiftool.Models
{
    public partial class DataConversion
    {
        //DUTY CYCLE
        public static double[] PWMDutyOut { get; set; } = new double[4];

        //PHASESHIFT
        public static UInt32[] PWMFreqOut { get; set; } = new UInt32[4];
    }
}
