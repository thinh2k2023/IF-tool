using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.Windows;
using WPFiftool.Models;
using static WPFiftool.Models.Common_string;
using DocumentFormat.OpenXml.Spreadsheet;
using WPFiftool.ViewModels.SignalMonitor;
using ControlzEx.Standard;

namespace WPFiftool.ViewModels.ConfigfileViewModel
{
    public partial class Save_file
    {
        //public static Binding[,] dataBinding = new Binding[8, 16];  //  index = 0 -> 7 : Digital in,analog in , pwm in, AC in , di out , analog out ,pwm,AC output 
        private static string Path_file_save;
        //private static List<Common_string.Signal_Title> List_save = new List<Common_string.Signal_Title>();

        private static List<Common_string.Data_save> data_save = new List<Common_string.Data_save>();
        private static List<Common_string.Title_save> title_save = new List<Common_string.Title_save>();
        public static void Get_data_save()
        {
            data_save.Clear();
            foreach (Common_string.Signal_Title signal_save in InputMonitor.SignalMonitorDataSaveExcel)
            {
               
                Common_string.Data_save newData = new Common_string.Data_save();
               
                newData.Type = signal_save.Type;
                newData.Channel = signal_save.Channel;
                newData.IO = signal_save.IO;
                newData.SignalName = signal_save.SignalName;
                newData.Element = signal_save.Element;
                newData.Value = signal_save.Value;
                newData.Unit = signal_save.Unit;
                newData.MinLabel = signal_save.MinLabel;
                newData.MaxLabel = signal_save.MaxLabel;
                newData.Resolution = signal_save.Resolution;
                newData.Offset = signal_save.Offset;
                newData.VisibleMonitor = signal_save.VisibleMonitor;
                newData.OrderMonitor = signal_save.OrderMonitor;
                newData.VisibleOutput = signal_save.VisibleOutput;
                newData.OrderOutput = signal_save.OrderOutput;
                
                data_save.Add(newData);
            }
            for (int i = 0; i < Common_string.check_format.Length; i++)
            {
                Common_string.Title_save Title_save = new Common_string.Title_save();
                Title_save.Title = Common_string.check_format[i];
                title_save.Add(Title_save);
            }
        }
        public static void save_function()
        {
            Path_file_save = Properties.Settings.Default.ImportedFilePath;

            Get_data_save();
            // Tạo một workbook mới mỗi lần muốn lưu
            using (var wbook = new XLWorkbook(Path_file_save))
            {
                var ws = wbook.Worksheet("ConfigData");

                // Ghi giá trị của title_save lần lượt vào các ô trong hàng đầu tiên
                //for (int i = 0; i < title_save.Count; i++)
                //{
                //    ws.Cell(1, i + 1).Value = title_save[i].Title;
                //}
                ws.Cell(2, 1).InsertData(data_save);
                //ws.Cell(2, 1).InsertData(List_save);
                // Tự động điều chỉnh độ rộng của các cột để phù hợp với nội dung
                ws.Columns().AdjustToContents();
                // Cộng thêm 2 khoảng trắng vào độ rộng của mỗi cột
                for (int i = 1; i <= ws.Columns().Count(); i++)
                {
                    ws.Column(i).Width += 2; // Cộng thêm 2 khoảng trắng cho mỗi cột
                }
                wbook.SaveAs(Path_file_save);
                //wbook.SaveAs("Export/Export.xlsx");
                MessageBox.Show("Save completed", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                // Xóa danh sách để chuẩn bị cho lần lưu tiếp theo
                data_save.Clear();
                //title_save.Clear();
            }
        }
       

    }
}

