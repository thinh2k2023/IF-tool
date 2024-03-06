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
using DocumentFormat.OpenXml.Wordprocessing;
using WPFiftool.Models.CAN;
using WPFiftool.ViewModels.CANViewModel;
using WPFiftool.ViewModels.StateMachineVM;

namespace WPFiftool.Views
{

    public class DigitalOutputCANSend
    {
        public static void SendDigitalOutputData(UInt16 Channel, UInt16 DataChannel)
        {
            if (StateMachine.StateMachineData == StateMachine.StateRun)
            {
                CANTXModel._DigitalOutputTXRawData.digitalOutputData[Channel] = DataConversion.DigitalOut[Channel];
                CANRawTXViewModel.SendDigitalOutput();
            }
        }
    }

    public partial class ControlOutputWindow : Window
    {
        /// <summary>
        /// control output value with their button
        /// </summary>
        // take data from each Digital toggle switch to array

        private void Digi0_Toggle(object sender, RoutedEventArgs e)
        {

            DataConversion.DigitalOut[0] = Convert.ToByte(Digi0.IsOn);
            DigitalOutputCANSend.SendDigitalOutputData(0, DataConversion.DigitalOut[0]);

        }
        private void Digi1_Toggle(object sender, RoutedEventArgs e)
        {
            DataConversion.DigitalOut[1] = Convert.ToByte(Digi1.IsOn);
            DigitalOutputCANSend.SendDigitalOutputData(1, DataConversion.DigitalOut[1]);
        }
        private void Digi2_Toggle(object sender, RoutedEventArgs e)
        {
            DataConversion.DigitalOut[2] = Convert.ToByte(Digi2.IsOn);
            DigitalOutputCANSend.SendDigitalOutputData(2, DataConversion.DigitalOut[2]);
        }
        private void Digi3_Toggle(object sender, RoutedEventArgs e)
        {
            DataConversion.DigitalOut[3] = Convert.ToByte(Digi3.IsOn);
            DigitalOutputCANSend.SendDigitalOutputData(3, DataConversion.DigitalOut[3]);
        }
        private void Digi4_Toggle(object sender, RoutedEventArgs e)
        {
            DataConversion.DigitalOut[4] = Convert.ToByte(Digi4.IsOn);
            DigitalOutputCANSend.SendDigitalOutputData(4, DataConversion.DigitalOut[4]);
        }
        private void Digi5_Toggle(object sender, RoutedEventArgs e)
        {
            DataConversion.DigitalOut[5] = Convert.ToByte(Digi5.IsOn);
            DigitalOutputCANSend.SendDigitalOutputData(5, DataConversion.DigitalOut[5]);
        }
        private void Digi6_Toggle(object sender, RoutedEventArgs e)
        {
            DataConversion.DigitalOut[6] = Convert.ToByte(Digi6.IsOn);
            DigitalOutputCANSend.SendDigitalOutputData(6, DataConversion.DigitalOut[6]);
        }
        private void Digi7_Toggle(object sender, RoutedEventArgs e)
        {
            DataConversion.DigitalOut[7] = Convert.ToByte(Digi7.IsOn);
            DigitalOutputCANSend.SendDigitalOutputData(7, DataConversion.DigitalOut[7]);
        }
        private void Digi8_Toggle(object sender, RoutedEventArgs e)
        {
            DataConversion.DigitalOut[8] = Convert.ToByte(Digi8.IsOn);
            DigitalOutputCANSend.SendDigitalOutputData(8, DataConversion.DigitalOut[8]);
        }
        private void Digi9_Toggle(object sender, RoutedEventArgs e)
        {
            DataConversion.DigitalOut[9] = Convert.ToByte(Digi9.IsOn);
            DigitalOutputCANSend.SendDigitalOutputData(9, DataConversion.DigitalOut[9]);
        }
        private void Digi10_Toggle(object sender, RoutedEventArgs e)
        {
            DataConversion.DigitalOut[10] = Convert.ToByte(Digi10.IsOn);
            DigitalOutputCANSend.SendDigitalOutputData(10, DataConversion.DigitalOut[10]);
        }
        private void Digi11_Toggle(object sender, RoutedEventArgs e)
        {
            DataConversion.DigitalOut[11] = Convert.ToByte(Digi11.IsOn);
            DigitalOutputCANSend.SendDigitalOutputData(11, DataConversion.DigitalOut[11]);
        }
        private void Digi12_Toggle(object sender, RoutedEventArgs e)
        {
            DataConversion.DigitalOut[12] = Convert.ToByte(Digi12.IsOn);
            DigitalOutputCANSend.SendDigitalOutputData(12, DataConversion.DigitalOut[12]);
        }
        private void Digi13_Toggle(object sender, RoutedEventArgs e)
        {
            DataConversion.DigitalOut[13] = Convert.ToByte(Digi13.IsOn);
            DigitalOutputCANSend.SendDigitalOutputData(13, DataConversion.DigitalOut[13]);
        }
        private void Digi14_Toggle(object sender, RoutedEventArgs e)
        {
            DataConversion.DigitalOut[14] = Convert.ToByte(Digi14.IsOn);
            DigitalOutputCANSend.SendDigitalOutputData(14, DataConversion.DigitalOut[14]);
        }
        private void Digi15_Toggle(object sender, RoutedEventArgs e)
        {
            DataConversion.DigitalOut[15] = Convert.ToByte(Digi15.IsOn);
            DigitalOutputCANSend.SendDigitalOutputData(15, DataConversion.DigitalOut[15]);
        }

    }
}