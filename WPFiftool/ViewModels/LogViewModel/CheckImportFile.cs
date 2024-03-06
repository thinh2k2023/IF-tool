using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFiftool.ViewModels.LogViewModel
{
    public class CheckImportFile
    {
        public static bool IsFileLocked(string LogfilePath)
        {
            bool lockStatus = false;
            try
            {
                using (FileStream fileStream = System.IO.File.Open(LogfilePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    // File/Stream manipulating code here
                    lockStatus = !fileStream.CanRead;
                }
            }
            catch
            {
                lockStatus = true;
            }
            return lockStatus;
        }
    }
}
