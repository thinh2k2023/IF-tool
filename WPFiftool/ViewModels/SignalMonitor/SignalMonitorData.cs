using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFiftool.Models.InputSignal;

namespace WPFiftool.ViewModels.SignalMonitor
{
    public static class ResolutionData
    {
        //analog input
        public static float[] AnalogInputResolution = new float[16];

        //AC input
        public static float[] ACInputRMSResolution = new float[16];

        public static float[] ACInputFreqResolution = new float[4];

        public static float[] ACInputPeakLResolution = new float[4];

        public static float[] ACInputPeakHResolution = new float[4];


        //

        //analog output



        public static void CalculateAnalogInputResolution(UInt16 index, float MaxValue, float MinValue)
        {
            AnalogInputResolution[index] = 4095/(MaxValue - MinValue);
        }

        public static void CalculateACRMSInputResolution(UInt16 index, float MaxValue, float MinValue)
        {
            ACInputRMSResolution[index] = (float)((1.65/Math.Sqrt(2))/(MaxValue - MinValue)); //max rms is 1.65/ sqrt(2)
        }

        public static void CalculateACPeakLInputResolution(UInt16 index, float MaxValue, float MinValue)
        {
            ACInputPeakLResolution[index] = 1.65f / (MaxValue - MinValue);
        }
        public static void CalculateACPeakHInputResolution(UInt16 index, float MaxValue, float MinValue)
        {
            ACInputPeakHResolution[index] = 1.65f / (MaxValue - MinValue);
        }
    }
}
