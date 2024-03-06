
using Winform = System.Windows.Forms;

namespace WPFiftool.ViewModels.LogViewModel
{
    public class GetPathLogfile
    {
        public static string SelectFolder()
        {
            var dialog = new Winform.FolderBrowserDialog();
            Winform.DialogResult result = dialog.ShowDialog();

            if (result == Winform.DialogResult.OK)
            {
                return dialog.SelectedPath;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
