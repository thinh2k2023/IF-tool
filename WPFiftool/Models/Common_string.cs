using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFiftool.Models
{
    public class Common_string
    {

        public static bool List_Empty<T>(List<T> list)
        {
            return list == null || list.Count == 0;
        }

        public static string[] check_format = "Type,Channel,I/O,Signal name,Element,Value,Unit,Min (label),Max (label),Resolution,Offset,Visible monitor,Order monitor,Visible output,Order output".Split(',');

        public class Signal_Title : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public String Title { get; set; }
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

            // Các thuộc tính khác

            public string DataValidationFormula1 { get; set; }
            public string DataValidationFormula2 { get; set; }
            public XLOperator DataValidationType { get; set; }
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

        public class Data_save
        {
            public string Type;
            public string Channel;
            public string IO;
            public string SignalName;
            public string Element;
            public string Value;
            public string Unit;
            public string MinLabel;
            public string MaxLabel;
            public string Resolution;
            public string Offset;
            public string VisibleMonitor;
            public string OrderMonitor;
            public string VisibleOutput;
            public string OrderOutput;
        }
        public class Title_save
        {
            public string Title;
        }
        public class Each_signal_data_origin
        {
            public List<Signal_Title> Digital_in { get; set; } = new List<Signal_Title>();
            public List<Signal_Title> Analog_in { get; set; } = new List<Signal_Title>();
            public List<Signal_Title> PWM_in_duty { get; set; } = new List<Signal_Title>();
            public List<Signal_Title> PWM_in_freq { get; set; } = new List<Signal_Title>();
            public List<Signal_Title> AC_in_rms { get; set; } = new List<Signal_Title>();
            public List<Signal_Title> AC_in_freq { get; set; } = new List<Signal_Title>();
            public List<Signal_Title> AC_in_peak_L { get; set; } = new List<Signal_Title>();
            public List<Signal_Title> AC_in_peak_H { get; set; } = new List<Signal_Title>();
            public List<Signal_Title> Digital_out { get; set; } = new List<Signal_Title>();
            public List<Signal_Title> Analog_out { get; set; } = new List<Signal_Title>();
            public List<Signal_Title> PWM_out_duty { get; set; } = new List<Signal_Title>();
            public List<Signal_Title> PWM_out_freq { get; set; } = new List<Signal_Title>();
            public List<Signal_Title> AC_out_rms { get; set; } = new List<Signal_Title>();
            public List<Signal_Title> AC_out_freq { get; set; } = new List<Signal_Title>();
            public List<Signal_Title> AC_out_phase { get; set; } = new List<Signal_Title>();
            public List<Signal_Title> AC_out_type_wave { get; set; } = new List<Signal_Title>();
        }
        public class Each_signal_default_file_str
        {
            public static List<Signal_Title> Digital_in { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> Analog_in { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> PWM_in_duty { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> PWM_in_freq { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> AC_in_duty { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> AC_in_freq { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> Digital_out { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> Analog_out { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> PWM_out_duty { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> PWM_out_freq { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> AC_out_rms { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> AC_out_freq { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> AC_out_phase { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> AC_out_type_wave { get; set; } = new List<Signal_Title>();
        }
        public class Each_signal_start_app_str
        {
            public static List<Signal_Title> Digital_in { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> Analog_in { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> PWM_in_duty { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> PWM_in_freq { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> AC_in_duty { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> AC_in_freq { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> Digital_out { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> Analog_out { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> PWM_out_duty { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> PWM_out_freq { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> AC_out_rms { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> AC_out_freq { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> AC_out_phase { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> AC_out_type_wave { get; set; } = new List<Signal_Title>();
        }
        public class Each_signal_import_str
        {
            public static List<Signal_Title> Digital_in { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> Analog_in { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> PWM_in_duty { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> PWM_in_freq { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> AC_in_duty { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> AC_in_freq { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> Digital_out { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> Analog_out { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> PWM_out_duty { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> PWM_out_freq { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> AC_out_rms { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> AC_out_freq { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> AC_out_phase { get; set; } = new List<Signal_Title>();
            public static List<Signal_Title> AC_out_type_wave { get; set; } = new List<Signal_Title>();
        }
        public class Each_signal_default_screen
        {
            public static List<Signal_Title_default_screen> Digital_in { get; set; } = new List<Signal_Title_default_screen>();
            public static List<Signal_Title_default_screen> Analog_in { get; set; } = new List<Signal_Title_default_screen>();
            public static List<Signal_Title_default_screen> PWM_in { get; set; } = new List<Signal_Title_default_screen>();
            public static List<Signal_Title_default_screen> AC_in { get; set; } = new List<Signal_Title_default_screen>();
            public static List<Signal_Title_default_screen> Digital_out { get; set; } = new List<Signal_Title_default_screen>();
            public static List<Signal_Title_default_screen> Analog_out { get; set; } = new List<Signal_Title_default_screen>();
            public static List<Signal_Title_default_screen> PWM_out { get; set; } = new List<Signal_Title_default_screen>();
            public static List<Signal_Title_default_screen> AC_out { get; set; } = new List<Signal_Title_default_screen>();
        }
        public class Signal_Title_default_screen
        {
            public String Title;
            public String Type;
            public String Channel;
            public String IO;
            public String SignalName;
            public String[] Element;
            public String[] Value;
            public String[] Unit;
            public String[] MinLabel;
            public String[] MaxLabel;
            public String[] Resolution;
            public String[] Offset;
            public String[] VisibleMonitor;
            public String[] OrderMonitor;
            public String[] VisibleOutput;
            public String[] OrderOutput;
        }


        public class Auto_control_Title
        {
            public String Title { get; set; }
            public String Information { get; set; }
            public String Setting1 { get; set; }
            public String Setting2 { get; set; }
            public String Setting3 { get; set; }
            public String Setting4 { get; set; }
            public String Setting5 { get; set; }

        }




    }
}
