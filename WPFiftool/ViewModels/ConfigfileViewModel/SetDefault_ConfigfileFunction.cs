using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFiftool.Models;
using static WPFiftool.Models.Common_string;
using static WPFiftool.Models.DataConversion;
namespace WPFiftool.ViewModels.ConfigfileViewModel
{
    public partial class Read_file
    {
        public static void default_screen()
        {
            default_screen_output_control();
        }
        public static void default_screen_output_control()
        {
            for (int index_di_in_ub = 0; index_di_in_ub < 16; index_di_in_ub++)
            {
                Common_string.Signal_Title signal = new Common_string.Signal_Title();
                signal.Type = "Digital";
                signal.Channel = index_di_in_ub.ToString();
                signal.IO = "I";
                signal.SignalName = "DIGITAL IN " + index_di_in_ub.ToString();
                signal.Element = " ";
                signal.Value = "FALSE";
                signal.Unit = "-";
                signal.MinLabel = "LO";
                signal.MaxLabel = "HI";
                signal.Resolution = "-";
                signal.Offset = "-";
                signal.VisibleMonitor = "Yes";
                signal.OrderMonitor = index_di_in_ub.ToString();
                signal.VisibleOutput = "-";
                signal.OrderOutput = "-";
                Data_default_screen.Digital_in.Add(signal);
            }

            for (int index_analog_in_ub = 0; index_analog_in_ub < 16; index_analog_in_ub++)
            {
                Common_string.Signal_Title signal = new Common_string.Signal_Title();
                signal.Type = "Analog";
                signal.Channel = index_analog_in_ub.ToString();
                signal.IO = "I";
                signal.SignalName = "ANALOG IN " + index_analog_in_ub.ToString();
                signal.Element = " ";
                signal.Value = "0";
                signal.Unit = "V";
                signal.MinLabel = "null";
                signal.MaxLabel = "null";
                signal.Resolution = "0.1";
                signal.Offset = "0";
                signal.VisibleMonitor = "Yes";
                signal.OrderMonitor = index_analog_in_ub.ToString();
                signal.VisibleOutput = "-";
                signal.OrderOutput = "-";
                Data_default_screen.Analog_in.Add(signal);
            }
            for (int index_PWM_in_ub = 0; index_PWM_in_ub < 4; index_PWM_in_ub++)
            {
                Common_string.Signal_Title signal1 = new Common_string.Signal_Title();
                Common_string.Signal_Title signal2 = new Common_string.Signal_Title();
                signal1.Type = "PWM";
                signal1.Channel = index_PWM_in_ub.ToString();
                signal1.IO = "I";
                signal1.SignalName = "PWM IN " + index_PWM_in_ub.ToString();
                signal1.Element = "Duty";
                signal1.Value = "0";
                signal1.Unit = "%";
                signal1.MinLabel = "null";
                signal1.MaxLabel = "null";
                signal1.Resolution = "1";
                signal1.Offset = "-";
                signal1.VisibleMonitor = "No";
                signal1.OrderMonitor = "null";
                signal1.VisibleOutput = "-";
                signal1.OrderOutput = "-";
                Data_default_screen.PWM_in_duty.Add(signal1);

                signal2.Type = "PWM";
                signal2.Channel = index_PWM_in_ub.ToString();
                signal2.IO = "I";
                signal2.SignalName = "PWM IN " + index_PWM_in_ub.ToString();
                signal2.Element = "Frequency";
                signal2.Value = "0";
                signal2.Unit = "Hz";
                signal2.MinLabel = "null";
                signal2.MaxLabel = "null";
                signal2.Resolution = "1";
                signal2.Offset = "-";
                signal2.VisibleMonitor = "No";
                signal2.OrderMonitor = "null";
                signal2.VisibleOutput = "-";
                signal2.OrderOutput = "-";
                Data_default_screen.PWM_in_freq.Add(signal2);
            }

            for (int index_AC_in_ub = 0; index_AC_in_ub < 4; index_AC_in_ub++)
            {
                Common_string.Signal_Title signal1 = new Common_string.Signal_Title();
                Common_string.Signal_Title signal2 = new Common_string.Signal_Title();
                Common_string.Signal_Title signal3 = new Common_string.Signal_Title();
                Common_string.Signal_Title signal4 = new Common_string.Signal_Title();

                signal1.Type = "AC";
                signal1.Channel = index_AC_in_ub.ToString();
                signal1.IO = "I";
                signal1.SignalName = "AC IN " + index_AC_in_ub.ToString();
                signal1.Element = "RMS";
                signal1.Value = "0";
                signal1.Unit = "Vrms";
                signal1.MinLabel = "null";
                signal1.MaxLabel = "null";
                signal1.Resolution = "1";
                signal1.Offset = "0";
                signal1.VisibleMonitor = "Yes";
                signal1.OrderMonitor = index_AC_in_ub.ToString();
                signal1.VisibleOutput = "-";
                signal1.OrderOutput = "-";
                Data_default_screen.AC_in_rms.Add(signal1);

                signal2.Type = "AC";
                signal2.Channel = index_AC_in_ub.ToString();
                signal2.IO = "I";
                signal2.SignalName = "AC IN " + index_AC_in_ub.ToString();
                signal2.Element = "Frequency";
                signal2.Value = "0";
                signal2.Unit = "Hz";
                signal2.MinLabel = "null";
                signal2.MaxLabel = "null";
                signal2.Resolution = "1";
                signal2.Offset = "-";
                signal2.VisibleMonitor = "Yes";
                signal2.OrderMonitor = index_AC_in_ub.ToString();
                signal2.VisibleOutput = "-";
                signal2.OrderOutput = "-";
                Data_default_screen.AC_in_freq.Add(signal2);

                signal3.Type = "AC";
                signal3.Channel = index_AC_in_ub.ToString();
                signal3.IO = "I";
                signal3.SignalName = "AC IN " + index_AC_in_ub.ToString();
                signal3.Element = "Peak L";
                signal3.Value = "0";
                signal3.Unit = "V";
                signal3.MinLabel = "null";
                signal3.MaxLabel = "null";
                signal3.Resolution = "1";
                signal3.Offset = "-";
                signal3.VisibleMonitor = "Yes";
                signal3.OrderMonitor = index_AC_in_ub.ToString();
                signal3.VisibleOutput = "-";
                signal3.OrderOutput = "-";
                Data_default_screen.AC_in_peak_L.Add(signal3);

                signal4.Type = "AC";
                signal4.Channel = index_AC_in_ub.ToString();
                signal4.IO = "I";
                signal4.SignalName = "AC IN " + index_AC_in_ub.ToString();
                signal4.Element = "Peak H";
                signal4.Value = "0";
                signal4.Unit = "V";
                signal4.MinLabel = "null";
                signal4.MaxLabel = "null";
                signal4.Resolution = "1";
                signal4.Offset = "-";
                signal4.VisibleMonitor = "Yes";
                signal4.OrderMonitor = index_AC_in_ub.ToString();
                signal4.VisibleOutput = "-";
                signal4.OrderOutput = "-";
                Data_default_screen.AC_in_peak_H.Add(signal4);
            }

            for (int index_di_out_ub = 0; index_di_out_ub < 16; index_di_out_ub++)
            {
                Common_string.Signal_Title signal1 = new Common_string.Signal_Title();
                signal1.Type = "Digital";
                signal1.Channel = index_di_out_ub.ToString();
                signal1.IO = "O";
                signal1.SignalName = "DIGITAL OUT " + index_di_out_ub.ToString();
                signal1.Element = " ";
                signal1.Value = "0";
                signal1.Unit = "-";
                signal1.MinLabel = "LO";
                signal1.MaxLabel = "HI";
                signal1.Resolution = "-";
                signal1.Offset = "-";
                signal1.VisibleMonitor = "No";
                signal1.OrderMonitor = "null";
                signal1.VisibleOutput = "Yes";
                signal1.OrderOutput = index_di_out_ub.ToString();
                Data_default_screen.Digital_out.Add(signal1);
            }


            for (int index_analog_out_ub = 0; index_analog_out_ub < 16; index_analog_out_ub++)
            {
                Common_string.Signal_Title signal1 = new Common_string.Signal_Title();
                signal1.Type = "Analog";
                signal1.Channel = index_analog_out_ub.ToString();
                signal1.IO = "O";
                signal1.SignalName = "ANALOG OUT " + index_analog_out_ub.ToString();
                signal1.Element = " ";
                signal1.Value = "0";
                signal1.Unit = "V";
                signal1.MinLabel = "0";
                signal1.MaxLabel = "3.3";
                signal1.Resolution = "0.1";
                signal1.Offset = "0";
                signal1.VisibleMonitor = "Yes";
                signal1.OrderMonitor = "null";
                signal1.VisibleOutput = "-";
                signal1.OrderOutput = index_analog_out_ub.ToString();
                Data_default_screen.Analog_out.Add(signal1);
            }

            for (int index_PWM_out_ub = 0; index_PWM_out_ub < 4; index_PWM_out_ub++)
            {
                Common_string.Signal_Title signal1 = new Common_string.Signal_Title();
                Common_string.Signal_Title signal2 = new Common_string.Signal_Title();

                signal1.Type = "PWM";
                signal1.Channel = index_PWM_out_ub.ToString();
                signal1.IO = "O";
                signal1.SignalName = "PWM OUT " + index_PWM_out_ub.ToString();
                signal1.Element = "Duty";
                signal1.Value = "0";
                signal1.Unit = "%";
                signal1.MinLabel = "0";
                signal1.MaxLabel = "100";
                signal1.Resolution = "0.1";
                signal1.Offset = "-";
                signal1.VisibleMonitor = "Yes";
                signal1.OrderMonitor = "null";
                signal1.VisibleOutput = "Yes";
                signal1.OrderOutput = index_PWM_out_ub.ToString();
                Data_default_screen.PWM_out_duty.Add(signal1);

                signal2.Type = "PWM";
                signal2.Channel = index_PWM_out_ub.ToString();
                signal2.IO = "O";
                signal2.SignalName = "PWM OUT " + index_PWM_out_ub.ToString();
                signal2.Element = "Frequency";
                signal2.Value = "0";
                signal2.Unit = "Hz";
                signal2.MinLabel = "0";
                signal2.MaxLabel = "200000";
                signal2.Resolution = "100";
                signal2.Offset = "-";
                signal2.VisibleMonitor = "Yes";
                signal2.OrderMonitor = "null";
                signal2.VisibleOutput = "Yes";
                signal2.OrderOutput = index_PWM_out_ub.ToString();
                Data_default_screen.PWM_out_freq.Add(signal2);
            }


            for (int index_AC_out_ub = 0; index_AC_out_ub < 4; index_AC_out_ub++)
            {
                Common_string.Signal_Title signal1 = new Common_string.Signal_Title();
                Common_string.Signal_Title signal2 = new Common_string.Signal_Title();
                Common_string.Signal_Title signal3 = new Common_string.Signal_Title();
                Common_string.Signal_Title signal4 = new Common_string.Signal_Title();

                signal1.Type = "AC";
                signal1.Channel = index_AC_out_ub.ToString();
                signal1.IO = "O";
                signal1.SignalName = "AC OUT " + index_AC_out_ub.ToString();
                signal1.Element = "RMS";
                signal1.Value = "100";
                signal1.Unit = "Vrms";
                signal1.MinLabel = "0";
                signal1.MaxLabel = "551.5";
                signal1.Resolution = "0.3";
                signal1.Offset = "551.5";
                signal1.VisibleMonitor = "Yes";
                signal1.OrderMonitor = "null";
                signal1.VisibleOutput = "Yes";
                signal1.OrderOutput = index_AC_out_ub.ToString();
                Data_default_screen.AC_out_rms.Add(signal1);


                signal2.Type = "AC";
                signal2.Channel = index_AC_out_ub.ToString();
                signal2.IO = "O";
                signal2.SignalName = "AC OUT " + index_AC_out_ub.ToString();
                signal2.Element = "Frequency";
                signal2.Value = "50";
                signal2.Unit = "Hz";
                signal2.MinLabel = "0";
                signal2.MaxLabel = "50";
                signal2.Resolution = "0.1";
                signal2.Offset = "-";
                signal2.VisibleMonitor = "Yes";
                signal2.OrderMonitor = "null";
                signal2.VisibleOutput = "Yes";
                signal2.OrderOutput = index_AC_out_ub.ToString();
                Data_default_screen.AC_out_freq.Add(signal2);

                signal3.Type = "AC";
                signal3.Channel = index_AC_out_ub.ToString();
                signal3.IO = "O";
                signal3.SignalName = "AC OUT " + index_AC_out_ub.ToString();
                signal3.Element = "Frequency";
                signal3.Value = "50";
                signal3.Unit = "°";
                signal3.MinLabel = "-360";
                signal3.MaxLabel = "360";
                signal3.Resolution = "1";
                signal3.Offset = "-360";
                signal3.VisibleMonitor = "Yes";
                signal3.OrderMonitor = "null";
                signal3.VisibleOutput = "Yes";
                signal3.OrderOutput = index_AC_out_ub.ToString();
                Data_default_screen.AC_out_phase.Add(signal3);

                signal4.Type = "AC";
                signal4.Channel = index_AC_out_ub.ToString();
                signal4.IO = "O";
                signal4.SignalName = "AC OUT " + index_AC_out_ub.ToString();
                signal4.Element = "Typewave";
                signal4.Value = "Sine-Wave";
                signal4.Unit = "-";
                signal4.MinLabel = "null";
                signal4.MaxLabel = "null";
                signal4.Resolution = "-";
                signal4.Offset = "-";
                signal4.VisibleMonitor = "Yes";
                signal4.OrderMonitor = "null";
                signal4.VisibleOutput = "Yes";
                signal4.OrderOutput = index_AC_out_ub.ToString();
                Data_default_screen.AC_out_type_wave.Add(signal4);
            }

        }
    }
}
