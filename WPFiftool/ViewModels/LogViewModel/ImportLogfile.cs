using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

namespace WPFiftool.ViewModels.LogViewModel
{
    public class ImportLogfile
    {
        public static void Importlogfile(string savedPath)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files|*.csv";
            openFileDialog.InitialDirectory = savedPath;
            //openFileDialog.ShowDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                // Get path selected log file
                string Logfile = openFileDialog.FileName;

                // Check if the file is locked
                if (!CheckImportFile.IsFileLocked(Logfile))
                {
                    // Read file
                    MessageBox.Show("Can open file to read!", "Check log file accessibility", MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK);
                }
                else
                {
                    MessageBox.Show("Can not open file!\nPlease check file accessibility", "Check log file accessibility", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
                }
            }
        }
    }
}
