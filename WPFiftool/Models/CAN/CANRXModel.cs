
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFiftool.Models.CAN
{
    public static class CANRXRawData
    {

        public static ResponseRawData _ResponseRawData { get; set; } = new ResponseRawData();  //all raw rx data is in here

        public static DigitalInputRawData _DigitalInputRawData { get; set; } = new DigitalInputRawData();  //all raw rx data is in here

        public static AnalogInputRawData _AnalogInputRawData { get; set; } = new AnalogInputRawData();  //all raw rx data is in here

        public static PWMInputRawData _PWMInputRawData { get; set; } = new PWMInputRawData();  //all raw rx data is in here

        public static ACInputRawData _ACInputRawData { get; set; } = new ACInputRawData();  //all raw rx data is in here

    }

    public class ResponseRawData : INotifyPropertyChanged
    {
        private byte _responselData = new byte();     //16 channel

        public ResponseRawData()       //constructor
        {

        }

        public byte responselData
        {
            get
            {
                return _responselData;
            }
            set
            {
                _responselData = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(responselData)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class DigitalInputRawData : INotifyPropertyChanged
    {
        //data
        private const UInt16 MaxDigitalInputChannel = 16;

        private byte[] _digitalData = new byte[MaxDigitalInputChannel];     //16 channel

        public DigitalInputRawData()       //constructor
        {

        }

        public byte[] digitalData
        {
            get
            {
                return _digitalData;
            }
            set
            {
                _digitalData = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(_digitalData)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class AnalogInputRawData : INotifyPropertyChanged
    {
        private const UInt16 MaxAnalogInputChannel = 16;

        private UInt16[] _analogData = new UInt16[MaxAnalogInputChannel];     //16 channel

        public UInt16[] analogData
        {
            get
            {
                return _analogData;
            }
            set
            {
                _analogData = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(analogData)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class PWMInputRawData : INotifyPropertyChanged
    {
        //data
        private string _frequency;
        private string _dutyCycle;

        public string frequency
        {
            get
            {
                return _frequency;
            }
            set
            {
                _frequency = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(frequency)));
            }
        }

        public string dutyCycle
        {
            get
            {
                return _dutyCycle;
            }
            set
            {
                _dutyCycle = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(dutyCycle)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }


    public class ACInputRawData : INotifyPropertyChanged
    {
        private const UInt16 MaxACInputChannel = 4;
        private float[] _frequency = new float[MaxACInputChannel];           //4 channel
        private float[] _RMSVoltage = new float[MaxACInputChannel];          //4 channel
        private float[] _PeakHighVoltage = new float[MaxACInputChannel];     //4 channel
        private float[] _PeakLowVoltage = new float[MaxACInputChannel];      //4 channel

        public float[] frequency
        {
            get
            {
                return _frequency;
            }
            set
            {
                _frequency = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(frequency)));
            }
        }

        public float[] RMSVoltage
        {
            get
            {
                return _RMSVoltage;
            }
            set
            {
                _RMSVoltage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RMSVoltage)));
            }
        }

        public float[] PeakHighVoltage
        {
            get
            {
                return _PeakHighVoltage;
            }
            set
            {
                _PeakHighVoltage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PeakHighVoltage)));
            }
        }

        public float[] PeakLowVoltage
        {
            get
            {
                return _PeakLowVoltage;
            }
            set
            {
                _PeakLowVoltage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PeakLowVoltage)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}


