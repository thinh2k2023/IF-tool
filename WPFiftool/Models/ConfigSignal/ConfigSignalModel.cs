using DocumentFormat.OpenXml.Vml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFiftool.Models.ConfigSignal
{
    public class ConfigSignalModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

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


        private byte id;

        public byte ID
        {

            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ID)));
                }
            }
        }


        private bool isVisible;

        public bool IsVisible
        {

            get { return isVisible; }
            set
            {
                if (isVisible != value)
                {
                    isVisible = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsVisible)));
                }
            }
        }

        private EditableSignal editableSignal = new EditableSignal();

        public EditableSignal EditableSignal
        {
            get { return editableSignal; }
            set
            {
                if (editableSignal != value)
                {
                    editableSignal = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EditableSignal)));
                }
            }
        }
    }

    public class EditableSignal
    {
        private bool isUintEditable = true; // Default editable state

        public bool IsUintEditable
        {

            get { return isUintEditable; }
            set
            {
                if (isUintEditable != value)
                {
                    isUintEditable = value;
                }
                else
                {
                    //do nothing
                }
            }
        }

        private bool isMinMaxEditable = true; // Default editable state

        public bool IsMinMaxEditable
        {

            get { return isMinMaxEditable; }
            set
            {
                if (isMinMaxEditable != value)
                {
                    isMinMaxEditable = value;
                }
                else
                {
                    //do nothing
                }
            }
        }

        private bool isResolutionEditable = true; // Default editable state

        public bool IsResolutionEditable
        {
            get { return isResolutionEditable; }
            set
            {
                if (isResolutionEditable != value)
                {
                    isResolutionEditable = value;
                }
                else
                {
                    //do nothing
                }
            }
        }

        private bool isOffsetEditable = true; // Default editable state

        public bool IsOffsetEditable
        {
            get { return isOffsetEditable; }
            set
            {
                if (isOffsetEditable != value)
                {
                    isOffsetEditable = value;
                }
                else
                {
                    //do nothing
                }
            }
        }
    }
}
