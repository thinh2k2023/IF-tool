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
using WPFiftool.ViewModels.SignalMonitor;


namespace WPFiftool.Views
{

    public class AnalogOutputCANSend
    {
        public static UInt16 AnalogOutputConvertToRaw(UInt16 Channel, double Value, double MinValue)
        {
            UInt16 AnalogOutputRawData = (UInt16)((Value - MinValue) / DataConversion.AnalogOutputResolution[Channel]);
            return AnalogOutputRawData;
        }
        public static void SendAnalogOutputData(UInt16 Channel, UInt16 DataChannel)
        {
            switch (Channel)
            {
                case 0:
                    CANTXModel._AnalogOutputTXRawData.analogOutputData[0] = DataChannel;
                    CANRawTXViewModel.SendAnalogOutputMXP0();
                    break;

                case 1:
                    CANTXModel._AnalogOutputTXRawData.analogOutputData[1] = DataChannel;
                    CANRawTXViewModel.SendAnalogOutputMXP0();
                    break;
                case 2:
                    CANTXModel._AnalogOutputTXRawData.analogOutputData[2] = DataChannel;
                    CANRawTXViewModel.SendAnalogOutputMXP0();
                    break;
                case 3:
                    CANTXModel._AnalogOutputTXRawData.analogOutputData[3] = DataChannel;
                    CANRawTXViewModel.SendAnalogOutputMXP0();
                    break;

                case 4:
                    CANTXModel._AnalogOutputTXRawData.analogOutputData[4] = DataChannel;
                    CANRawTXViewModel.SendAnalogOutputMXP0();
                    break;
                case 5:
                    CANTXModel._AnalogOutputTXRawData.analogOutputData[5] = DataChannel;
                    CANRawTXViewModel.SendAnalogOutputMXP1();
                    break;
                case 6:
                    CANTXModel._AnalogOutputTXRawData.analogOutputData[6] = DataChannel;
                    CANRawTXViewModel.SendAnalogOutputMXP1();
                    break;

                case 7:
                    CANTXModel._AnalogOutputTXRawData.analogOutputData[7] = DataChannel;
                    CANRawTXViewModel.SendAnalogOutputMXP1();
                    break;
                case 8:
                    CANTXModel._AnalogOutputTXRawData.analogOutputData[8] = DataChannel;
                    CANRawTXViewModel.SendAnalogOutputMXP1();
                    break;
                case 9:
                    CANTXModel._AnalogOutputTXRawData.analogOutputData[9] = DataChannel;
                    CANRawTXViewModel.SendACOutputMXP1();
                    break;

                case 10:
                    CANTXModel._AnalogOutputTXRawData.analogOutputData[10] = DataChannel;
                    CANRawTXViewModel.SendAnalogOutputMXP2();
                    break;
                case 11:
                    CANTXModel._AnalogOutputTXRawData.analogOutputData[11] = DataChannel;
                    CANRawTXViewModel.SendAnalogOutputMXP2();
                    break;
                case 12:
                    CANTXModel._AnalogOutputTXRawData.analogOutputData[12] = DataChannel;
                    CANRawTXViewModel.SendAnalogOutputMXP2();
                    break;
                case 13:
                    CANTXModel._AnalogOutputTXRawData.analogOutputData[13] = DataChannel;
                    CANRawTXViewModel.SendAnalogOutputMXP2();
                    break;

                case 14:
                    CANTXModel._AnalogOutputTXRawData.analogOutputData[14] = DataChannel;
                    CANRawTXViewModel.SendAnalogOutputMXP2();
                    break;
                case 15:
                    CANTXModel._AnalogOutputTXRawData.analogOutputData[15] = DataChannel;
                    CANRawTXViewModel.SendAnalogOutputMXP3();
                    break;
                default:
                    //do nothing
                    break;
            }
        }
    }


    public partial class ControlOutputWindow : Window
    {

        /// <summary>
        /// CONTROL VALUE OF ANALOG OUTPUT WITH BUTTON OR MOUSE
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="control_btn"></param>
        private void Ana_control_value_click(UInt16 channel, Int16 control_btn)
        {
            // author: -
            // description: this function is update value of Analog Output when user change value of their textbox
            // return:-
            // note: -
            TextBox[] AnalogTextBoxes = new TextBox[16] { Analog0, Analog1, Analog2, Analog3, Analog4, Analog5, Analog6, Analog7, Analog8, Analog9, Analog10, Analog11, Analog12, Analog13, Analog14, Analog15 };

            double currentValue = Convert.ToDouble(AnalogTextBoxes[channel].Text);
            double newValue = 0, tempValue = 0;
            if (control_btn == MINUS_BTN)
            {
                newValue = Math.Max(currentValue - DataConversion._ana_step[channel], DataConversion._ana_min[channel]); // giới hạn giá trị dưới
            }
            else if (control_btn == PLUS_BTN)
            {
                newValue = Math.Min(currentValue + DataConversion._ana_step[channel], DataConversion._ana_max[channel]); // giới hạn giá trị trên
            }
            else // NO_USE_BTN
            {
                tempValue = Math.Max(currentValue, DataConversion._ana_min[channel]); // giới hạn giá trị dưới
                newValue = Math.Min(tempValue, DataConversion._ana_max[channel]); // giới hạn giá trị trên
            }
            AnalogTextBoxes[channel].Text = Convert.ToString(newValue); // hiển thị lên màn hình


            DataConversion.AnalogOut[channel] = Convert.ToDouble(AnalogTextBoxes[channel].Text); // lấy giá trị trên màn hình gán vào array chung
            
            if (StateMachine.StateMachineData == StateMachine.StateRun)
            {

                AnalogOutputCANSend.SendAnalogOutputData(channel, AnalogOutputCANSend.AnalogOutputConvertToRaw(channel, DataConversion.AnalogOut[channel], DataConversion._ana_min[channel]));
            }
        }

