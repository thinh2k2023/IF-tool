using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebSockets;
//using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ControlzEx.Standard;
using static System.Net.Mime.MediaTypeNames;
using WPFiftool.Models;
using System.Runtime.CompilerServices;
using MahApps.Metro.Controls;
using WPFiftool.ViewModels.ConfigfileViewModel;
using System.Windows.Media.Animation;
using static WPFiftool.Models.Common_string;
using System.Text.RegularExpressions;
using MaterialDesignThemes.Wpf;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.InkML;
using System.Security.Cryptography;
using WPFiftool.ViewModels.CANViewModel;
using WPFiftool.Models.CAN;
using WPFiftool.Driver;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using WPFiftool.ViewModels.StateMachineVM;
using System.Runtime.Remoting.Channels;


namespace WPFiftool.Views
{
    public class ACOutputCANSend
    {
        public static UInt16 ACOutputFreqConvertToRaw(UInt16 Channel, double Value)
        {
            //UInt16 tempRMSValue = (UInt16)(Value * 10);

            UInt16 tempRMSValue = (UInt16)(Value);

            return tempRMSValue;
        }

        public static UInt16 ACOutputLevelConvertToRaw(UInt16 Channel, double Value)
        {
            UInt16 tempRMSValue = (UInt16)((Value / (DataConversion.ACOutputRMSResolution[Channel])) * (Math.Sqrt(2)) - ((DataConversion.ACOutputRMSOffset[Channel]) / DataConversion.ACOutputRMSResolution[Channel]));

            return tempRMSValue;
        }

        public static UInt16 ACOutputPhaseShiftConvertToRaw(UInt16 Channel, int Value)
        {
            UInt16 tempRMSValue = (UInt16)(Value + 360);

            return tempRMSValue;
        }


        public static void SendACRMSDataEvent(UInt16 Channel, UInt16 DataChannel)
        {
            switch (Channel)
            {
                case 0:
                    CANTXModel._ACOutputTXRawData.Level[0] = DataChannel;
                    CANRawTXViewModel.SendACOutputMXP0();
                    break;
                case 1:
                    CANTXModel._ACOutputTXRawData.Level[1] = DataChannel;
                    CANRawTXViewModel.SendACOutputMXP1();
                    break;

                case 2:
                    CANTXModel._ACOutputTXRawData.Level[2] = DataChannel;
                    CANRawTXViewModel.SendACOutputMXP2();
                    break;
                case 3:
                    CANTXModel._ACOutputTXRawData.Level[3] = DataChannel;
                    CANRawTXViewModel.SendACOutputMXP3();
                    break;
                default:
                    /* Do nothing */
                    break;
            }
        }

        public static void SendACFreqDataEvent(UInt16 Channel, UInt16 DataChannel)
        {
            switch (Channel)
            {
                case 0:
                    CANTXModel._ACOutputTXRawData.frequency[0] = DataChannel;
                    CANRawTXViewModel.SendACOutputMXP0();
                    break;
                case 1:
                    CANTXModel._ACOutputTXRawData.frequency[1] = DataChannel;
                    CANRawTXViewModel.SendACOutputMXP1();
                    break;

                case 2:
                    CANTXModel._ACOutputTXRawData.frequency[2] = DataChannel;
                    CANRawTXViewModel.SendACOutputMXP2();
                    break;
                case 3:
                    CANTXModel._ACOutputTXRawData.frequency[3] = DataChannel;
                    CANRawTXViewModel.SendACOutputMXP3();
                    break;
                default:
                    /* Do nothing */
                    break;
            }
        }


        public static void SendACTypeWaveDataEvent(UInt16 Channel, UInt16 DataChannel)
        {
            switch (Channel)
            {
                case 0:
                    CANTXModel._ACOutputTXRawData.Type[0] = DataChannel;
                    CANRawTXViewModel.SendACOutputMXP0();
                    break;
                case 1:
                    CANTXModel._ACOutputTXRawData.Type[1] = DataChannel;
                    CANRawTXViewModel.SendACOutputMXP1();
                    break;

                case 2:
                    CANTXModel._ACOutputTXRawData.Type[2] = DataChannel;

                    CANRawTXViewModel.SendACOutputMXP2();
                    break;
                case 3:
                    CANTXModel._ACOutputTXRawData.Type[3] = DataChannel;

                    CANRawTXViewModel.SendACOutputMXP3();
                    break;
                default:
                    /* Do nothing */
                    break;
            }
        }

