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
using WPFiftool.Driver;
using WPFiftool.Models.CAN;
using WPFiftool.ViewModels.CANViewModel;
using WPFiftool.ViewModels.StateMachineVM;


namespace WPFiftool.Views
{


    public class PWMOutputCANSend
    {

        public static UInt16 PWMDutyFactor { get; } = 10;
        public static void SendPWMOutputDutyCycleData(UInt16 Channel, UInt16 DataChannel)
        {
            switch (Channel)
            {
                case 0:
                    CANTXModel._PWMOutputTXRawData.dutyCycle[0] = DataChannel;
                    CANRawTXViewModel.SendPWMOutputMXP0();
                    break;
                case 1:
                    CANTXModel._PWMOutputTXRawData.dutyCycle[1] = DataChannel;
                    CANRawTXViewModel.SendPWMOutputMXP0();
                    break;

                case 2:
                    CANTXModel._PWMOutputTXRawData.dutyCycle[2] = DataChannel;
                    CANRawTXViewModel.SendPWMOutputMXP1();
                    break;
                case 3:
                    CANTXModel._PWMOutputTXRawData.dutyCycle[3] = DataChannel;
                    CANRawTXViewModel.SendPWMOutputMXP1();
                    break;
                default:
                    /* Do nothing */
                    break;
            }
        }

        public static void SendPWMOutputFreqData(UInt16 Channel, UInt32 DataChannel)
        {
            switch (Channel)
            {
                case 0:
                    CANTXModel._PWMOutputTXRawData.frequency[0] = DataChannel;
                    CANRawTXViewModel.SendPWMOutputMXP0();
                    break;
                case 1:
                    CANTXModel._PWMOutputTXRawData.frequency[1] = DataChannel;
                    CANRawTXViewModel.SendPWMOutputMXP0();
                    break;

                case 2:
                    CANTXModel._PWMOutputTXRawData.frequency[2] = DataChannel;
                    CANRawTXViewModel.SendPWMOutputMXP1();
                    break;
                case 3:
                    CANTXModel._PWMOutputTXRawData.frequency[3] = DataChannel;
                    CANRawTXViewModel.SendPWMOutputMXP1();
                    break;
                default:
                    /* Do nothing */
                    break;
            }
        }
    }


    public partial class ControlOutputWindow : Window
    {

        #region PWM OUTPUT HANDLE EVENT
        /// <summary>
        ///  CONTROL PWM OUTPUT WITH THEIR TEXTBOX VALUE
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="control_btn"></param>
        private void PWM_Duty_control_value_click(UInt16 channel, Int16 control_btn)
        {
            // author: -
            // description: this function is update value of PWM Duty when user change value of their textbox
            // return:-
            // note: -
            TextBox[] PWMDutyTextBoxes = new TextBox[4] { PWM0_Duty, PWM1_Duty, PWM2_Duty, PWM3_Duty }; //PWM element

            double currentValue = Convert.ToDouble(PWMDutyTextBoxes[channel].Text);
            double newValue = 0, tempValue = 0;
            if (control_btn == MINUS_BTN)
            {
                newValue = Math.Max(currentValue - DataConversion._PWM_Duty_step[channel], DataConversion.PWM_DUTY_MIN); // giới hạn giá trị dưới
            }
            else if (control_btn == PLUS_BTN)
            {
                newValue = Math.Min(currentValue + DataConversion._PWM_Duty_step[channel], DataConversion.PWM_DUTY_MAX); // giới hạn giá trị trên
            }
            else // NO_USE_BTN
            {
                tempValue = Math.Max(currentValue, DataConversion.PWM_DUTY_MIN); // giới hạn giá trị dưới
                newValue = Math.Min(tempValue, DataConversion.PWM_DUTY_MAX); // giới hạn giá trị trên
            }
            PWMDutyTextBoxes[channel].Text = Convert.ToString(newValue); // hiển thị lên màn hình

            DataConversion.PWMDutyOut[channel] = Convert.ToDouble(PWMDutyTextBoxes[channel].Text); // lấy giá trị trên màn hình gán vào array chung

            if (StateMachine.StateMachineData == StateMachine.StateRun)
            {
                PWMOutputCANSend.SendPWMOutputDutyCycleData(channel, (UInt16)(DataConversion.PWMDutyOut[channel] * PWMOutputCANSend.PWMDutyFactor));
            }
        }

