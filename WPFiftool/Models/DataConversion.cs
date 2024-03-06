using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xaml;
using WPFiftool.Models;
using WPFiftool.ViewModels.ConfigfileViewModel;
using WPFiftool.Views;
using static WPFiftool.Models.Common_string;
using WPFiftool.ViewModels.SignalMonitor;

namespace WPFiftool.Models
{
    public partial class DataConversion
    {

        public static Int16 OFF = 0;
        public static Int16 ON = 1;

        public static Int16 ShowConfigSignalWindow = OFF;
        public static Int16 ShowOutputControlWindow = OFF;
        public static Int16 ShowAutoControlWindow = OFF;

        // khai báo kiểu constant
        public static int VISIBILYTY_VISIBLE = 0;
        public static int VISIBILYTY_COLLAPSED = 2;

        // Khai báo state cho phím bấm
        public Int16 BTN_Unclick = 0;
        public Int16 BTN_Click = 1;

        const Int16 DIG_ARRAY_LEN = 16;
        const Int16 ANA_ARRAY_LEN = 16;
        const Int16 PWM_ARRAY_LEN = 4;
        const Int16 AC_ARRAY_LEN = 4;

        const Int16 TOTAL_AD_STEP = 4095; // khai báo giá trị để tính resolution từ MIN-MAX



        // khai báo public limit value of duty, frequency
        public static double PWM_DUTY_MIN = 0.0F;
        public static double PWM_DUTY_MAX = 100.0F;
        public static double PWM_FREQ_MIN = 0;
        public static double PWM_FREQ_MAX = 200E3;
        public static double AC_FREQ_MIN = 0.0F;
        public static double AC_FREQ_MAX = 100.0F;
        public static Int16 AC_PS_MIN = -360;
        public static Int16 AC_PS_MAX = 360;
        public static double[] _ana_min = new double[ANA_ARRAY_LEN] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public static double[] _ana_max = new double[ANA_ARRAY_LEN] { 3.3, 3.3, 3.3, 3.3, 3.3, 3.3, 3.3, 3.3, 3.3, 3.3, 3.3, 3.3, 3.3, 3.3, 3.3, 3.3 };
        public static double _AC_RMS_min = 0.0F;
        public static double[] _AC_RMS_max = new double[PWM_ARRAY_LEN] { 551, 551, 551, 551 };

        public static Int16 START_ARRAY_ANA = 16;
        public static Int16 START_ARRAY_PWM = 32;
        public static Int16 START_ARRAY_AC = 36;

        // khai báo biến lưu trữ giá trị của các output control


        // declearate static variable for save at click "Apply" button
        public static int[] ComponentVisibilityTemp = new int[40];
        public static string[] ComponentNameTemp = new string[40];

        // step button for each element // this data will be set on resolution of config file
        public static double[] _ana_step = new double[ANA_ARRAY_LEN] { 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1, 0.1 };
        public static double[] _PWM_Duty_step = new double[PWM_ARRAY_LEN] { 0.1, 0.1, 0.1, 0.1 };
        public static double[] _PWM_Freq_step = new double[PWM_ARRAY_LEN] { 100, 100, 100, 100 };
        public static double[] _AC_RMS_step = new double[AC_ARRAY_LEN] { 1.0, 1.0, 1.0, 1.0 };
        public static double[] _AC_Freq_step = new double[AC_ARRAY_LEN] { 0.1, 0.1, 0.1, 0.1 };
        public static Int16[] _AC_PS_step = new Int16[AC_ARRAY_LEN ] { 1, 1, 1, 1};



        /// <summary>
        /// THINH GET RESOLUTION
        /// </summary>
        /// <param name="excelData"></param>
        /// 
        public static double[] AnalogOutputResolution = new double[ANA_ARRAY_LEN];
        public static double[] AnalogOutputOffset = new double[ANA_ARRAY_LEN];

        public static double[] ACOutputRMSResolution = new double[AC_ARRAY_LEN];
        public static double[] ACOutputFreqResolution = new double[AC_ARRAY_LEN];
        public static double[] ACOutputRMSOffset = new double[AC_ARRAY_LEN];



