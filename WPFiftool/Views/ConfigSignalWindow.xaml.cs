using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFiftool.ViewModels.SignalMonitor;
using static WPFiftool.Models.Common_string;
using WPFiftool.Models.ConfigSignal;
using WPFiftool.ViewModels.ConfigSignalVM;
using DocumentFormat.OpenXml.InkML;
using DocumentFormat.OpenXml.Vml.Spreadsheet;

using WPFiftool.Models;
using ControlzEx.Standard;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using System.Web.UI;
using OfficeOpenXml.FormulaParsing.Utilities;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;

namespace WPFiftool.Views
{
    /// <summary>
    /// Interaction logic for ConfigSignalWindow.xaml
    /// </summary>
    public partial class ConfigSignalWindow : Window
    {

        private const UInt16 digitalInputOffset = 0;        //16 signals
        private const UInt16 analogInputOffset = 16;        //16 signals
        private const UInt16 PWMInputOffset = 32;           //8 signals
        private const UInt16 ACInputOffset = 40;            //8 signals

        private const UInt16 DigitalOutputOffset = 56;      //16 signals
        private const UInt16 AnalogOutputOffset = 72;       //16 signals
        private const UInt16 PWMOutputOffset = 88;          //8 signals
        private const UInt16 ACOutputOffset = 96;           //16 signals

        // declearate some variable for onpen window one time
        const Int16 OFF = 0;
        const Int16 ON = 1;

        public ConfigSignalWindow()
        {
            InitializeComponent();
            SigmntDG.ItemsSource = ConfigSignalHandle.SignalMonitorConfigData;

            SigmntDG.CellEditEnding += DataGrid_CellEditEnding;
        }


        //text input 

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var DataGridTemp = (DataGrid)sender;

            //var PreviousConfigSignal = (ConfigSignalModel)DataGridTemp.SelectedValue;
            var PreviousConfigSignal = (ConfigSignalModel)e.Row.Item;



            Console.WriteLine(PreviousConfigSignal.MaxLabel);
            //Console.WriteLine(EditingConfigSignal.MaxLabel);

            String editedValue = "";
            if (e.EditingElement is TextBox textBox)
            {
                editedValue = textBox.Text;
                Console.WriteLine(editedValue);
                //Console.WriteLine($"{editedValue}");

            }

            //configSignalModelTemp = (ConfigSignalModel)e.Row.Item;

            //Console.WriteLine(configSignalModelTemp.Type);
            //Console.WriteLine(configSignalModelTemp.IO);
            //Console.WriteLine(configSignalModelTemp.Channel);

            //Digital input: id 0 to 15

            //analog input: id 16 to 31
            //Console.WriteLine(configSignalModelTemp.ID);

            //e.Cancel = true;


            if (PreviousConfigSignal.ID >= digitalInputOffset && PreviousConfigSignal.ID < analogInputOffset) //for digital input
            {
                //CheckTextInputAnalogInput(editedValue, e);
                //e.Cancel = true;
                //ConfigSignalHandle.SignalMonitorConfigData[15].MaxLabel = "100000";
            }

            else if (PreviousConfigSignal.ID >= analogInputOffset && PreviousConfigSignal.ID < PWMInputOffset) //for analog input
            {
                //CheckTextInputAnalogInput(editedValue, e);
                //e.Cancel = true;
                //ConfigSignalHandle.SignalMonitorConfigData[15].MaxLabel = "100000";
                string a = PreviousConfigSignal.MinLabel;
                string b = a;
                CheckMaxAnalogInput(PreviousConfigSignal.ID, editedValue, b, e);
            }


            if (PreviousConfigSignal.ID == 16)
            {
                //CheckTextInputAnalogInput(editedValue, e);
                //e.Cancel = true;
                //ConfigSignalHandle.SignalMonitorConfigData[15].MaxLabel = "100000";
            }

            //e.Cancel = true;
        }


        private void CheckMaxAnalogInput(byte ID, string MaxAnalogInputDataEditing, string MaxAnalogInputDataPrevious, DataGridCellEditEndingEventArgs e)
        {
            bool flagTemp = false;
            double AnalogInputDataTemp;
            try
            {

                AnalogInputDataTemp = Convert.ToDouble(MaxAnalogInputDataEditing);
                //Console.WriteLine(AnalogInputDataTemp);
            }
            catch
            {
                //MessageBox.Show("Input mus be double value");
                
                flagTemp = true;
            }

            if (flagTemp != false)
            {
                ConfigSignalHandle.SignalMonitorConfigData[ID].MinLabel = MaxAnalogInputDataPrevious.ToString();
            }

        Console.WriteLine(MaxAnalogInputDataPrevious);
        }



        //InputMonitor.SignalMonitorDataSave\
        static UInt16 cnt_temp = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cnt_temp++;
            InputMonitor.SignalMonitorDataSave.Clear();
            InputMonitor.SignalMonitorDataSaveExcel.Clear();
            foreach (ConfigSignalModel signal in ConfigSignalHandle.SignalMonitorConfigData)
            {
                string typeValue = signal.Type;
                string Channel = signal.Channel;
                string IO = signal.IO;
                string SignalName = signal.SignalName;
                string Element = signal.Element;
                string Value = signal.Value;
                string Unit = signal.Unit;
                string MinLabel = signal.MinLabel;
                string MaxLabel = signal.MaxLabel;
                string Resolution = signal.Resolution;
                string Offset = signal.Offset;

                string VisibleInput;

                if (signal.IsVisible == true)
                {
                    VisibleInput = "Yes";
                }
                else
                {
                    VisibleInput = "No";
                }
                string OrderMonitor = signal.OrderMonitor;
                string VisibleOutput = signal.VisibleOutput;
                string OrderOutput = signal.OrderOutput;

                InputMonitor.SignalMonitorDataSave.Add(new Signal_Title()
                {
                    Type = typeValue,
                    Channel = Channel,
                    IO = IO,
                    SignalName = SignalName,
                    Element = Element,
                    Value = Value,
                    Unit = Unit,
                    MinLabel = MinLabel,
                    MaxLabel = MaxLabel,
                    Resolution = Resolution,
                    Offset = Offset,
                    VisibleMonitor = VisibleInput,
                    OrderMonitor = OrderMonitor,
                    VisibleOutput = VisibleOutput,
                    OrderOutput = OrderOutput
                });

                InputMonitor.SignalMonitorDataSaveExcel.Add(new Signal_Title()
                {
                    Type = typeValue,
                    Channel = Channel,
                    IO = IO,
                    SignalName = signal.SignalName.Substring(0, signal.SignalName.Length - signal.Element.Length),
                    Element = Element,
                    Value = Value,
                    Unit = Unit,
                    MinLabel = MinLabel,
                    MaxLabel = MaxLabel,
                    Resolution = Resolution,
                    Offset = Offset,
                    VisibleMonitor = VisibleInput,
                    OrderMonitor = OrderMonitor,
                    VisibleOutput = VisibleOutput,
                    OrderOutput = OrderOutput
                });

            }





            InputMonitor.FilterData();

            ConfigSignalHandle.SignalMonitorConfigData[0].Resolution = cnt_temp.ToString();
        }

        private void StartUpProgramLoaded(object sender, RoutedEventArgs e)
        {
            DataConversion.ShowConfigSignalWindow = ON;
        }

        private void CloseProgramUnloaded(object sender, RoutedEventArgs e)
        {
            DataConversion.ShowConfigSignalWindow = OFF;
        }
    }
}