        private void PWM_Freq_control_value_click(UInt16 channel, Int16 control_btn)
        {
            // author: -
            // description: this function is update value of PWM Freq when user change value of their textbox
            // return:-
            // note: -
            TextBox[] PWMFreqTextBoxes = new TextBox[PWM_ARRAY_LEN] { PWM0_Freq, PWM1_Freq, PWM2_Freq, PWM3_Freq }; // AC elements

            double currentValue = Convert.ToDouble(PWMFreqTextBoxes[channel].Text);
            double newValue = 0, tempValue = 0;
            if (control_btn == MINUS_BTN)
            {
                newValue = Math.Max(currentValue - DataConversion._PWM_Freq_step[channel], DataConversion.PWM_FREQ_MIN); // giới hạn giá trị dưới
            }
            else if (control_btn == PLUS_BTN)
            {
                newValue = Math.Min(currentValue + DataConversion._PWM_Freq_step[channel], DataConversion.PWM_FREQ_MAX); // giới hạn giá trị trên
            }
            else // NO_USE_BTN
            {
                tempValue = Math.Max(currentValue, DataConversion.PWM_FREQ_MIN); // giới hạn giá trị dưới
                newValue = Math.Min(tempValue, DataConversion.PWM_FREQ_MAX); // giới hạn giá trị trên
            }
            PWMFreqTextBoxes[channel].Text = Convert.ToString(newValue); // hiển thị lên màn hình

            DataConversion.PWMFreqOut[channel] = Convert.ToUInt32(PWMFreqTextBoxes[channel].Text);
            if (StateMachine.StateMachineData == StateMachine.StateRun)
            {
                PWMOutputCANSend.SendPWMOutputFreqData(channel, DataConversion.PWMFreqOut[channel]);
            }

        }

        #endregion

        

        #region PWM OUTPUT EVENT