        public static void SendACLineCenterDataEvent(UInt16 Channel, UInt16 DataChannel)
        {
            switch (Channel)
            {
                case 0:
                    CANTXModel._ACOutputTXRawData.Center[0] = 2047;
                    CANRawTXViewModel.SendACOutputMXP0();
                    break;
                case 1:
                    CANTXModel._ACOutputTXRawData.Center[1] = 2047;
                    CANRawTXViewModel.SendACOutputMXP1();
                    break;

                case 2:
                    CANTXModel._ACOutputTXRawData.Center[2] = 2047;

                    CANRawTXViewModel.SendACOutputMXP2();
                    break;
                case 3:
                    CANTXModel._ACOutputTXRawData.Center[3] = 2047;

                    CANRawTXViewModel.SendACOutputMXP3();
                    break;
                default:
                    /* Do nothing */
                    break;
            }
        }

        public static void SendACPhaseShiftDataEvent(UInt16 Channel, UInt16 DataChannel)
        {
            switch (Channel)
            {
                case 0:
                    //do nothing
                    CANTXModel._ACOutputTXRawData.phaseShift[0] = DataChannel;
                    CANRawTXViewModel.SendACOutputMXP0();
                    break;
                case 1:
                    CANTXModel._ACOutputTXRawData.phaseShift[1] = DataChannel;
                    CANRawTXViewModel.SendACOutputMXP1();
                    break;
                case 2:

                    CANTXModel._ACOutputTXRawData.phaseShift[2] = DataChannel;
                    CANRawTXViewModel.SendACOutputMXP2();
                    break;
                case 3:
                    CANTXModel._ACOutputTXRawData.phaseShift[3] = DataChannel;
                    CANRawTXViewModel.SendACOutputMXP3();
                    break;
                default:
                    /* Do nothing */
                    break;
            }
        }
    }

    public partial class ControlOutputWindow : Window
    {

        #region AC OUTPUT FUNCTION CONTROL
        private void AC_RMS_control_value_click(UInt16 channel, Int16 control_btn)
        {
            // author: -
            // description: this function is update value of AC RMS when user change value of their textbox
            // return:-
            // note: -
            TextBox[] ACRmsTextBoxes = new TextBox[AC_ARRAY_LEN] { AC0_Rms, AC1_Rms, AC2_Rms, AC3_Rms }; // AC elements

            double currentValue = Convert.ToDouble(ACRmsTextBoxes[channel].Text);
            double newValue = 0, tempValue = 0;
            if (control_btn == MINUS_BTN)
            {
                newValue = Math.Max(currentValue - DataConversion._AC_RMS_step[channel], DataConversion._AC_RMS_min); // giới hạn giá trị dưới
            }
            else if (control_btn == PLUS_BTN)
            {
                newValue = Math.Min(currentValue + DataConversion._AC_RMS_step[channel], DataConversion._AC_RMS_max[channel]); // giới hạn giá trị trên
            }
            else // NO_USE_BTN
            {
                tempValue = Math.Max(currentValue, DataConversion._AC_RMS_min); // giới hạn giá trị dưới
                newValue = Math.Min(tempValue, DataConversion._AC_RMS_max[channel]); // giới hạn giá trị trên
            }
            ACRmsTextBoxes[channel].Text = Convert.ToString(newValue); // hiển thị lên màn hình


            //thinh coding this function
            DataConversion.ACRmsOut[channel] = Convert.ToDouble(ACRmsTextBoxes[channel].Text); // lấy giá trị trên màn hình gán vào array chung

            if (StateMachine.StateMachineData == StateMachine.StateRun)
            {
                ACOutputCANSend.SendACRMSDataEvent(channel, ACOutputCANSend.ACOutputLevelConvertToRaw(channel, DataConversion.ACRmsOut[channel]));
                ACOutputCANSend.SendACLineCenterDataEvent(channel, 2047);
            }
        }


