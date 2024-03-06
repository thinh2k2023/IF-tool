using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFiftool.Models.CAN
{
    public static class CANTXModel
    {

        public static RequestMessage _RequestMessage { get; set; } = new RequestMessage();
        public static DigitalOutputPHYData _DigitalOutputTXRawData { get; set; } = new DigitalOutputPHYData();
        public static AnalogOutputPHYData _AnalogOutputTXRawData { get; set; } = new AnalogOutputPHYData();
        public static PWMOutputPHYData _PWMOutputTXRawData { get; set; } = new PWMOutputPHYData();
        public static ACOutputPHYData _ACOutputTXRawData { get; set; } = new ACOutputPHYData();
        public static byte[] _DataCANTXMSG { get; set; } = new byte[8];       //msg data transmit (8 bytes)
    }

    public class RequestMessage : INotifyPropertyChanged
    {
        //data

        private byte _requestMessageData;
        private const UInt16 _ReqMSGOutputID = 256;

        public RequestMessage()       //constructor
        {

        }

        public byte requestMessageData
        {
            get
            {
                return _requestMessageData;
            }
            set
            {
                _requestMessageData = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(requestMessageData)));
            }
        }
        public UInt16 ReqMSGOutputID
        {
            get
            {
                return _ReqMSGOutputID;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class DigitalOutputPHYData : INotifyPropertyChanged
    {

        private byte[] _digitalOutputData = new byte[16];     //16 channel
        private const UInt16 _DigitalOutputID = 512;

        public byte[] digitalOutputData
        {
            get
            {
                return _digitalOutputData;
            }
            set
            {
                _digitalOutputData = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(digitalOutputData)));
            }
        }

        public UInt16 DigitalOutputID
        {
            get
            {
                return _DigitalOutputID;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class AnalogOutputPHYData : INotifyPropertyChanged
    {

        //data
        private UInt16[] _analogOutputData = new UInt16[16];     //16 channel
        private const UInt16 _AnalogOutputID = 513;

        public UInt16[] analogOutputData
        {
            get
            {
                return _analogOutputData;
            }
            set
            {
                _analogOutputData = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(analogOutputData)));
            }
        }

        public UInt16 AnalogOutputID
        {
            get
            {
                return _AnalogOutputID;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class PWMOutputPHYData : INotifyPropertyChanged
    {
        //data
        private UInt32[] _frequency = new UInt32[4];     //4 channel
        private UInt16[] _dutyCycle = new UInt16[4];     //4 channel
        private const UInt16 _PWMOutputID = 514;
        public UInt32[] frequency
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

        public UInt16[] dutyCycle
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
        public UInt16 PWMOutputID
        {
            get
            {
                return _PWMOutputID;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class ACOutputPHYData : INotifyPropertyChanged
    {

        //data
        private UInt16[] _frequency = new UInt16[4];
        private UInt16[] _level = new UInt16[4];
        private UInt16[] _center = new UInt16[4];
        private UInt16[] _type = new UInt16[4];
        private UInt16[] _phaseShift = new UInt16[4];

        private const UInt16 _ACOutputID = 515;

        public UInt16[] frequency
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

        public UInt16[] Level
        {
            get
            {
                return _level;
            }
            set
            {
                _level = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Level)));
            }
        }

        public UInt16[] Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Type)));
            }
        }

        public UInt16[] phaseShift
        {
            get
            {
                return _phaseShift;
            }
            set
            {
                _phaseShift = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(phaseShift)));
            }
        }

        public UInt16[] Center
        {
            get
            {
                return _center;
            }
            set
            {
                _center = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Center)));
            }
        }
        public UInt16 ACOutputID
        {
            get
            {
                return _ACOutputID;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