        #region PWM OUTPUT CH0
        // control PWM Output with their buttons and click
        // control Duty value of PWM 0
        private void PWM0_Duty_minus_Click(object sender, RoutedEventArgs e)
        {
            PWM_Duty_control_value_click(PWM_CH0, MINUS_BTN); // click minus PWM Freq textbox
        }
        private void PWM0_Duty_plus_Click(object sender, RoutedEventArgs e)
        {
            PWM_Duty_control_value_click(PWM_CH0, PLUS_BTN); // click plus PWM Freq textbox
        }
        private void PWM0_Duty_lostFocus(object sender, RoutedEventArgs e)
        {
            PWM_Duty_control_value_click(PWM_CH0, NO_USE_BTN); // lost focus mouse at PWM Freq textbox
        }
        private void PWM0_Duty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PWM_Duty_control_value_click(PWM_CH0, NO_USE_BTN); // press "Enter" at PWM Freq textbox
            }
        }

        // control Freq value of PWM 0
        private void PWM0_Freq_minus_Click(object sender, RoutedEventArgs e)
        {
            PWM_Freq_control_value_click(PWM_CH0, MINUS_BTN); // click minus PWM Freq textbox
        }
        private void PWM0_Freq_plus_Click(object sender, RoutedEventArgs e)
        {
            PWM_Freq_control_value_click(PWM_CH0, PLUS_BTN); // click plus PWM Freq textbox
        }
        private void PWM0_Freq_lostFocus(object sender, RoutedEventArgs e)
        {
            PWM_Freq_control_value_click(PWM_CH0, NO_USE_BTN); // lost focus mouse at PWM Freq textbox
        }

        private void PWM0_Freq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PWM_Freq_control_value_click(PWM_CH0, NO_USE_BTN); // press "Enter" at PWM Freq textbox
            }
        }
        #endregion


        #region PWM OUTPUT CH1
        // control Duty value of PWM 1
        private void PWM1_Duty_minus_Click(object sender, RoutedEventArgs e)
        {
            PWM_Duty_control_value_click(PWM_CH1, MINUS_BTN); // click minus PWM Freq textbox
        }
        private void PWM1_Duty_plus_Click(object sender, RoutedEventArgs e)
        {
            PWM_Duty_control_value_click(PWM_CH1, PLUS_BTN); // click plus PWM Freq textbox
        }
        private void PWM1_Duty_lostFocus(object sender, RoutedEventArgs e)
        {
            PWM_Duty_control_value_click(PWM_CH1, NO_USE_BTN); // lost focus mouse at PWM Freq textbox
        }
        private void PWM1_Duty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PWM_Duty_control_value_click(PWM_CH1, NO_USE_BTN); // press "Enter" at PWM Freq textbox
            }
        }

        // control Freq value of PWM 1
        private void PWM1_Freq_minus_Click(object sender, RoutedEventArgs e)
        {
            PWM_Freq_control_value_click(PWM_CH1, MINUS_BTN); // click minus PWM Freq textbox
        }
        private void PWM1_Freq_plus_Click(object sender, RoutedEventArgs e)
        {
            PWM_Freq_control_value_click(PWM_CH1, PLUS_BTN); // click plus PWM Freq textbox
        }
        private void PWM1_Freq_lostFocus(object sender, RoutedEventArgs e)
        {
            PWM_Freq_control_value_click(PWM_CH1, NO_USE_BTN); // lost focus mouse at PWM Freq textbox
        }

        private void PWM1_Freq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PWM_Freq_control_value_click(PWM_CH1, NO_USE_BTN); // press "Enter" at PWM Freq textbox
            }
        }
        #endregion

        #region PWM OUTPUT CH2
        // control Duty value of PWM 2
        private void PWM2_Duty_minus_Click(object sender, RoutedEventArgs e)
        {
            PWM_Duty_control_value_click(PWM_CH2, MINUS_BTN); // click minus PWM Freq textbox
        }
        private void PWM2_Duty_plus_Click(object sender, RoutedEventArgs e)
        {
            PWM_Duty_control_value_click(PWM_CH2, PLUS_BTN); // click plus PWM Freq textbox
        }
        private void PWM2_Duty_lostFocus(object sender, RoutedEventArgs e)
        {
            PWM_Duty_control_value_click(PWM_CH2, NO_USE_BTN); // lost focus mouse at PWM Freq textbox
        }
        private void PWM2_Duty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PWM_Duty_control_value_click(PWM_CH2, NO_USE_BTN); // press "Enter" at PWM Freq textbox
            }
        }
        // control Freq value of PWM 2
        private void PWM2_Freq_minus_Click(object sender, RoutedEventArgs e)
        {
            PWM_Freq_control_value_click(PWM_CH2, MINUS_BTN); // click minus PWM Freq textbox
        }
        private void PWM2_Freq_plus_Click(object sender, RoutedEventArgs e)
        {
            PWM_Freq_control_value_click(PWM_CH2, PLUS_BTN); // click plus PWM Freq textbox
        }
        private void PWM2_Freq_lostFocus(object sender, RoutedEventArgs e)
        {
            PWM_Freq_control_value_click(PWM_CH2, NO_USE_BTN); // lost focus mouse at PWM Freq textbox
        }

        private void PWM2_Freq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PWM_Freq_control_value_click(PWM_CH2, NO_USE_BTN); // press "Enter" at PWM Freq textbox
            }
        }
        #endregion


        #region PWM OUTPUT CH3
        // control Duty value of PWM 3
        private void PWM3_Duty_minus_Click(object sender, RoutedEventArgs e)
        {
            PWM_Duty_control_value_click(PWM_CH3, MINUS_BTN); // click minus PWM Freq textbox
        }
        private void PWM3_Duty_plus_Click(object sender, RoutedEventArgs e)
        {
            PWM_Duty_control_value_click(PWM_CH3, PLUS_BTN); // click plus PWM Freq textbox
        }
        private void PWM3_Duty_lostFocus(object sender, RoutedEventArgs e)
        {
            PWM_Duty_control_value_click(PWM_CH3, NO_USE_BTN); // lost focus mouse at PWM Freq textbox
        }
        private void PWM3_Duty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PWM_Duty_control_value_click(PWM_CH3, NO_USE_BTN); // press "Enter" at PWM Freq textbox
            }
        }

        // control Freq value of PWM 3
        private void PWM3_Freq_minus_Click(object sender, RoutedEventArgs e)
        {
            PWM_Freq_control_value_click(PWM_CH3, MINUS_BTN); // click minus PWM Freq textbox
        }
        private void PWM3_Freq_plus_Click(object sender, RoutedEventArgs e)
        {
            PWM_Freq_control_value_click(PWM_CH3, PLUS_BTN); // click plus PWM Freq textbox
        }
        private void PWM3_Freq_lostFocus(object sender, RoutedEventArgs e)
        {
            PWM_Freq_control_value_click(PWM_CH3, NO_USE_BTN); // lost focus mouse at PWM Freq textbox
        }

        private void PWM3_Freq_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                PWM_Freq_control_value_click(PWM_CH3, NO_USE_BTN); // press "Enter" at PWM Freq textbox
            }
        }

        #endregion
        #endregion
    }
}
