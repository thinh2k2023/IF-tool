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
using System.ComponentModel;
using WPFiftool.ViewModels.SignalMonitor;
using WPFiftool.ViewModels.CANViewModel;
using WPFiftool.ViewModels.ControlOutputVM;

namespace WPFiftool.Views
{

    /// <summary>
    /// Interaction logic for OutputControl.xaml
    /// </summary>
    public partial class ControlOutputWindow : Window, INotifyPropertyChanged
    {

        //khai báo data conversion mới để binding data từ DataConversion
        //public DataConversion DataConversion = new DataConversion();

        private OutputMonitor _OutputMonitor = new OutputMonitor();


        /// <summary>
        /// Biến lưu trữ đang chọn border nào tại 
        /// </summary>
        private int _selectedBorderRemove = 0;

        /// <summary>
        /// Tạo source border để dễ dàng mở rộng và quản lý
        /// </summary>
        private Dictionary<int, Border> ComponentBorderDict = new Dictionary<int, Border>();
        private Dictionary<int, CheckBox> ComponentChekcBoxDict = new Dictionary<int, CheckBox>();


        // array for all components
        int[] ComponentNumber = new int[40] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39 };

        // declearate array for visibility of each component
        int[] ComponentVisibilityStt = new int[40];

        const Int16 DIG_ARRAY_LEN = 16;
        const Int16 ANA_ARRAY_LEN = 16;
        const Int16 PWM_ARRAY_LEN = 4;
        const Int16 AC_ARRAY_LEN = 4;

        // khai báo phím bấm
        public Int16 MINUS_BTN = -1;
        public Int16 NO_USE_BTN = 0;
        public Int16 PLUS_BTN = 1;

        const UInt16 ANA_CH0 = 0, ANA_CH1 = 1, ANA_CH2 = 2, ANA_CH3 = 3, ANA_CH4 = 4, ANA_CH5 = 5, ANA_CH6 = 6, ANA_CH7 = 7, ANA_CH8 = 8, ANA_CH9 = 9, ANA_CH10 = 10, ANA_CH11 = 11, ANA_CH12 = 12, ANA_CH13 = 13, ANA_CH14 = 14, ANA_CH15 = 15;
        const UInt16 AC_CH0 = 0, AC_CH1 = 1, AC_CH2 = 2, AC_CH3 = 3;
        const UInt16 PWM_CH0 = 0, PWM_CH1 = 1, PWM_CH2 = 2, PWM_CH3 = 3;

        const Int16 OFF = 0;
        const Int16 ON = 1;

        const Int16 DEFAULT_FILE = 0;
        const Int16 START_APP = 1;

        // declearation storage value temporary for save state output control windown close and open again
        public static Int16[] DigitalOutTemp = new Int16[16]; // declearation storage value for each channel of output control
        public static double[] AnalogOutTemp = new double[16];
        public static double[] PWMDutyOutTemp = new double[4] { -1, -1, -1, -1 }; // declearation for each temporary variable
        public static UInt32[] PWMFreqOutTemp = new UInt32[4];
        public static double[] ACRmsOutTemp = new double[4];
        public static double[] ACFreqOutTemp = new double[4];
        public static Int16[] ACPsOutTemp = new Int16[4];
        public static UInt16[] ACTypeWaveOutTemp = new UInt16[4];
        public static int[] ComponentVisibilityTemp = new int[40];
        public static string[] ComponentNameTemp = new string[40];

        CANRawTXViewModel _CANRawTXViewModel = new CANRawTXViewModel();
        private static Int16 select_excel_file = START_APP; // variable for select config at startup program


        private string[] anaSuffix = new string[16];

