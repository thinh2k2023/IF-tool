using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFiftool.Models;
using ClosedXML.Excel;
using System.Windows.Controls;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using WPFiftool.Views;
using System.Collections.ObjectModel;
using static WPFiftool.Models.Common_string;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using WPFiftool.ViewModels.CANViewModel;
using System.Windows.Threading;
using WPFiftool.Driver;
using DocumentFormat.OpenXml.Spreadsheet;
using WPFiftool.Models.CAN;

namespace WPFiftool.ViewModels.ConfigfileViewModel
{
    public partial class Read_file : Window
    {
        private const UInt16 digitalInputOffset = 0;        //16 signals
        private const UInt16 analogInputOffset = 16;        //16 signals
        private const UInt16 PWMInputOffset = 32;           //8 signals
        private const UInt16 ACInputOffset = 40;            //8 signals

        private const UInt16 digitalOutputOffset = 48;      //16 signals
        private const UInt16 analogOutputOffset = 64;       //16 signals
        private const UInt16 PWMOutputOffset = 80;          //8 signals
        private const UInt16 ACOutputOffset = 88;           //16 signals
        public static List<Common_string.Signal_Title> List_data_current_signal_monitor = new List<Common_string.Signal_Title>();
      
        public static List<T> Data_reset_list_temp = new List<T>(); /* Intermediate variable used for reset function */

        //private static string strPathRoot = AppDomain.CurrentDomain.BaseDirectory;
        //private static string strPath_load_config = Path.Combine(strPathRoot, "file_default");
        private static string Path_file_open_app;


        public static List<Common_string.Signal_Title> List_data_config_open_app = new List<Common_string.Signal_Title>();
        public static List<Common_string.Auto_control_Title> List_data_autocontrol_open_app = new List<Common_string.Auto_control_Title>();


        private static IXLWorksheet Worksheet_1, Worksheet_2;

        public ObservableCollection<Signal_Title> ProductCollection = new ObservableCollection<Signal_Title>(); //contain all data of excel
        public ObservableCollection<Signal_Title> ProductCollection2 = new ObservableCollection<Signal_Title>();  //contain just only data show in the datagrid
        public static List<Common_string.Signal_Title> List_data_import_completed = new List<Common_string.Signal_Title>();


        public Read_file()
        {
            //USBCanDriver.dataUpdatedEvent += ReceivedEventCallback;      //register event
        }

        //public void ReceivedEventCallback(object sender, EventArgs e)
        //{
        //    Dispatcher.Invoke(() =>
        //    {
        //        updateDataFromCAN();
        //    });
        //}

        //public void updateDataFromCAN()
        //{

        //    for (UInt16 i = 0; i < 16; i++)
        //    {
        //        //ProductCollection[i + digitalInputOffset].RawValue = (CANRXRawData._DigitalInputRawData.digitalData[i]).ToString();
        //        //ProductCollection[i + analogInputOffset].RawValue = (CANRXRawData._AnalogInputRawData.analogData[i]).ToString();
        //        //ProductCollection[i + analogInputOffset].Value = ((CANRXRawData._AnalogInputRawData.analogData[i]) * float.Parse(ProductCollection[i + analogInputOffset].Resolution) + float.Parse(ProductCollection[i + analogInputOffset].Offset)).ToString();



        //        //ProductCollection[i + digitalOutputOffset].RawValue = (_CANRawRXViewModel._CANRawData._DigitalInputRawData.digitalData[i]).ToString();
        //        //ProductCollection[i + analogOutputOffset].RawValue = (_CANRawRXViewModel._CANRawData._AnalogInputRawData.analogData[i]).ToString();
        //    }

        //    for (UInt16 i = 0; i < 8; i++)
        //    {
        //        //ProductCollection[i + PWMInputOffset].RawValue = (_CANRawRXViewModel._CANRawData._PWMInputRawData.dutyCycle).ToString();
        //        //ProductCollection[i + PWMOutputOffset].RawValue = (_CANRawRXViewModel._CANRawData._AnalogInputRawData.analogData[i]).ToString();
        //    }
        //}
        public static void Get_path_open_app()
        {
            /*check to see when the file was last opened*/
            if (!string.IsNullOrEmpty(Properties.Settings.Default.ImportedFilePath) && System.IO.File.Exists(Properties.Settings.Default.ImportedFilePath)) /*has path of file was last opened*/
            {
                //MessageBox.Show(Properties.Settings.Default.ImportedFilePath, "Loading file", MessageBoxButton.OK, MessageBoxImage.Information);
                Path_file_open_app = Properties.Settings.Default.ImportedFilePath;
            }
            else if ((Properties.Settings.Default.List_save_test = true) && (Path_file_open_app == null))/*has not path of file was last opened*/
            {
                // MessageBox.Show("File not found ", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                Read_file.Load_default_file();
            }
            else
            {
                Read_file.default_screen();
                /*File compression rules are also restarted the first time*/ // test khởi động lần đầu bằng cách nén phần mềm
                Properties.Settings.Default.ImportedFilePath = string.Empty;
            }
        }


