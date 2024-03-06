using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFiftool.Models;
using WPFiftool.Views;

namespace WPFiftool.ViewModels.SignalMonitor
{
    public class OutputMonitor
    {
        private const UInt16 DigitalOutputOffset = 56;      //16 signals
        private const UInt16 AnalogOutputOffset = 72;       //16 signals
        private const UInt16 PWMOutputOffset = 88;          //8 signals
        private const UInt16 ACOutputOffset = 96;           //16 signals

        public OutputMonitor() 
        { 


        } 
        
        public void UpdateOutputPHYValue()
        {
            for (int i = 0; i < 16; i++)
            {
                if (DataConversion.DigitalOut[i] == 1)
                {
                    //digital
                    InputMonitor.SignalMonitorDataSave[i + DigitalOutputOffset].RawValue = "1";
                    InputMonitor.SignalMonitorDataSave[i + DigitalOutputOffset].Value = InputMonitor.SignalMonitorDataSave[i + DigitalOutputOffset].MaxLabel;
                }
                else
                {
                    InputMonitor.SignalMonitorDataSave[i + DigitalOutputOffset].RawValue = "0";
                    InputMonitor.SignalMonitorDataSave[i + DigitalOutputOffset].Value = InputMonitor.SignalMonitorDataSave[i + DigitalOutputOffset].MinLabel;
                }
                //analog
                InputMonitor.SignalMonitorDataSave[i + AnalogOutputOffset].Value = DataConversion.AnalogOut[i].ToString();
            }


            //PWM OUTPUT
            //ch0
            InputMonitor.SignalMonitorDataSave[PWMOutputOffset + 0].Value = DataConversion.PWMDutyOut[0].ToString();
            InputMonitor.SignalMonitorDataSave[PWMOutputOffset + 1].Value = DataConversion.PWMFreqOut[0].ToString();

            //ch1
            InputMonitor.SignalMonitorDataSave[PWMOutputOffset + 2].Value = DataConversion.PWMDutyOut[1].ToString();
            InputMonitor.SignalMonitorDataSave[PWMOutputOffset + 3].Value = DataConversion.PWMFreqOut[1].ToString();

            //ch2
            InputMonitor.SignalMonitorDataSave[PWMOutputOffset + 4].Value = DataConversion.PWMDutyOut[2].ToString();
            InputMonitor.SignalMonitorDataSave[PWMOutputOffset + 5].Value = DataConversion.PWMFreqOut[2].ToString();

            //ch3
            InputMonitor.SignalMonitorDataSave[PWMOutputOffset + 6].Value = DataConversion.PWMDutyOut[3].ToString();
            InputMonitor.SignalMonitorDataSave[PWMOutputOffset + 7].Value = DataConversion.PWMFreqOut[3].ToString();

            
            //AC OUTPUT
            //ch0
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 0].Value = DataConversion.ACRmsOut[0].ToString();
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 1].Value = DataConversion.ACFreqOut[0].ToString();

            if(DataConversion.ACTypeWaveOut[0] == 0)
            {
                InputMonitor.SignalMonitorDataSave[ACOutputOffset + 2].Value = "Sine-Wave";
            }
            else if (DataConversion.ACTypeWaveOut[0] == 1) 
            {
                InputMonitor.SignalMonitorDataSave[ACOutputOffset + 2].Value = "Full-Wave";
            }
            else if (DataConversion.ACTypeWaveOut[0] == 2)
            {
                InputMonitor.SignalMonitorDataSave[ACOutputOffset + 2].Value = "Half-Wave";
            }
            else
            {
                //do nothing
            }