        /*variable of read excel*/
        public static Common_string.Each_signal_data_origin Data_start_app = new Each_signal_data_origin();
        public static Common_string.Each_signal_data_origin Data_import = new Each_signal_data_origin();
        public static Common_string.Each_signal_data_origin Data_clear = new Each_signal_data_origin();
        public static Common_string.Each_signal_data_origin data_current_signal_monitor = new Each_signal_data_origin();
        public static Common_string.Each_signal_data_origin data_signal_monitor_temp = new Each_signal_data_origin();
        public static Common_string.Each_signal_data_origin Data_default_screen = new Each_signal_data_origin();
        public static void update_step_button_value_rs_clr(Common_string.Each_signal_data_origin excelData)
        {
            // author: -
            // description: this function is update all step button value follow excel file
            // return:-
            // note: -

            for (int i = 0; i < ANA_ARRAY_LEN; i++)  // analog step value
            {
                // description: hàm này tính giá trị resolution default (from MIN-MAX) và resolution custom (from user) và lấy giá trị lớn hơn làm step
                double tempValue = 0;
                double tempResolution = 0;
                double tempOffset = 0;


                tempValue = Convert.ToDouble(excelData.Analog_out[i].Resolution);  //[V]
                tempOffset = Convert.ToDouble(excelData.Analog_out[i].Offset);
                tempResolution = Convert.ToDouble((Convert.ToDouble(excelData.Analog_out[i].MaxLabel) - Convert.ToDouble(excelData.Analog_out[i].MinLabel)) / TOTAL_AD_STEP);

                DataConversion.AnalogOutputOffset[i] = tempOffset;
                DataConversion.AnalogOutputResolution[i] = tempResolution;

                _ana_step[i] = Math.Max(tempValue, tempResolution);  //[V]
            }
            for (int i = 0; i < PWM_ARRAY_LEN; i++)  // PWM duty step value
            {
                double tempValue = 0, tempResolution = 0;
                tempValue = Convert.ToDouble(excelData.PWM_out_duty[i].Resolution);  //[V]
                tempResolution = Convert.ToDouble((Convert.ToDouble(excelData.PWM_out_duty[i].MaxLabel) - Convert.ToDouble(excelData.PWM_out_duty[i].MinLabel)) / TOTAL_AD_STEP);
                _PWM_Duty_step[i] = Math.Max(tempValue, tempResolution); //[%]
            }
            for (int i = 0; i < PWM_ARRAY_LEN; i++)  // PWM freq step value
            {
                double tempValue = 0, tempResolution = 0;
                tempValue = Convert.ToDouble(excelData.PWM_out_freq[i].Resolution);  //[V]
                tempResolution = Convert.ToDouble((Convert.ToDouble(excelData.PWM_out_freq[i].MaxLabel) - Convert.ToDouble(excelData.PWM_out_freq[i].MinLabel)) / TOTAL_AD_STEP);
                _PWM_Freq_step[i] = Math.Max(tempValue, tempResolution); //[Hz]
            }
            for (int i = 0; i < AC_ARRAY_LEN; i++)  // AC RMS step value
            {
                double tempValue = 0, tempResolution = 0;
                tempValue = Convert.ToDouble(excelData.AC_out_rms[i].Resolution);  //[V]

                double tempValueOffset = Convert.ToDouble(excelData.AC_out_rms[i].Offset);  //[V]

                tempResolution = Convert.ToDouble((Convert.ToDouble(excelData.AC_out_rms[i].MaxLabel) - Convert.ToDouble(excelData.AC_out_rms[i].MinLabel)) / TOTAL_AD_STEP);
                ACOutputRMSOffset[i] = tempValueOffset;

                ACOutputRMSResolution[i] = tempResolution;       //thinh get resolution
                
                _AC_RMS_step[i] = Math.Max(tempValue, tempResolution);  //[V]
            }
            for (int i = 0; i < AC_ARRAY_LEN; i++)  // AC Freq step value
            {
                double tempValue = 0, tempResolution = 0;
                tempValue = Convert.ToDouble(excelData.AC_out_freq[i].Resolution);  //[V]
                tempResolution = Convert.ToDouble((Convert.ToDouble(excelData.AC_out_freq[i].MaxLabel) - Convert.ToDouble(excelData.AC_out_freq[i].MinLabel)) / TOTAL_AD_STEP);

                ACOutputFreqResolution[i] = tempResolution;       //thinh get resolution

                _AC_Freq_step[i] = Math.Max(tempValue, tempResolution); //[Hz]
            }
            for (int i = 1; i < AC_ARRAY_LEN; i++)  // AC PS step value
            {
                Int16 tempValue = 0, tempResolution = 0;
                tempValue = Convert.ToInt16(excelData.AC_out_phase[i].Resolution);  //[V]
                tempResolution = Convert.ToInt16((Convert.ToInt16(excelData.AC_out_phase[i].MaxLabel) - Convert.ToInt16(excelData.AC_out_phase[i].MinLabel)) / TOTAL_AD_STEP);
                _AC_PS_step[i] = Math.Max(tempValue, tempResolution);//[°]
            }
        }

        public static void update_limit_value_rs_clr(Common_string.Each_signal_data_origin excelData)
        {
            // author: -
            // argument: data in excel
            // description: this function is update all limit value follow excel file
            // return:-
            // note: -

            for (int i = 0; i < ANA_ARRAY_LEN; i++)  // analog limit value
            {
                _ana_min[i] = Convert.ToDouble(excelData.Analog_out[i].MinLabel);  //[V]
                _ana_max[i] = Convert.ToDouble(excelData.Analog_out[i].MaxLabel);  //[V]
            }
            for (int i = 0; i < AC_ARRAY_LEN; i++)  // AC RMS limit value
            {
                _AC_RMS_max[i] = Convert.ToDouble(excelData.AC_out_rms[i].MaxLabel);  //[V]
            }
        }
    }
}
