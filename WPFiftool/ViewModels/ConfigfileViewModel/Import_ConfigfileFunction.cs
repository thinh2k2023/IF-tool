using ClosedXML.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFiftool.Models;
using WPFiftool.ViewModels.ConfigfileViewModel;
using Microsoft.Win32;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using static WPFiftool.Models.Common_string;
using Xamarin.Forms;

namespace WPFiftool.ViewModels.ConfigfileViewModel
{
    public partial class Read_file
    {
        private static bool Status_import_error = false;/* Used when reading the wrong file and not selecting the import file*/
        public static List<Common_string.Signal_Title> List_read_sheet_config_signal_monitor = new List<Common_string.Signal_Title>();
        public static List<Common_string.Auto_control_Title> List_data_import_autocontrol_completed = new List<Common_string.Auto_control_Title>();

        public static void load_File_Import()
        {
            OpenFileDialog openFileConfigDialog = new OpenFileDialog(); /*Creates a file opening dialog box, allows the user to select a file from the file syste*/
            openFileConfigDialog.Filter = "Excel Files|*.xls;*.xlsx"; /*filter*/
            String Path_file_import_s = "";

            /* Selected file excel and press OK */
            if (openFileConfigDialog.ShowDialog() == true)
            {
                Path_file_import_s = openFileConfigDialog.FileName; /* select folder */
                Properties.Settings.Default.ImportedFilePath = Path_file_import_s;
                Properties.Settings.Default.Save();
                XLWorkbook Workbook_import;

                FileStream fileStream = new FileStream(Path_file_import_s, FileMode.Open, FileAccess.Read, FileShare.ReadWrite); /*create an object to read*/
                if (File_running(Path_file_import_s))
                {
                    MessageBox.Show("The file is currently in use by another process", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    try
                    {
                        Workbook_import = new XLWorkbook(fileStream);
                        Worksheet_1 = Workbook_import.Worksheet("ConfigData");
                        Worksheet_2 = Workbook_import.Worksheet("AutoControl");

                        get_data_sheet_ConfigData(Worksheet_1, DataConversion.Data_import);
                        get_data_sheet_AutoControl(Worksheet_2);
                        DataConversion.data_signal_monitor_temp = DataConversion.Data_import;
                        DataConversion.data_current_signal_monitor = DataConversion.Data_import;
                        // Check if the list is empty
                        if (!Common_string.List_Empty(List_read_sheet_config_signal_monitor) && Status_import_error == false)
                        {
                            //List_title_default_screen.Clear();
                            List_data_current_signal_monitor = new List<Common_string.Signal_Title>(List_read_sheet_config_signal_monitor);


                        }
                        else
                        {
                            /*do nothing*/
                        }
                    }
                    catch
                    {
                        //MessageBox.Show("This file cannot be used", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    finally
                    {
                        fileStream.Close();
                    }
                }

            }
            /*file not select and press ok*/
            else
            {
                Path_file_import_s = string.Empty;
                MessageBox.Show("File not selected", " Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private static void get_data_sheet_AutoControl(IXLWorksheet sheet)
        {

            List_data_import_autocontrol_completed.Clear();
            /*Create a dictionary to store the value you want to find*/
            Dictionary<string, uint> dctSignalCol_autocontrol = new Dictionary<string, uint>
            {
                { "Information_temp", Function_Excel.Get_index_column(sheet, 1, "Information") },
                { "Setting1_temp", Function_Excel.Get_index_column(sheet, 1, "Setting1") },
                { "Setting2_temp", Function_Excel.Get_index_column(sheet, 1, "Setting2") },
                { "Setting3_temp", Function_Excel.Get_index_column(sheet, 1, "Setting3") },
                { "Setting4_temp", Function_Excel.Get_index_column(sheet, 1, "Setting4") },
                { "Setting5_temp", Function_Excel.Get_index_column(sheet, 1, "Setting5") },
            };


            for (uint idx_ub = 2; idx_ub <= sheet.LastRowUsed().RowNumber(); idx_ub++) /*search each column*/
            {
                Common_string.Auto_control_Title signal = new Common_string.Auto_control_Title();/*Save the string value of each column*/
                signal.Title = Function_Excel.get_value_cell(sheet, 1, idx_ub - 1); /* get title */
                signal.Information = Function_Excel.get_value_cell(sheet, idx_ub, dctSignalCol_autocontrol["Information_temp"]);
                signal.Setting1 = Function_Excel.get_value_cell(sheet, idx_ub, dctSignalCol_autocontrol["Setting1_temp"]);
                signal.Setting2 = Function_Excel.get_value_cell(sheet, idx_ub, dctSignalCol_autocontrol["Setting2_temp"]);
                signal.Setting3 = Function_Excel.get_value_cell(sheet, idx_ub, dctSignalCol_autocontrol["Setting3_temp"]);
                signal.Setting4 = Function_Excel.get_value_cell(sheet, idx_ub, dctSignalCol_autocontrol["Setting4_temp"]);
                signal.Setting5 = Function_Excel.get_value_cell(sheet, idx_ub, dctSignalCol_autocontrol["Setting5_temp"]);

                List_data_import_autocontrol_completed.Add(signal);  /* get all the data*/

            }
        }
        private static void get_data_sheet_ConfigData(IXLWorksheet sheet, Common_string.Each_signal_data_origin dataListConfig)
        {
            // Clear all lists in dataListConfig
            dataListConfig.Digital_in.Clear();
            dataListConfig.Analog_in.Clear();
            dataListConfig.PWM_in_duty.Clear();
            dataListConfig.PWM_in_freq.Clear();
            dataListConfig.AC_in_rms.Clear();
            dataListConfig.AC_in_freq.Clear();
            dataListConfig.AC_in_peak_L.Clear();
            dataListConfig.AC_in_peak_H.Clear();
            dataListConfig.Digital_out.Clear();
            dataListConfig.Analog_out.Clear();
            dataListConfig.PWM_out_duty.Clear();
            dataListConfig.PWM_out_freq.Clear();
            dataListConfig.AC_out_rms.Clear();
            dataListConfig.AC_out_freq.Clear();
            dataListConfig.AC_out_phase.Clear();
            dataListConfig.AC_out_type_wave.Clear();

            List_read_sheet_config_signal_monitor.Clear();
            /*Create a dictionary to store the value you want to find*/
            Dictionary<string, uint> dctSignalCol = new Dictionary<string, uint>
            {
                { "type_temp", Function_Excel.Get_index_column(sheet, 1, "Type") },
                { "Channel_temp", Function_Excel.Get_index_column(sheet, 1, "Channel") },
                { "I/O_temp", Function_Excel.Get_index_column(sheet, 1, "I/O") },
                { "signal_name_temp", Function_Excel.Get_index_column(sheet, 1, "Signal name") },
                { "Element_temp", Function_Excel.Get_index_column(sheet, 1, "Element") },
                { "value_temp", Function_Excel.Get_index_column(sheet, 1, "Value") },
                { "Unit_temp", Function_Excel.Get_index_column(sheet, 1, "Unit") },
                { "Min_temp", Function_Excel.Get_index_column(sheet, 1, "Min (label)") },
                { "Max_temp", Function_Excel.Get_index_column(sheet, 1, "Max (label)") },
                { "Resolution_temp", Function_Excel.Get_index_column(sheet, 1, "Resolution") },
                { "Offset_temp", Function_Excel.Get_index_column(sheet, 1, "Offset") },
                { "Visible_monitor_temp", Function_Excel.Get_index_column(sheet, 1, "Visible monitor") },
                { "Order_monitor_temp", Function_Excel.Get_index_column(sheet, 1, "Order monitor") },
                { "Visible_output_temp", Function_Excel.Get_index_column(sheet, 1, "Visible output") },
                { "Order_output_temp", Function_Excel.Get_index_column(sheet, 1, "Order output") }
            };


            for (uint idx_ub = 2; idx_ub <= sheet.LastRowUsed().RowNumber(); idx_ub++) /*search each column*/
            {
                Common_string.Signal_Title signal = new Common_string.Signal_Title();/*Save the string value of each column*/
                signal.Title = Function_Excel.get_value_cell(sheet, 1, idx_ub - 1); /* get title */
                signal.Type = Function_Excel.get_value_cell(sheet, idx_ub, dctSignalCol["type_temp"]);
                signal.Channel = Function_Excel.get_value_cell(sheet, idx_ub, dctSignalCol["Channel_temp"]);
                signal.IO = Function_Excel.get_value_cell(sheet, idx_ub, dctSignalCol["I/O_temp"]);
                signal.SignalName = Function_Excel.get_value_cell(sheet, idx_ub, dctSignalCol["signal_name_temp"]);
                signal.Element = Function_Excel.get_value_cell(sheet, idx_ub, dctSignalCol["Element_temp"]);
                signal.Value = Function_Excel.get_value_cell(sheet, idx_ub, dctSignalCol["value_temp"]);
                signal.Unit = Function_Excel.get_value_cell(sheet, idx_ub, dctSignalCol["Unit_temp"]);
                signal.MinLabel = Function_Excel.get_value_cell(sheet, idx_ub, dctSignalCol["Min_temp"]);
                signal.MaxLabel = Function_Excel.get_value_cell(sheet, idx_ub, dctSignalCol["Max_temp"]);
                signal.Resolution = Function_Excel.get_value_cell(sheet, idx_ub, dctSignalCol["Resolution_temp"]);
                signal.Offset = Function_Excel.get_value_cell(sheet, idx_ub, dctSignalCol["Offset_temp"]);
                signal.VisibleMonitor = Function_Excel.get_value_cell(sheet, idx_ub, dctSignalCol["Visible_monitor_temp"]);
                signal.OrderMonitor = Function_Excel.get_value_cell(sheet, idx_ub, dctSignalCol["Order_monitor_temp"]);
                signal.VisibleOutput = Function_Excel.get_value_cell(sheet, idx_ub, dctSignalCol["Visible_output_temp"]);
                signal.OrderOutput = Function_Excel.get_value_cell(sheet, idx_ub, dctSignalCol["Order_output_temp"]);

                List_read_sheet_config_signal_monitor.Add(signal);  /* get all the data*/

                if (flag_press_clear == true)
                {
                    /*This flag uses a default file that is only read once at startup and the list value is not changed when running other functions, and because it shares this "get data sheet" function, note: if you don't want the flag, use the clear code function. add similar function "get data sheet".*/
                    List_data_config_default_file.Add(signal);/* list of clear function*/
                }
                else
                {
                    /*do nothing*/
                }

                /* start reserve:  assign data to struct for show each signal */
                if (signal.Type == "Digital")
                {
                    if (signal.IO == "I")
                    {
                        dataListConfig.Digital_in.Add(signal);
                    }
                    else if (signal.IO == "O")
                    {
                        dataListConfig.Digital_out.Add(signal);
                    }
                    else
                    {
                        /*do nothing*/
                    }
                }
                else if (signal.Type == "Analog")
                {
                    if (signal.IO == "I")
                    {
                        dataListConfig.Analog_in.Add(signal);
                    }
                    else if (signal.IO == "O")
                    {
                        dataListConfig.Analog_out.Add(signal);
                    }
                    else
                    {
                        /*do nothing*/
                    }
                }
                else if (signal.Type == "PWM")
                {
                    if (signal.IO == "I" && signal.Element == "Duty")
                    {
                        dataListConfig.PWM_in_duty.Add(signal);
                    }
                    else if (signal.IO == "I" && signal.Element == "Frequency")
                    {
                        dataListConfig.PWM_in_freq.Add(signal);
                    }
                    else if (signal.IO == "O" && signal.Element == "Duty")
                    {
                        dataListConfig.PWM_out_duty.Add(signal);
                    }
                    else if (signal.IO == "O" && signal.Element == "Frequency")
                    {
                        dataListConfig.PWM_out_freq.Add(signal);
                    }
                    else
                    {
                        /*do nothing*/
                    }
                }
                else if (signal.Type == "AC")
                {
                    if (signal.IO == "I" && signal.Element == "RMS")
                    {
                        dataListConfig.AC_in_rms.Add(signal);
                    }
                    else if (signal.IO == "I" && signal.Element == "Frequency")
                    {
                        dataListConfig.AC_in_freq.Add(signal);
                    }
                    else if (signal.IO == "I" && signal.Element == "Peak L")
                    {
                        dataListConfig.AC_in_peak_L.Add(signal);
                    }
                    else if (signal.IO == "I" && signal.Element == "Peak H")
                    {
                        dataListConfig.AC_in_peak_H.Add(signal);
                    }
                    else if (signal.IO == "O" && signal.Element == "RMS")
                    {
                        dataListConfig.AC_out_rms.Add(signal);
                        /*because AC output 0 has no Phase*/
                        if (signal.IO == "O" && signal.Element == "RMS" && signal.Channel == "0")
                        {
                            Common_string.Signal_Title phase_ac_CH0 = new Common_string.Signal_Title();
                            phase_ac_CH0.Element = "0";
                            phase_ac_CH0.VisibleMonitor = "-";
                            dataListConfig.AC_out_phase.Add(phase_ac_CH0);
                        }
                        /*because AC output 0 has no Phase*/
                    }
                    else if (signal.IO == "O" && signal.Element == "Frequency")
                    {
                        dataListConfig.AC_out_freq.Add(signal);
                    }
                    else if (signal.IO == "O" && signal.Element == "Typewave")
                    {
                        dataListConfig.AC_out_type_wave.Add(signal);
                    }
                    else if (signal.IO == "O" && signal.Element == "Phase")
                    {
                        dataListConfig.AC_out_phase.Add(signal);
                    }
                    else
                    {
                        /*do nothing*/
                    }
                }
                else
                {
                    /*do nothing*/
                }


                /* end reserve */
            }
            if (Common_string.List_Empty(List_read_sheet_config_signal_monitor))
            {
                MessageBox.Show("Error empty: file being imported!", " Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Status_import_error = false; /* Used when reading the wrong file and not selecting the import file*/
                // Check if the list is empty, check structure
                for (int i = 0; i < Common_string.check_format.Length; i++)
                {
                    if (Common_string.check_format[i] != List_read_sheet_config_signal_monitor[i].Title)
                    {
                        Status_import_error = true;
                        MessageBox.Show("worksheet content error", " Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        /*do nothing*/
                    }
                }
                if (Status_import_error == true)
                {
                    List_read_sheet_config_signal_monitor.Clear();
                }
                else
                {
                    /*do nothing*/
                }
            }
        }

    }
}