        /***********************HANDLER EVENT**********************/
        #region ANALOG OUTPUT CH0
        private void Ana0_minus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH0, MINUS_BTN); // click minus Analog textbox
        }
        private void Ana0_plus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH0, PLUS_BTN); // click plus Analog textbox
        }
        private void Ana0_lostFocus(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH0, NO_USE_BTN); // lost focus mouse at Analog textbox
        }
        private void Ana0_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Ana_control_value_click(ANA_CH0, NO_USE_BTN); // press "Enter" at Analog textbox
            }
        }

        #endregion


        #region ANALOG OUTPUT CH1
        /// control analog 1 with their buttons and click
        private void Ana1_minus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH1, MINUS_BTN); // click minus Analog textbox
        }
        private void Ana1_plus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH1, PLUS_BTN); // click plus Analog textbox
        }
        private void Ana1_lostFocus(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH1, NO_USE_BTN); // lost focus mouse at Analog textbox
        }
        private void Ana1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Ana_control_value_click(ANA_CH1, NO_USE_BTN); // press "Enter" at Analog textbox
            }
        }
        #endregion


        #region ANALOG OUTPUT CH2
        /// control analog 2 with their buttons and click
        private void Ana2_minus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH2, MINUS_BTN); // click minus Analog textbox
        }
        private void Ana2_plus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH2, PLUS_BTN); // click plus Analog textbox
        }
        private void Ana2_lostFocus(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH2, NO_USE_BTN); // lost focus mouse at Analog textbox
        }
        private void Ana2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Ana_control_value_click(ANA_CH2, NO_USE_BTN); // press "Enter" at Analog textbox
            }
        }

        #endregion


        #region ANALOG OUTPUT CH3
        /// control analog 3 with their buttons and click
        private void Ana3_minus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH3, MINUS_BTN); // click minus Analog textbox
        }
        private void Ana3_plus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH3, PLUS_BTN); // click plus Analog textbox
        }
        private void Ana3_lostFocus(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH3, NO_USE_BTN); // lost focus mouse at Analog textbox
        }
        private void Ana3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Ana_control_value_click(ANA_CH3, NO_USE_BTN); // press "Enter" at Analog textbox
            }
        }

        #endregion


        #region ANALOG OUTPUT CH4
        /// control analog 4 with their buttons and click
        private void Ana4_minus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH4, MINUS_BTN); // click minus Analog textbox
        }
        private void Ana4_plus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH4, PLUS_BTN); // click plus Analog textbox
        }
        private void Ana4_lostFocus(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH4, NO_USE_BTN); // lost focus mouse at Analog textbox
        }
        private void Ana4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Ana_control_value_click(ANA_CH4, NO_USE_BTN); // press "Enter" at Analog textbox
            }
        }

        #endregion


        #region ANALOG OUTPUT CH5
        /// control analog 5 with their buttons and click
        private void Ana5_minus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH5, MINUS_BTN); // click minus Analog textbox
        }
        private void Ana5_plus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH5, PLUS_BTN); // click plus Analog textbox
        }
        private void Ana5_lostFocus(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH5, NO_USE_BTN); // lost focus mouse at Analog textbox
        }
        private void Ana5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Ana_control_value_click(ANA_CH5, NO_USE_BTN); // press "Enter" at Analog textbox
            }
        }

        #endregion


        #region ANALOG OUTPUT CH6
        /// control analog 6 with their buttons and click
        private void Ana6_minus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH6, MINUS_BTN); // click minus Analog textbox
        }
        private void Ana6_plus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH6, PLUS_BTN); // click plus Analog textbox
        }
        private void Ana6_lostFocus(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH6, NO_USE_BTN); // lost focus mouse at Analog textbox
        }
        private void Ana6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Ana_control_value_click(ANA_CH6, NO_USE_BTN); // press "Enter" at Analog textbox
            }
        }
        #endregion


        #region ANALOG OUTPUT CH7
        /// control analog 7 with their buttons and click
        private void Ana7_minus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH7, MINUS_BTN); // click minus Analog textbox
        }
        private void Ana7_plus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH7, PLUS_BTN); // click plus Analog textbox
        }
        private void Ana7_lostFocus(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH7, NO_USE_BTN); // lost focus mouse at Analog textbox
        }
        private void Ana7_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Ana_control_value_click(ANA_CH7, NO_USE_BTN); // press "Enter" at Analog textbox
            }
        }
        #endregion


        #region ANALOG OUTPUT CH8
        /// control analog 8 with their buttons and click
        private void Ana8_minus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH8, MINUS_BTN); // click minus Analog textbox
        }
        private void Ana8_plus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH8, PLUS_BTN); // click plus Analog textbox
        }
        private void Ana8_lostFocus(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH8, NO_USE_BTN); // lost focus mouse at Analog textbox
        }
        private void Ana8_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Ana_control_value_click(ANA_CH8, NO_USE_BTN); // press "Enter" at Analog textbox
            }
        }
        #endregion


        #region ANALOG OUTPUT CH9
        /// control analog 9 with their buttons and click
        private void Ana9_minus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH9, MINUS_BTN); // click minus Analog textbox
        }
        private void Ana9_plus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH9, PLUS_BTN); // click plus Analog textbox
        }
        private void Ana9_lostFocus(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH9, NO_USE_BTN); // lost focus mouse at Analog textbox
        }
        private void Ana9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Ana_control_value_click(ANA_CH9, NO_USE_BTN); // press "Enter" at Analog textbox
            }
        }
        #endregion


        #region ANALOG OUTPUT CH10
        /// control analog 10 with their buttons and click
        private void Ana10_minus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH10, MINUS_BTN); // click minus Analog textbox
        }
        private void Ana10_plus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH10, PLUS_BTN); // click plus Analog textbox
        }
        private void Ana10_lostFocus(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH10, NO_USE_BTN); // lost focus mouse at Analog textbox
        }
        private void Ana10_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Ana_control_value_click(ANA_CH10, NO_USE_BTN); // press "Enter" at Analog textbox
            }
        }
        #endregion


        #region ANALOG OUTPUT CH11
        /// control analog 11 with their buttons and click
        private void Ana11_minus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH11, MINUS_BTN); // click minus Analog textbox
        }
        private void Ana11_plus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH11, PLUS_BTN); // click plus Analog textbox
        }
        private void Ana11_lostFocus(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH11, NO_USE_BTN); // lost focus mouse at Analog textbox
        }
        private void Ana11_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Ana_control_value_click(ANA_CH11, NO_USE_BTN); // press "Enter" at Analog textbox
            }
        }
        #endregion


        #region ANALOG OUTPUT CH12
        /// control analog 12 with their buttons and click
        private void Ana12_minus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH12, MINUS_BTN); // click minus Analog textbox
        }
        private void Ana12_plus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH12, PLUS_BTN); // click plus Analog textbox
        }
        private void Ana12_lostFocus(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH12, NO_USE_BTN); // lost focus mouse at Analog textbox
        }
        private void Ana12_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Ana_control_value_click(ANA_CH12, NO_USE_BTN); // press "Enter" at Analog textbox
            }
        }
        #endregion


        #region ANALOG OUTPUT CH13
        /// control analog 13 with their buttons and click
        private void Ana13_minus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH13, MINUS_BTN); // click minus Analog textbox
        }
        private void Ana13_plus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH13, PLUS_BTN); // click plus Analog textbox
        }
        private void Ana13_lostFocus(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH13, NO_USE_BTN); // lost focus mouse at Analog textbox
        }
        private void Ana13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Ana_control_value_click(ANA_CH13, NO_USE_BTN); // press "Enter" at Analog textbox
            }
        }
        #endregion


        #region ANALOG OUTPUT CH14
        /// control analog 14 with their buttons and click
        private void Ana14_minus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH14, MINUS_BTN); // click minus Analog textbox
        }
        private void Ana14_plus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH14, PLUS_BTN); // click plus Analog textbox
        }
        private void Ana14_lostFocus(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH14, NO_USE_BTN); // lost focus mouse at Analog textbox
        }
        private void Ana14_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Ana_control_value_click(ANA_CH14, NO_USE_BTN); // press "Enter" at Analog textbox
            }
        }
        #endregion


        #region ANALOG OUTPUT CH15
        /// control analog 15 with their buttons and click
        private void Ana15_minus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH15, MINUS_BTN); // click minus Analog textbox
        }
        private void Ana15_plus_Click(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH15, PLUS_BTN); // click plus Analog textbox
        }
        private void Ana15_lostFocus(object sender, RoutedEventArgs e)
        {
            Ana_control_value_click(ANA_CH15, NO_USE_BTN); // lost focus mouse at Analog textbox
        }
        private void Ana15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Ana_control_value_click(ANA_CH15, NO_USE_BTN); // press "Enter" at Analog textbox
            }
        }
        #endregion
    }
}