        static bool File_running(string filePath)
        {
            try
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))/* create an open object to read the file operation*/
                {
                    return false;
                }
            }
            catch (IOException)
            {
                // Nếu xảy ra IOException, có nghĩa là tệp đang được sử dụng
                return true;
            }
        }

        static bool Has_not_access(string Path)
        {
            try
            {
                AuthorizationRuleCollection rules = File.GetAccessControl(Path).GetAccessRules(true, true, typeof(SecurityIdentifier));

                foreach (AuthorizationRule rule in rules)
                {
                    if (rule is FileSystemAccessRule fileRule)
                    {
                        // Kiểm tra quyền đọc và quyền ghi
                        if ((fileRule.FileSystemRights & (FileSystemRights.Read | FileSystemRights.Write)) == (FileSystemRights.Read | FileSystemRights.Write) &&
                            fileRule.AccessControlType == AccessControlType.Allow &&
                            WindowsIdentity.GetCurrent().User.Equals(fileRule.IdentityReference))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (UnauthorizedAccessException)
            {
                // Xử lý ngoại lệ truy cập không được phép
                return true;
            }
        }


        public static void Load_file_start_app()
        {
            Get_path_open_app();
            if (Path_file_open_app != null)
            {
                // check file is exist
                if (!File.Exists(Path_file_open_app))
                {
                    MessageBox.Show("File not found ", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Read_file.Load_default_file();
                }
                else
                {
                    /*do nothing*/
                }

                /* check format file "xlsx" */
                string file_Extension = Path.GetExtension(Path_file_open_app);
                if (file_Extension != ".xlsx" && file_Extension != ".xls")
                {
                    MessageBox.Show("Invalid file format. Please choose an Excel file.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    /*do nothing*/
                }


                FileStream Open_file = null;    /* create an open object to read the file operation*/

                try
                {
                    Open_file = new FileStream(Path_file_open_app, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    XLWorkbook Workbook_start_app;
                    // Check if the file is in use
                    if (File_running(Path_file_open_app))
                    {
                        MessageBox.Show("The file is currently in use by another process", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        Workbook_start_app = new XLWorkbook(Open_file); /* initialize object using file"*/
                        Worksheet_1 = Workbook_start_app.Worksheet("ConfigData");
                        Worksheet_2 = Workbook_start_app.Worksheet("AutoControl");
                        /* start read file*/
                        List_data_autocontrol_open_app.Clear();
                        get_data_sheet_ConfigData(Worksheet_1, DataConversion.Data_start_app);
                        DataConversion.data_signal_monitor_temp = DataConversion.Data_start_app;                       
                        DataConversion.data_current_signal_monitor = DataConversion.Data_start_app;
                        List_data_current_signal_monitor = new List<Common_string.Signal_Title>(List_read_sheet_config_signal_monitor);

                        if (flag_press_clear)
                        {
                            Data_clear_signal_monitor = new List<Common_string.Signal_Title>(List_data_current_signal_monitor);

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                finally
                {
                    Open_file?.Close(); // nếu không null thì gọi close , nếu null thì không gọi
                }
            }
            else
            {

                if (DataConversion.Data_clear.Analog_out.Count != 0)
                {
                    MessageBox.Show("load default file ", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    DataConversion.Data_start_app = DataConversion.Data_clear;
                    DataConversion.data_signal_monitor_temp = DataConversion.Data_clear;
                    DataConversion.data_current_signal_monitor = DataConversion.Data_clear;
                }
                else
                {
                    MessageBox.Show("load default screen", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    DataConversion.Data_start_app = DataConversion.Data_default_screen;
                    DataConversion.data_signal_monitor_temp = DataConversion.Data_default_screen;
                    DataConversion.data_current_signal_monitor = DataConversion.Data_default_screen;
                }

            }
        }
        public void readDataFromExcel(List<Common_string.Signal_Title> ListForRead)
        {
            //Read_file.load_File_Import();
            //Read_file.List_data_current
            //add data from excel to observableCollection
            foreach (var signal in ListForRead)
            {
                string typeValue = signal.Type;
                string Channel = signal.Channel;
                string IO = signal.IO;
                string SignalName = signal.SignalName + " " + signal.Element;
                string Value = signal.Value;
                string Unit = signal.Unit;
                string Min = signal.MinLabel;
                string Max = signal.MaxLabel;
                string Resolution = signal.Resolution;
                string Offset = signal.Offset;
                string VisibleInput = signal.VisibleMonitor;
                string OrderMonitor = signal.OrderMonitor;
                string VisibleOutput = signal.VisibleOutput;
                string OrderOutput = signal.OrderOutput;

                ProductCollection.Add(new Signal_Title() { Type = typeValue, Channel = Channel, IO = IO, SignalName = SignalName, Value = Value, Unit = Unit, MinLabel = Min, MaxLabel = Max, Resolution = Resolution, Offset = Offset, VisibleMonitor = VisibleInput, OrderMonitor = OrderMonitor, VisibleOutput = VisibleOutput, OrderOutput = OrderOutput });
            }
        }
        public void AddSignalToMonitor()
        {

        }
    }
}