        private void AC_Freq_control_value_click(UInt16 channel, Int16 control_btn)
        {
            // author: -
            // description: this function is update value of AC Freq when user change value of their textbox
            // return:-
            // note: -
            TextBox[] ACFreqTextBoxes = new TextBox[AC_ARRAY_LEN] { AC0_Freq, AC1_Freq, AC2_Freq, AC3_Freq }; // AC elements

            double currentValue = Convert.ToDouble(ACFreqTextBoxes[channel].Text);
            double newValue = 0, tempValue = 0;
            if (control_btn == MINUS_BTN)
            {
                newValue = Math.Max(currentValue - DataConversion._AC_Freq_step[channel], DataConversion.AC_FREQ_MIN); // giới hạn giá trị dưới
            }
            else if (control_btn == PLUS_BTN)
            {
                newValue = Math.Min(currentValue + DataConversion._AC_Freq_step[channel], DataConversion.AC_FREQ_MAX); // giới hạn giá trị trên
            }
            else // NO_USE_BTN
            {
                tempValue = Math.Max(currentValue, DataConversion.AC_FREQ_MIN); // giới hạn giá trị dưới
                newValue = Math.Min(tempValue, DataConversion.AC_FREQ_MAX); // giới hạn giá trị trên
            }
            ACFreqTextBoxes[channel].Text = Convert.ToString(newValue); // hiển thị lên màn hình


            //DataConversion.ACFreqOut[channel] = Convert.ToDouble(ACFreqTextBoxes[channel].Text); // lấy giá trị trên màn hình gán vào array chung

            //thinh coding this function
            DataConversion.ACFreqOut[channel] = Convert.ToDouble(ACFreqTextBoxes[channel].Text); // lấy giá trị trên màn hình gán vào array chung
            if (StateMachine.StateMachineData == StateMachine.StateRun)
            {
                ACOutputCANSend.SendACFreqDataEvent(channel, ACOutputCANSend.ACOutputFreqConvertToRaw(channel, DataConversion.ACFreqOut[channel]));
                ACOutputCANSend.SendACLineCenterDataEvent(channel, 2047);
            }
        }



        private void AC_PS_control_value_click(UInt16 channel, Int16 control_btn)
        {
            // author: -
            // description: this function is update value of AC PhaseShift when user change value of their textbox
            // return:-
            // note: -

            TextBox[] ACPhaseshiftTextBoxes = new TextBox[4] { AC0_PhaseShift, AC1_PhaseShift, AC2_PhaseShift, AC3_PhaseShift };// AC elements
            //ComboBox[] ACTypeWaveComboboxes = new ComboBox[4] { AC0_TypeWave, AC1_TypeWave, AC2_TypeWave, AC3_TypeWave };

            Int16 currentValue = Convert.ToInt16(ACPhaseshiftTextBoxes[channel].Text);
            Int16 newValue = 0, tempValue = 0;
            if (control_btn == MINUS_BTN)
            {
                newValue = Math.Max(Convert.ToInt16(currentValue - DataConversion._AC_PS_step[channel]), DataConversion.AC_PS_MIN); // giới hạn giá trị dưới
            }
            else if (control_btn == PLUS_BTN)
            {
                newValue = Math.Min(Convert.ToInt16(currentValue + DataConversion._AC_PS_step[channel]), DataConversion.AC_PS_MAX); // giới hạn giá trị trên
            }
            else // NO_USE_BTN
            {
                tempValue = Math.Max(currentValue, DataConversion.AC_PS_MIN); // giới hạn giá trị dưới
                newValue = Math.Min(tempValue, DataConversion.AC_PS_MAX); // giới hạn giá trị trên
            }
            ACPhaseshiftTextBoxes[channel].Text = Convert.ToString(newValue); // hiển thị lên màn hình

            //DataConversion.ACPsOut[channel] = Convert.ToInt16(ACPhaseshiftTextBoxes[channel].Text); // lấy giá trị trên màn hình gán vào array chung

            //thinh coding this function
            DataConversion.ACPsOut[channel] = Convert.ToInt16(ACPhaseshiftTextBoxes[channel].Text); // lấy giá trị trên màn hình gán vào array chung
            if (StateMachine.StateMachineData == StateMachine.StateRun)
            {
                ACOutputCANSend.SendACPhaseShiftDataEvent(channel, ACOutputCANSend.ACOutputPhaseShiftConvertToRaw(channel, DataConversion.ACPsOut[channel]));
                ACOutputCANSend.SendACLineCenterDataEvent(channel, 2047);
            }


            // // // // //
            Console.WriteLine(ACPhaseshiftTextBoxes[channel]);// test code write value of them
        }