        public string AnaUnitTypes0
        {
            get { return anaSuffix[0]; }
            set
            {
                anaSuffix[0] = value;
                OnPropertyChanged(nameof(AnaUnitTypes0));
            }
        }
        public string AnaUnitTypes1
        {
            get { return anaSuffix[1]; }
            set
            {
                anaSuffix[1] = value;
                OnPropertyChanged(nameof(AnaUnitTypes1));
            }
        }
        public string AnaUnitTypes2
        {
            get { return anaSuffix[2]; }
            set
            {
                anaSuffix[2] = value;
                OnPropertyChanged(nameof(AnaUnitTypes2));
            }
        }
        public string AnaUnitTypes3
        {
            get { return anaSuffix[3]; }
            set
            {
                anaSuffix[3] = value;
                OnPropertyChanged(nameof(AnaUnitTypes3));
            }
        }
        public string AnaUnitTypes4
        {
            get { return anaSuffix[4]; }
            set
            {
                anaSuffix[4] = value;
                OnPropertyChanged(nameof(AnaUnitTypes4));
            }
        }
        public string AnaUnitTypes5
        {
            get { return anaSuffix[5]; }
            set
            {
                anaSuffix[5] = value;
                OnPropertyChanged(nameof(AnaUnitTypes5));
            }
        }
        public string AnaUnitTypes6
        {
            get { return anaSuffix[6]; }
            set
            {
                anaSuffix[6] = value;
                OnPropertyChanged(nameof(AnaUnitTypes6));
            }
        }
        public string AnaUnitTypes7
        {
            get { return anaSuffix[7]; }
            set
            {
                anaSuffix[7] = value;
                OnPropertyChanged(nameof(AnaUnitTypes7));
            }
        }
        public string AnaUnitTypes8
        {
            get { return anaSuffix[8]; }
            set
            {
                anaSuffix[8] = value;
                OnPropertyChanged(nameof(AnaUnitTypes8));
            }
        }
        public string AnaUnitTypes9
        {
            get { return anaSuffix[9]; }
            set
            {
                anaSuffix[9] = value;
                OnPropertyChanged(nameof(AnaUnitTypes9));
            }
        }
        public string AnaUnitTypes10
        {
            get { return anaSuffix[10]; }
            set
            {
                anaSuffix[10] = value;
                OnPropertyChanged(nameof(AnaUnitTypes10));
            }
        }
        public string AnaUnitTypes11
        {
            get { return anaSuffix[11]; }
            set
            {
                anaSuffix[11] = value;
                OnPropertyChanged(nameof(AnaUnitTypes11));
            }
        }
        public string AnaUnitTypes12
        {
            get { return anaSuffix[12]; }
            set
            {
                anaSuffix[12] = value;
                OnPropertyChanged(nameof(AnaUnitTypes12));
            }
        }
        public string AnaUnitTypes13
        {
            get { return anaSuffix[13]; }
            set
            {
                anaSuffix[13] = value;
                OnPropertyChanged(nameof(AnaUnitTypes13));
            }
        }
        public string AnaUnitTypes14
        {
            get { return anaSuffix[14]; }
            set
            {
                anaSuffix[14] = value;
                OnPropertyChanged(nameof(AnaUnitTypes14));
            }
        }
        public string AnaUnitTypes15
        {
            get { return anaSuffix[15]; }
            set
            {
                anaSuffix[15] = value;
                OnPropertyChanged(nameof(AnaUnitTypes15));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string newName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(newName));
            }
        }


        public ControlOutputWindow()
        {

            InitializeComponent();
            this.DataContext = this; // this command for binding data

            #region Dictionary declaration
            // Khởi tạo source Border Dictionary
            ComponentBorderDict.Add(ComponentNumber[0], this.Border_Digi0); // Digital component
            ComponentBorderDict.Add(ComponentNumber[1], this.Border_Digi1);
            ComponentBorderDict.Add(ComponentNumber[2], this.Border_Digi2);
            ComponentBorderDict.Add(ComponentNumber[3], this.Border_Digi3);
            ComponentBorderDict.Add(ComponentNumber[4], this.Border_Digi4);
            ComponentBorderDict.Add(ComponentNumber[5], this.Border_Digi5);
            ComponentBorderDict.Add(ComponentNumber[6], this.Border_Digi6);
            ComponentBorderDict.Add(ComponentNumber[7], this.Border_Digi7);
            ComponentBorderDict.Add(ComponentNumber[8], this.Border_Digi8);
            ComponentBorderDict.Add(ComponentNumber[9], this.Border_Digi9);
            ComponentBorderDict.Add(ComponentNumber[10], this.Border_Digi10);
            ComponentBorderDict.Add(ComponentNumber[11], this.Border_Digi11);
            ComponentBorderDict.Add(ComponentNumber[12], this.Border_Digi12);
            ComponentBorderDict.Add(ComponentNumber[13], this.Border_Digi13);
            ComponentBorderDict.Add(ComponentNumber[14], this.Border_Digi14);
            ComponentBorderDict.Add(ComponentNumber[15], this.Border_Digi15);
            ComponentBorderDict.Add(ComponentNumber[16], this.Border_Ana0); // Analog component
            ComponentBorderDict.Add(ComponentNumber[17], this.Border_Ana1);
            ComponentBorderDict.Add(ComponentNumber[18], this.Border_Ana2);
            ComponentBorderDict.Add(ComponentNumber[19], this.Border_Ana3);
            ComponentBorderDict.Add(ComponentNumber[20], this.Border_Ana4);
            ComponentBorderDict.Add(ComponentNumber[21], this.Border_Ana5);
            ComponentBorderDict.Add(ComponentNumber[22], this.Border_Ana6);
            ComponentBorderDict.Add(ComponentNumber[23], this.Border_Ana7);
            ComponentBorderDict.Add(ComponentNumber[24], this.Border_Ana8);
            ComponentBorderDict.Add(ComponentNumber[25], this.Border_Ana9);
            ComponentBorderDict.Add(ComponentNumber[26], this.Border_Ana10);
            ComponentBorderDict.Add(ComponentNumber[27], this.Border_Ana11);
            ComponentBorderDict.Add(ComponentNumber[28], this.Border_Ana12);
            ComponentBorderDict.Add(ComponentNumber[29], this.Border_Ana13);
            ComponentBorderDict.Add(ComponentNumber[30], this.Border_Ana14);
            ComponentBorderDict.Add(ComponentNumber[31], this.Border_Ana15);
            ComponentBorderDict.Add(ComponentNumber[32], this.Border_PWM0); // PWM component
            ComponentBorderDict.Add(ComponentNumber[33], this.Border_PWM1);
            ComponentBorderDict.Add(ComponentNumber[34], this.Border_PWM2);
            ComponentBorderDict.Add(ComponentNumber[35], this.Border_PWM3);
            ComponentBorderDict.Add(ComponentNumber[36], this.Border_AC0); // AC component
            ComponentBorderDict.Add(ComponentNumber[37], this.Border_AC1);
            ComponentBorderDict.Add(ComponentNumber[38], this.Border_AC2);
            ComponentBorderDict.Add(ComponentNumber[39], this.Border_AC3);

            // Khởi tạo source CheckBox Dictionary
            ComponentChekcBoxDict.Add(ComponentNumber[0], this.Digi0_checkedBox); // Digital component
            ComponentChekcBoxDict.Add(ComponentNumber[1], this.Digi1_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[2], this.Digi2_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[3], this.Digi3_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[4], this.Digi4_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[5], this.Digi5_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[6], this.Digi6_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[7], this.Digi7_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[8], this.Digi8_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[9], this.Digi9_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[10], this.Digi10_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[11], this.Digi11_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[12], this.Digi12_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[13], this.Digi13_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[14], this.Digi14_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[15], this.Digi15_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[16], this.Ana0_checkedBox); // Analog component
            ComponentChekcBoxDict.Add(ComponentNumber[17], this.Ana1_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[18], this.Ana2_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[19], this.Ana3_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[20], this.Ana4_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[21], this.Ana5_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[22], this.Ana6_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[23], this.Ana7_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[24], this.Ana8_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[25], this.Ana9_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[26], this.Ana10_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[27], this.Ana11_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[28], this.Ana12_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[29], this.Ana13_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[30], this.Ana14_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[31], this.Ana15_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[32], this.PWM0_checkedBox); // PWM component
            ComponentChekcBoxDict.Add(ComponentNumber[33], this.PWM1_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[34], this.PWM2_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[35], this.PWM3_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[36], this.AC0_checkedBox); // AC component
            ComponentChekcBoxDict.Add(ComponentNumber[37], this.AC1_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[38], this.AC2_checkedBox);
            ComponentChekcBoxDict.Add(ComponentNumber[39], this.AC3_checkedBox);
            #endregion
        }






        private void StartUpProgramLoaded(object sender, RoutedEventArgs e)
        {
            // author: -
            // description: this function will set value, name and visibility of each component
            // return:-
            // note: -

            DataConversion.ShowOutputControlWindow = ON; // set flag for disable button - Tan Feb 22th 2024

            if (select_excel_file == DEFAULT_FILE)
            {
                update_data_from_excel_file(DataConversion.Data_clear); // get and show data from default file
            }
            else
            {
                if (DataConversion.Data_import.Analog_out.Count != 0) // file import is not empty.
                {
                    update_data_from_excel_file(DataConversion.Data_import); // get and show data from import file
                }
                else
                {
                    update_data_from_excel_file(DataConversion.Data_start_app); // get and show data from start up file
                }
            }

            if (PWMDutyOutTemp[0] != -1) // != -1, it means control output window open not first time. After that, all value and visibility will be loaded from temp value.
            {
                // load valueand visibility from temporary value
                load_previous_value_component(); // show value component coressponding at previos time close
                load_previous_visibility_component(); // hide show component coressponding show value component coressponding at previos time close, also checkbox
            }
        }


        private UInt16 DigitalInputOffset = 0;
        private UInt16 AnalogInputOffset = 16;
        private UInt16 PWMInputOffset = 32;
        private UInt16 ACInputOffset = 40;

        private UInt16 DigitalOutputOffset = 48;
        private UInt16 AnalogOutputOffset = 64;
        private UInt16 PWMOutputOffset = 80;
        private UInt16 ACOutputOffset = 88;




        private void CloseProgramUnloaded(object sender, RoutedEventArgs e)
        {
            DataConversion.ShowOutputControlWindow = OFF; // set flag for disable button - Tan Feb 22th 2024

            // storage all value and show/hide status in array, and show again when it will open next time
            save_current_data_value();
            save_current_data_visibility();

            //thinh comment: update output control data to signal monitor
            _OutputMonitor.UpdateOutputPHYValue();

            _OutputMonitor.UpdateOutputRawValue();

        }

        //this function to check the visibility status of components


        // remove the corresponding component from the context menus corresponding to the components




        // click Clear button, all data will be reset to default config file data
        private void Clear_Btn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to use default setting?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes) // Implement when user click Yes
            {
                select_excel_file = DEFAULT_FILE; // set flag for opening in the next time
                update_data_from_excel_file(DataConversion.Data_clear); // get and show data from start up file
                                                                        //thinhcode here
                                                                        //capture event

                ControlOuputCommon.CANSendAllData();

            }
            else // Implement when user click No
            {
                // do nothing
            }
        }

        // click reset button, all data will be reset to config file data
        private void Reset_Btn_Click(object sender, RoutedEventArgs e)
        {
            // author: -
            // description: this function is update all step button value follow excel file
            // return:-
            // argument: 
            // note: -
            select_excel_file = START_APP; // set flag for opening in the next time

            if (DataConversion.Data_import.Analog_out.Count != 0) // file import is not empty.
            {
                update_data_from_excel_file(DataConversion.Data_import); // get and show data from import file
            }
            else
            {
                update_data_from_excel_file(DataConversion.Data_start_app); // get and show data from start up file
            }
        }

        private void Apply_Button_Click(object sender, RoutedEventArgs e)
        {
            // author: -
            // description: Press Apply button will save value and visibility of all component
            // return:-
            // argument: 
            // note: -

            // Storage all values and show/hide status in the array, when it pops up again, open it
            save_current_data_value();
            save_current_data_visibility();
            _OutputMonitor.UpdateOutputPHYValue();
            _OutputMonitor.UpdateOutputRawValue();
        }

        // click Auto control button to open window to config Auto control
        private void ConfigAutoControl_Btn_Click(object sender, RoutedEventArgs e)
        {
            AutoControlWindow objAutoControlWindow = new AutoControlWindow();
            objAutoControlWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            objAutoControlWindow.ShowDialog();
        }

        // right click at each canvas of conponent
        private void mouseRightClickAtBorder(Int16 i, object sender)
        {
            ContextMenu cm = this.FindResource("ComponentContextMenu") as ContextMenu;
            cm.PlacementTarget = sender as Button;
            cm.IsOpen = true;
            _selectedBorderRemove = ComponentNumber[i]; // i position of  border trong dictionary
        }
        private void Digi0_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(0, sender); // 0 position of  Digi 0 trong Dictionary
        }
        private void Digi1_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(1, sender);
        }
        private void Digi2_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(2, sender);
        }
        private void Digi3_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(3, sender);
        }
        private void Digi4_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(4, sender);
        }
        private void Digi5_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(5, sender);
        }
        private void Digi6_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(6, sender);
        }
        private void Digi7_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(7, sender);
        }
        private void Digi8_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(8, sender); // show contextMenu and detect border to delete
        }
        private void Digi9_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(9, sender); // show contextMenu and detect border to delete
        }
        private void Digi10_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(10, sender); // show contextMenu and detect border to delete
        }
        private void Digi11_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(11, sender); // show contextMenu and detect border to delete
        }
        private void Digi12_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(12, sender); // show contextMenu and detect border to delete
        }
        private void Digi13_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(13, sender); // show contextMenu and detect border to delete
        }
        private void Digi14_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(14, sender); // show contextMenu and detect border to delete
        }
        private void Digi15_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(15, sender); // show contextMenu and detect border to delete
        }
        private void Ana0_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(16, sender); // show contextMenu and detect border to delete
        }
        private void Ana1_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(17, sender); // show contextMenu and detect border to delete
        }
        private void Ana2_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(18, sender); // show contextMenu and detect border to delete
        }
        private void Ana3_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(19, sender); // show contextMenu and detect border to delete
        }
        private void Ana4_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(20, sender); // show contextMenu and detect border to delete
        }
        private void Ana5_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(21, sender); // show contextMenu and detect border to delete
        }
        private void Ana6_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(22, sender); // show contextMenu and detect border to delete
        }
        private void Ana7_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(23, sender); // show contextMenu and detect border to delete
        }
        private void Ana8_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(24, sender); // show contextMenu and detect border to delete
        }
        private void Ana9_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(25, sender); // show contextMenu and detect border to delete
        }
        private void Ana10_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(26, sender); // show contextMenu and detect border to delete
        }
        private void Ana11_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(27, sender); // show contextMenu and detect border to delete
        }
        private void Ana12_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(28, sender); // show contextMenu and detect border to delete
        }
        private void Ana13_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(29, sender); // show contextMenu and detect border to delete
        }
        private void Ana14_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(30, sender); // show contextMenu and detect border to delete
        }
        private void Ana15_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(31, sender); // show contextMenu and detect border to delete
        }
        // mouse right click at PWM component
        private void PWM0_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(32, sender); // show contextMenu and detect border to delete
        }
        private void PWM1_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(33, sender); // show contextMenu and detect border to delete
        }
        private void PWM2_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(34, sender); // show contextMenu and detect border to delete
        }
        private void PWM3_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(35, sender); // show contextMenu and detect border to delete
        }
        // mouse right click at AC component
        private void AC0_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(36, sender); // show contextMenu and detect border to delete
        }
        private void AC1_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(37, sender); // show contextMenu and detect border to delete
        }
        private void AC2_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(38, sender); // show contextMenu and detect border to delete
        }
        private void AC3_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            mouseRightClickAtBorder(39, sender); // show contextMenu and detect border to delete
        }

        private void clickCheckBoxComponent(int channel)
        {
            // author: -
            // description: this function is update all step button value follow excel file
            // return:-
            // argument: 
            // note: -

            if (ComponentChekcBoxDict.TryGetValue(channel, out CheckBox checkbox))
            {
                if (checkbox.IsChecked == true) // check box
                {
                    if (ComponentBorderDict.TryGetValue(channel, out Border border))
                    {
                        border.Visibility = Visibility.Visible; // show border to list
                    }
                    else { } // do nothing
                }
                else // uncheck box
                {
                    if (ComponentBorderDict.TryGetValue(channel, out Border border))
                    {
                        border.Visibility = Visibility.Collapsed; // hide border to list
                    }
                    else { } // do nothing
                }
            }
            else { } // do nothing   
        }

        // control visible/ collapsed 
        private void Click_CheckBox_Digi0(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[0]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Digi1(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[1]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Digi2(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[2]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Digi3(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[3]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Digi4(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[4]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Digi5(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[5]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Digi6(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[6]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Digi7(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[7]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Digi8(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[8]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Digi9(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[9]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Digi10(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[10]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Digi11(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[11]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Digi12(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[12]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Digi13(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[13]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Digi14(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[14]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Digi15(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[15]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Ana0(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[16]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Ana1(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[17]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Ana2(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[18]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Ana3(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[19]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Ana4(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[20]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Ana5(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[21]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Ana6(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[22]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Ana7(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[23]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Ana8(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[24]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Ana9(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[25]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Ana10(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[26]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Ana11(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[27]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Ana12(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[28]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Ana13(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[29]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Ana14(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[30]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_Ana15(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[31]); // show/hide component coressponding from check box
        }
        // control show/hide PWM border of PWM
        private void Click_CheckBox_PWM0(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[32]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_PWM1(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[33]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_PWM2(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[34]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_PWM3(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[35]); // show/hide component coressponding from check box
        }
        // control show/hide PWM border of AC
        private void Click_CheckBox_AC0(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[36]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_AC1(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[37]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_AC2(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[38]); // show/hide component coressponding from check box
        }
        private void Click_CheckBox_AC3(object sender, RoutedEventArgs e)
        {
            clickCheckBoxComponent(ComponentNumber[39]); // show/hide component coressponding from check box
        }

    }
}
