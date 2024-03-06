using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFiftool.Models;
using WPFiftool.ViewModels.ConfigfileViewModel;

namespace WPFiftool.ViewModels.ConfigfileViewModel
{
    public partial class Read_file
    {
        public static void Reset_config()
        {
            DataConversion.data_current_signal_monitor = DataConversion.data_signal_monitor_temp;
        }
    }
}