        private void AC_TypeWave_control_value_click(UInt16 channel, UInt16 TypeWave)
        {
            DataConversion.ACTypeWaveOut[channel] = TypeWave;
            if (StateMachine.StateMachineData == StateMachine.StateRun)
            {
                ACOutputCANSend.SendACTypeWaveDataEvent(channel, DataConversion.ACTypeWaveOut[channel]);
                ACOutputCANSend.SendACLineCenterDataEvent(channel, 2047);
            }
        }
        #endregion


        #region AC OUTPUT CH0 EVENT HANDLE
        //RMS
        private void AC0_RMS_minus_Click(object sender, RoutedEventArgs e)
        {
            AC_RMS_control_value_click(AC_CH0, MINUS_BTN); // click minus AC RMS
        }
        private void AC0_RMS_plus_Click(object sender, RoutedEventArgs e)
        {
            AC_RMS_control_value_click(AC_CH0, PLUS_BTN); // click plus AC RMS
        }
        private void AC0_RMS_lostFocus(object sender, RoutedEventArgs e)
        {
            AC_RMS_control_value_click(AC_CH0, NO_USE_BTN); // lost focus mouse at AC RMS textbox
        }
        private void AC0_RMS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AC_RMS_control_value_click(AC_CH0, NO_USE_BTN); // press "Enter" at AC RMS textbox
            }
        }


        //PHASE SHIFT REQUEST
        private async void PhaseShift_Button_Click(object sender, RoutedEventArgs e)
        {
            // this value is different at the rest channel. Because only channel 0 has Start phase shift button.
            if (StateMachine.StateMachineData == StateMachine.StateRun)
            {
                DataConversion.ACPsOut[0] = 1;
                ACOutputCANSend.SendACLineCenterDataEvent(0, 2047);
                ACOutputCANSend.SendACPhaseShiftDataEvent(0, (UInt16)DataConversion.ACPsOut[0]);
                await Task.Delay(1000);
                DataConversion.ACPsOut[0] = 0;
                ACOutputCANSend.SendACPhaseShiftDataEvent(0, (UInt16)DataConversion.ACPsOut[0]);
            }
            //string a = Read_file.Data_import.AC_in_duty[0].Resolution;
        }

        //FREQUENCY
        private void AC0_Freq_minus_Click(object sender, RoutedEventArgs e)
        {
            AC_Freq_control_value_click(AC_CH0, MINUS_BTN); // click minus AC Freq
        }
        private void AC0_Freq_plus_Click(object sender, RoutedEventArgs e)
        {
            AC_Freq_control_value_click(AC_CH0, PLUS_BTN); // click plus AC Freq
        }
        private void AC0_Freq_lostFocus(object sender, RoutedEventArgs e)
        {
            AC_Freq_control_value_click(AC_CH0, NO_USE_BTN); // lost focus mouse at AC Freq textbox
        }
        private void AC0_Freq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AC_Freq_control_value_click(AC_CH0, NO_USE_BTN); // press "Enter" at AC Freq textbox
            }
        }

        //TYPE WAVE
        private void AC0_TypeWave_SelectChange(object sender, SelectionChangedEventArgs e)
        {
            AC_TypeWave_control_value_click(AC_CH0, (UInt16)AC0_TypeWave.SelectedIndex);
        }
        #endregion


        #region AC OUTPUT CH1 EVENT HANDLE

        //RMS
        private void AC1_RMS_minus_Click(object sender, RoutedEventArgs e)
        {
            AC_RMS_control_value_click(AC_CH1, MINUS_BTN); // click minus AC RMS
        }
        private void AC1_RMS_plus_Click(object sender, RoutedEventArgs e)
        {
            AC_RMS_control_value_click(AC_CH1, PLUS_BTN); // click plus AC RMS
        }
        private void AC1_RMS_lostFocus(object sender, RoutedEventArgs e)
        {
            AC_RMS_control_value_click(AC_CH1, NO_USE_BTN); // lost focus mouse at AC RMS textbox
        }
        private void AC1_RMS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AC_RMS_control_value_click(AC_CH1, NO_USE_BTN); // press "Enter" at AC RMS textbox
            }
        }

        //FREQUENCY
        private void AC1_Freq_minus_Click(object sender, RoutedEventArgs e)
        {
            AC_Freq_control_value_click(AC_CH1, MINUS_BTN); // click minus AC Freq
        }
        private void AC1_Freq_plus_Click(object sender, RoutedEventArgs e)
        {
            AC_Freq_control_value_click(AC_CH1, PLUS_BTN); // click plus AC Freq
        }
        private void AC1_Freq_lostFocus(object sender, RoutedEventArgs e)
        {
            AC_Freq_control_value_click(AC_CH1, NO_USE_BTN);  // lost focus mouse at AC Freq textbox
        }
        private void AC1_Freq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AC_Freq_control_value_click(AC_CH1, NO_USE_BTN); // press "Enter" at AC Freq textbox
            }
        }

        //PHASE SHIFT
        private void AC1_PhaseShift_minus_Click(object sender, RoutedEventArgs e)
        {
            AC_PS_control_value_click(AC_CH1, MINUS_BTN); // click plus AC PhaseShift
        }
        private void AC1_PhaseShift_plus_Click(object sender, RoutedEventArgs e)
        {
            AC_PS_control_value_click(AC_CH1, PLUS_BTN); // click plus AC PhaseShift
        }
        private void AC1_PhaseShift_lostFocus(object sender, RoutedEventArgs e)
        {
            AC_PS_control_value_click(AC_CH1, NO_USE_BTN); // lost focus mouse at AC PhaseShift textbox
        }

        private void AC1_PhaseShift_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AC_PS_control_value_click(AC_CH1, NO_USE_BTN); // press "Enter" at AC PhaseShift textbox
            }
        }

        //TYPE WAVE
        private void AC1_TypeWave_SelectChange(object sender, SelectionChangedEventArgs e)
        {
            AC_TypeWave_control_value_click(AC_CH1, (UInt16)AC1_TypeWave.SelectedIndex);
        }

        #endregion


        #region AC OUTPUT CH2 EVENT HANDLE

        //FREQUENCY
        private void AC2_Freq_minus_Click(object sender, RoutedEventArgs e)
        {
            AC_Freq_control_value_click(AC_CH2, MINUS_BTN); // click minus AC Freq
        }
        private void AC2_Freq_plus_Click(object sender, RoutedEventArgs e)
        {
            AC_Freq_control_value_click(AC_CH2, PLUS_BTN); // click plus AC Freq
        }
        private void AC2_Freq_lostFocus(object sender, RoutedEventArgs e)
        {
            AC_Freq_control_value_click(AC_CH2, NO_USE_BTN); // lost focus mouse at AC Freq textbox
        }
        private void AC2_Freq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AC_Freq_control_value_click(AC_CH2, NO_USE_BTN); // press "Enter" at AC Freq textbox
            }
        }

        //RMS
        private void AC2_RMS_minus_Click(object sender, RoutedEventArgs e)
        {
            AC_RMS_control_value_click(AC_CH2, MINUS_BTN); // click minus AC RMS
        }
        private void AC2_RMS_plus_Click(object sender, RoutedEventArgs e)
        {
            AC_RMS_control_value_click(AC_CH2, PLUS_BTN); // click minus AC RMS
        }
        private void AC2_RMS_lostFocus(object sender, RoutedEventArgs e)
        {
            AC_RMS_control_value_click(AC_CH2, NO_USE_BTN); // lost focus mouse at AC RMS textbox
        }
        private void AC2_RMS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AC_RMS_control_value_click(AC_CH2, NO_USE_BTN); // press "Enter" at AC RMS textbox
            }
        }

        //PHASE SHIFT
        private void AC2_PhaseShift_minus_Click(object sender, RoutedEventArgs e)
        {
            AC_PS_control_value_click(AC_CH2, MINUS_BTN); // click plus AC PhaseShift
        }
        private void AC2_PhaseShift_plus_Click(object sender, RoutedEventArgs e)
        {
            AC_PS_control_value_click(AC_CH2, PLUS_BTN); // click plus AC PhaseShift
        }
        private void AC2_PhaseShift_lostFocus(object sender, RoutedEventArgs e)
        {
            AC_PS_control_value_click(AC_CH2, NO_USE_BTN); // lost focus mouse at AC PhaseShift textbox
        }
        private void AC2_PhaseShift_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AC_PS_control_value_click(AC_CH2, NO_USE_BTN); // press "Enter" at AC PhaseShift textbox
            }
        }

        //TYPE WAVE
        private void AC2_TypeWave_SelectChange(object sender, SelectionChangedEventArgs e)
        {
            AC_TypeWave_control_value_click(AC_CH2, (UInt16)AC2_TypeWave.SelectedIndex);
        }

        #endregion


        #region AC OUTPUT CH3 EVENT HANDLE

        // FREQUENCY
        private void AC3_Freq_minus_Click(object sender, RoutedEventArgs e)
        {
            AC_Freq_control_value_click(AC_CH3, MINUS_BTN); // click minus AC Freq
        }
        private void AC3_Freq_plus_Click(object sender, RoutedEventArgs e)
        {
            AC_Freq_control_value_click(AC_CH3, PLUS_BTN); // click plus AC Freq
        }
        private void AC3_Freq_lostFocus(object sender, RoutedEventArgs e)
        {
            AC_Freq_control_value_click(AC_CH3, NO_USE_BTN); // lost focus mouse at AC Freq textbox
        }
        private void AC3_Freq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AC_Freq_control_value_click(AC_CH3, NO_USE_BTN); // press "Enter" at AC Freq textbox
            }
        }


        //RMS
        private void AC3_RMS_minus_Click(object sender, RoutedEventArgs e)
        {
            AC_RMS_control_value_click(AC_CH3, MINUS_BTN); // click minus AC RMS
        }
        private void AC3_RMS_plus_Click(object sender, RoutedEventArgs e)
        {
            AC_RMS_control_value_click(AC_CH3, PLUS_BTN); // click minus AC RMS
        }
        private void AC3_RMS_lostFocus(object sender, RoutedEventArgs e)
        {
            AC_RMS_control_value_click(AC_CH3, NO_USE_BTN); // lost focus mouse at AC RMS textbox
        }
        private void AC3_RMS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AC_RMS_control_value_click(AC_CH3, NO_USE_BTN); // press "Enter" at AC RMS textbox
            }
        }

        //PHASE SHIFT
        private void AC3_PhaseShift_minus_Click(object sender, RoutedEventArgs e)
        {
            AC_PS_control_value_click(AC_CH3, MINUS_BTN); // click plus AC PhaseShift
        }
        private void AC3_PhaseShift_plus_Click(object sender, RoutedEventArgs e)
        {
            AC_PS_control_value_click(AC_CH3, PLUS_BTN); // click plus AC PhaseShift
        }
        private void AC3_PhaseShift_lostFocus(object sender, RoutedEventArgs e)
        {
            AC_PS_control_value_click(AC_CH3, NO_USE_BTN); // lost focus mouse at AC PhaseShift textbox
        }
        private void AC3_PhaseShift_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AC_PS_control_value_click(AC_CH3, NO_USE_BTN); // press "Enter" at AC PhaseShift textbox
            }
        }
        //TYPE WAVE
        private void AC3_TypeWave_SelectChange(object sender, SelectionChangedEventArgs e)
        {
            AC_TypeWave_control_value_click(AC_CH3, (UInt16)AC3_TypeWave.SelectedIndex);
        }
        #endregion

    }
}