            //ch1
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 3].Value = DataConversion.ACRmsOut[1].ToString();
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 4].Value = DataConversion.ACFreqOut[1].ToString();
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 5].Value = DataConversion.ACPsOut[1].ToString();


            if (DataConversion.ACTypeWaveOut[1] == 0)
            {
                InputMonitor.SignalMonitorDataSave[ACOutputOffset + 6].Value = "Sine-Wave";
            }
            else if (DataConversion.ACTypeWaveOut[1] == 1)
            {
                InputMonitor.SignalMonitorDataSave[ACOutputOffset + 6].Value = "Full-Wave";
            }
            else if (DataConversion.ACTypeWaveOut[1] == 2)
            {
                InputMonitor.SignalMonitorDataSave[ACOutputOffset + 6].Value = "Half-Wave";
            }
            else
            {
                //do nothing
            }


            //ch2
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 7].Value = DataConversion.ACRmsOut[2].ToString();
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 8].Value = DataConversion.ACFreqOut[2].ToString();
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 9].Value = DataConversion.ACPsOut[2].ToString();

            if (DataConversion.ACTypeWaveOut[2] == 0)
            {
                InputMonitor.SignalMonitorDataSave[ACOutputOffset + 10].Value = "Sine-Wave";
            }
            else if (DataConversion.ACTypeWaveOut[2] == 1)
            {
                InputMonitor.SignalMonitorDataSave[ACOutputOffset + 10].Value = "Full-Wave";
            }
            else if (DataConversion.ACTypeWaveOut[2] == 2)
            {
                InputMonitor.SignalMonitorDataSave[ACOutputOffset + 10].Value = "Half-Wave";
            }
            else
            {
                //do nothing
            }    

            //ch3
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 11].Value = DataConversion.ACRmsOut[3].ToString();
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 12].Value = DataConversion.ACFreqOut[3].ToString();
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 13].Value = DataConversion.ACPsOut[3].ToString();

            if (DataConversion.ACTypeWaveOut[3] == 0)
            {
                InputMonitor.SignalMonitorDataSave[ACOutputOffset + 14].Value = "Sine-Wave";
            }
            else if (DataConversion.ACTypeWaveOut[3] == 1)
            {
                InputMonitor.SignalMonitorDataSave[ACOutputOffset + 14].Value = "Full-Wave";
            }
            else if (DataConversion.ACTypeWaveOut[3] == 2)
            {
                InputMonitor.SignalMonitorDataSave[ACOutputOffset + 14].Value = "Half-Wave";
            }
            else
            {
                //do nothing
            }
        }

        public void UpdateOutputRawValue()
        {
            //analog
            for (int i = 0; i < 16; i++)
            {
                InputMonitor.SignalMonitorDataSave[i + DigitalOutputOffset].RawValue = DataConversion.DigitalOut[i].ToString();
            }

            //InputMonitor.SignalMonitorDataSave[i + AnalogOutputOffset].RawValue = DataConversion.AnalogOutTemp[i].ToString();


            //pwm output raw value
            InputMonitor.SignalMonitorDataSave[PWMOutputOffset + 0].RawValue = DataConversion.PWMDutyOut[0].ToString();
            InputMonitor.SignalMonitorDataSave[PWMOutputOffset + 1].RawValue = DataConversion.PWMFreqOut[0].ToString();

            InputMonitor.SignalMonitorDataSave[PWMOutputOffset + 2].RawValue = DataConversion.PWMDutyOut[1].ToString();
            InputMonitor.SignalMonitorDataSave[PWMOutputOffset + 3].RawValue = DataConversion.PWMFreqOut[1].ToString();

            InputMonitor.SignalMonitorDataSave[PWMOutputOffset + 4].RawValue = DataConversion.PWMDutyOut[2].ToString();
            InputMonitor.SignalMonitorDataSave[PWMOutputOffset + 5].RawValue = DataConversion.PWMFreqOut[2].ToString();

            InputMonitor.SignalMonitorDataSave[PWMOutputOffset + 6].RawValue = DataConversion.PWMDutyOut[3].ToString();
            InputMonitor.SignalMonitorDataSave[PWMOutputOffset + 7].RawValue = DataConversion.PWMFreqOut[3].ToString();


            //AC OUTPUT
            //ch0
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 0].RawValue = DataConversion.ACRmsOut[0].ToString();
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 1].RawValue = DataConversion.ACFreqOut[0].ToString();
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 2].RawValue = DataConversion.ACTypeWaveOut[0].ToString();

            //ch1
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 3].RawValue = DataConversion.ACRmsOut[1].ToString();
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 4].RawValue = DataConversion.ACFreqOut[1].ToString();
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 5].RawValue = DataConversion.ACPsOut[1].ToString();
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 6].RawValue = DataConversion.ACTypeWaveOut[1].ToString();

            //ch2
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 7].RawValue = DataConversion.ACRmsOut[2].ToString();
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 8].RawValue = DataConversion.ACFreqOut[2].ToString();
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 9].RawValue = DataConversion.ACPsOut[2].ToString();
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 10].RawValue = DataConversion.ACTypeWaveOut[2].ToString();

            //ch3
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 11].RawValue = DataConversion.ACRmsOut[3].ToString();
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 12].RawValue = DataConversion.ACFreqOut[3].ToString();
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 13].RawValue = DataConversion.ACPsOut[3].ToString();
            InputMonitor.SignalMonitorDataSave[ACOutputOffset + 14].RawValue = DataConversion.ACTypeWaveOut[3].ToString();


        }
    }
}
