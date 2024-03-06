using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
namespace WPFiftool.Models
{
    public class SignalModel:INotifyPropertyChanged
    {
        public virtual event PropertyChangedEventHandler PropertyChanged;
        
        private string _Type;
        private string _Channel;
        private string _IO;
        private string _SignalName;
        private string _Element;
        private string _Value;
        private string _Unit;
        private string _MaxLabel;
        private string _MinLabel;
        private string _Resolution;
        private string _Offset;
        private string _VisibleMonitor;
        private string _OrderMonitor;
        private string _VisibleOutput;
        private string _OrderOutput;
        private string _RawValue;
        public string Type
        {

            get { return _Type; }
            set
            {
                if (_Type != value)
                {
                    _Type = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Type)));
                }
            }
        }
        public string Channel
        {

            get { return _Channel; }
            set
            {
                if (_Channel != value)
                {
                    _Channel = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Channel)));
                }
            }
        }
        public string IO
        {

            get { return _IO; }
            set
            {
                if (_IO != value)
                {
                    _IO = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IO)));
                }
            }
        }
        public string SignalName
        {
            get { return _SignalName; }
            set
            {
                if (_SignalName != value)
                {
                    _SignalName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SignalName)));
                }
            }
        }
        public string Element
        {
            get { return _Element; }
            set
            {
                if (_Element != value)
                {
                    _Element = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Element)));
                }
            }
        }
        public string Value
        {
            get { return _Value; }
            set
            {
                if (_Value != value)
                {
                    _Value = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Value)));
                }
            }
        }
        public string Unit
        {
            get { return _Unit; }
            set
            {
                if (_Unit != value)
                {
                    _Unit = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Unit)));
                }
            }
        }
        public string MaxLabel
        {
            get { return _MaxLabel; }
            set
            {
                if (_MaxLabel != value)
                {
                    _MaxLabel = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MaxLabel)));
                }
            }
        }
        public string MinLabel
        {
            get { return _MinLabel; }
            set
            {
                if (_MinLabel != value)
                {
                    _MinLabel = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MinLabel)));
                }
            }
        }
        public string Resolution
        {
            get { return _Resolution; }
            set
            {
                if (_Resolution != value)
                {
                    _Resolution = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Resolution)));
                }
            }
        }
        public string Offset
        {
            get { return _Offset; }
            set
            {
                if (_Offset != value)
                {
                    _Offset = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Offset)));
                }
            }
        }
        public string VisibleMonitor
        {
            get { return _VisibleMonitor; }
            set
            {
                if (_VisibleMonitor != value)
                {
                    _VisibleMonitor = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VisibleMonitor)));
                }
            }
        }
        public string OrderMonitor
        {
            get { return _OrderMonitor; }
            set
            {
                if (_OrderMonitor != value)
                {
                    _OrderMonitor = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OrderMonitor)));
                }
            }
        }
        public string VisibleOutput
        {
            get { return _VisibleOutput; }
            set
            {
                if (_VisibleOutput != value)
                {
                    _VisibleOutput = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VisibleOutput)));
                }
            }
        }
        public string OrderOutput
        {
            get { return _OrderOutput; }
            set
            {
                if (_OrderOutput != value)
                {
                    _OrderOutput = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OrderOutput)));
                }
            }
        }
        public string RawValue
        {
            get { return _RawValue; }
            set
            {
                _RawValue = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RawValue)));
            }
        }
    }
}
