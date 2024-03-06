
using System.Windows;
using WPFiftool.ViewModels;
using WPFiftool.ViewModels.CANViewModel;
using WPFiftool.ViewModels.SignalMonitor;
using WPFiftool.ViewModels.StateMachineVM;
using WPFiftool.ViewModels.ControlOutputVM;
using WPFiftool.ViewModels.ConfigSignalVM;
using WPFiftool.Driver;
using WPFiftool.Models;
using System.Web.UI.WebControls;
using System;
using MaterialDesignThemes.Wpf;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using WPFiftool.ViewModels.ConfigfileViewModel;
using System.Text;
using WPFiftool.Models.InputSignal;

namespace WPFiftool.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Declearation for disable output control window
        const Int16 OFF = 0;
        const Int16 ON = 1;
        const Int16 NUMBER_MONITOR_VISIBLE  = 11;
        bool[] property_visible = new bool[NUMBER_MONITOR_VISIBLE] { Properties.Settings.Default.signal_name_visible,
                                               Properties.Settings.Default.type_visible ,
                                               Properties.Settings.Default.channel_visible,
                                               Properties.Settings.Default.IO_visible,
                                               Properties.Settings.Default.Raw_value_visible,
                                               Properties.Settings.Default.value_visible,
                                               Properties.Settings.Default.unit_visible,
                                               Properties.Settings.Default.min_visible,
                                               Properties.Settings.Default.max_visible,
                                               Properties.Settings.Default.offset_visible,
                                               Properties.Settings.Default.resolution_visible
                                                                                                };
       
        CANRawTXViewModel _CANRawTXViewModel = new CANRawTXViewModel();
        ControlOuputCommon _ControlOuputCommon = new ControlOuputCommon();
        private Button controlOutput_button;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            SigmntDG.ItemsSource = InputMonitor.SignalMonitorDataView;      //biding data to datagrid


            StateMachine.StateMachineInit();
            CANRawRXViewModel.RegisterCANRXEvent();
            CommError.CommErrorInit();

            byte IndexPropety = 0;

            foreach (var PropetyVisible in PropetyVisibleVM.PropetiesVisible)
            {
                PropetyVisibleVM.PropetiesVisible[0].IsPropetyVisible = Properties.Settings.Default.signal_name_visible;
                PropetyVisibleVM.PropetiesVisible[1].IsPropetyVisible = Properties.Settings.Default.type_visible;
                PropetyVisibleVM.PropetiesVisible[2].IsPropetyVisible = Properties.Settings.Default.channel_visible;
                PropetyVisibleVM.PropetiesVisible[3].IsPropetyVisible = Properties.Settings.Default.IO_visible;
                PropetyVisibleVM.PropetiesVisible[4].IsPropetyVisible = Properties.Settings.Default.Raw_value_visible;
                PropetyVisibleVM.PropetiesVisible[5].IsPropetyVisible = Properties.Settings.Default.value_visible;
                PropetyVisibleVM.PropetiesVisible[6].IsPropetyVisible = Properties.Settings.Default.unit_visible;
                PropetyVisibleVM.PropetiesVisible[7].IsPropetyVisible = Properties.Settings.Default.min_visible;
                PropetyVisibleVM.PropetiesVisible[8].IsPropetyVisible = Properties.Settings.Default.max_visible;
                PropetyVisibleVM.PropetiesVisible[9].IsPropetyVisible = Properties.Settings.Default.offset_visible;
                PropetyVisibleVM.PropetiesVisible[10].IsPropetyVisible = Properties.Settings.Default.resolution_visible;


                if (PropetyVisible.IsPropetyVisible == false)
                {

                    this.SigmntDG.Columns[IndexPropety].Visibility = Visibility.Hidden;
                    //this.SigmntDG.Columns[0].Visibility = Properties.Settings.Default.Signal_name_visible;
                }
                else
                {
                    //do nothing
                    this.SigmntDG.Columns[IndexPropety].Visibility = Visibility.Visible;
                }
                IndexPropety++;
            }
        }


        //for visible propety
        private void OnCbObjectCheckBoxChecked(object sender, RoutedEventArgs e)
        {        
                if (PropetyVisibleVM.PropetiesVisible[0].IsPropetyVisible == false)
                {
                    
                    this.SigmntDG.Columns[0].Visibility = Visibility.Hidden;
                    Properties.Settings.Default.signal_name_visible = false;                 
                }
                else
                {              
                    this.SigmntDG.Columns[0].Visibility = Visibility.Visible;
                    Properties.Settings.Default.signal_name_visible = true;
                }

                if (PropetyVisibleVM.PropetiesVisible[1].IsPropetyVisible == false)
                {

                    this.SigmntDG.Columns[1].Visibility = Visibility.Hidden;
                    Properties.Settings.Default.type_visible = false;
                }
                else
                {
                    this.SigmntDG.Columns[1].Visibility = Visibility.Visible;
                    Properties.Settings.Default.type_visible = true;
                }

                if (PropetyVisibleVM.PropetiesVisible[2].IsPropetyVisible == false)
                {

                    this.SigmntDG.Columns[2].Visibility = Visibility.Hidden;
                    Properties.Settings.Default.channel_visible = false;
                }
                else
                {
                    this.SigmntDG.Columns[2].Visibility = Visibility.Visible;
                    Properties.Settings.Default.channel_visible = true;
                }

                if (PropetyVisibleVM.PropetiesVisible[3].IsPropetyVisible == false)
                {

                    this.SigmntDG.Columns[3].Visibility = Visibility.Hidden;
                    Properties.Settings.Default.IO_visible = false;
                }
                else
                {
                    this.SigmntDG.Columns[3].Visibility = Visibility.Visible;
                    Properties.Settings.Default.IO_visible = true;
                }

                if (PropetyVisibleVM.PropetiesVisible[4].IsPropetyVisible == false)
                {

                    this.SigmntDG.Columns[4].Visibility = Visibility.Hidden;
                    Properties.Settings.Default.Raw_value_visible = false;
                }
                else
                {
                    this.SigmntDG.Columns[4].Visibility = Visibility.Visible;
                    Properties.Settings.Default.Raw_value_visible = true;
                }

                if (PropetyVisibleVM.PropetiesVisible[5].IsPropetyVisible == false)
                {

                    this.SigmntDG.Columns[5].Visibility = Visibility.Hidden;
                    Properties.Settings.Default.value_visible = false;
                }
                else
                {
                    this.SigmntDG.Columns[5].Visibility = Visibility.Visible;
                    Properties.Settings.Default.value_visible = true;
                }


                if (PropetyVisibleVM.PropetiesVisible[6].IsPropetyVisible == false)
                {

                    this.SigmntDG.Columns[6].Visibility = Visibility.Hidden;
                    Properties.Settings.Default.unit_visible = false;
                }
                else
                {
                    this.SigmntDG.Columns[6].Visibility = Visibility.Visible;
                    Properties.Settings.Default.unit_visible = true;
                }



                if (PropetyVisibleVM.PropetiesVisible[7].IsPropetyVisible == false)
                {

                    this.SigmntDG.Columns[7].Visibility = Visibility.Hidden;
                    Properties.Settings.Default.min_visible = false;
                }
                else
                {
                    this.SigmntDG.Columns[7].Visibility = Visibility.Visible;
                    Properties.Settings.Default.min_visible = true;
                }


                if (PropetyVisibleVM.PropetiesVisible[8].IsPropetyVisible == false)
                {

                    this.SigmntDG.Columns[8].Visibility = Visibility.Hidden;
                    Properties.Settings.Default.max_visible = false;
                }
                else
                {
                    this.SigmntDG.Columns[8].Visibility = Visibility.Visible;
                    Properties.Settings.Default.max_visible = true;
                }


                if (PropetyVisibleVM.PropetiesVisible[9].IsPropetyVisible == false)
                {

                    this.SigmntDG.Columns[9].Visibility = Visibility.Hidden;
                    Properties.Settings.Default.offset_visible = false;
                }
                else
                {
                    this.SigmntDG.Columns[9].Visibility = Visibility.Visible;
                    Properties.Settings.Default.offset_visible = true;
                }

                if (PropetyVisibleVM.PropetiesVisible[10].IsPropetyVisible == false)
                {

                    this.SigmntDG.Columns[10].Visibility = Visibility.Hidden;
                    Properties.Settings.Default.resolution_visible = false;
                }
                else
                {
                    this.SigmntDG.Columns[10].Visibility = Visibility.Visible;
                    Properties.Settings.Default.resolution_visible = true;
                }

               
            Properties.Settings.Default.Save();
        }

        private void OnCbObjectsSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if(CBSelectPropety.SelectedIndex != -1)
            {
                if (PropetyVisibleVM.PropetiesVisible[CBSelectPropety.SelectedIndex].IsPropetyVisible == true)
                {
                    PropetyVisibleVM.PropetiesVisible[CBSelectPropety.SelectedIndex].IsPropetyVisible = false;
                    this.SigmntDG.Columns[CBSelectPropety.SelectedIndex].Visibility = Visibility.Hidden;

                }
                else
                {
                    PropetyVisibleVM.PropetiesVisible[CBSelectPropety.SelectedIndex].IsPropetyVisible = true;
                    this.SigmntDG.Columns[CBSelectPropety.SelectedIndex].Visibility = Visibility.Visible;
                }
            }    



            //Console.WriteLine(CBSelectPropety.SelectedIndex);
            CBSelectPropety.SelectedItem = null;
        }


        private void ConfigAutoControl_button_Click(object sender, RoutedEventArgs e)
        {
            if (DataConversion.ShowAutoControlWindow == OFF)
            {
                AutoControlWindow objAutoControlWindow = new AutoControlWindow();
                objAutoControlWindow.Show();
                ControlOuputCommon.CANSendAllData();
            }
        }

        private void ControlOutput_button_Click(object sender, RoutedEventArgs e)
        {
            if (DataConversion.ShowOutputControlWindow == OFF)
            {
                ControlOutputWindow objControlOutput = new ControlOutputWindow();
                objControlOutput.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                objControlOutput.Show();
                test = false;
            }
        }

        private void ConfigSignal_button_Click(object sender, RoutedEventArgs e)
        {
            if (DataConversion.ShowConfigSignalWindow == OFF)
            {
                ConfigSignalHandle.AddData();
                ConfigSignalWindow objConfigSignalWindow = new ConfigSignalWindow();
                objConfigSignalWindow.Show();
            }
        }
        private void About_Item_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow objAboutWindow = new AboutWindow();
            objAboutWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            objAboutWindow.ShowDialog();
        }
        private void UserManual_Item_Click(object sender, RoutedEventArgs e)
        {
            UserManualWindow objUserManualWindow = new UserManualWindow();
            objUserManualWindow.ShowDialog();
        }

        private void closeMain(object sender, RoutedEventArgs e)
        {
            //e.Cancel = true;
        }
        bool test = true;
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.Save();
            MessageBoxResult result_mb =
                    MessageBox.Show("Application is conecting with device. \nThis action will disconnect and save current config data. \n Do you want to save file?", "Warning", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning, MessageBoxResult.No);
            if (result_mb == MessageBoxResult.Yes) // user click Yes
            {
                Save_file.save_as();
                USBCanDriver.CANClose();
                Application.Current.Shutdown(99);
                e.Cancel = false;
            }
            else if (result_mb == MessageBoxResult.No)  // user click No
            {
                USBCanDriver.CANClose();
                Application.Current.Shutdown(99);
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

    }
}
