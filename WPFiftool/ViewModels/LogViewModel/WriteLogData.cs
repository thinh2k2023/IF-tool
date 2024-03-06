using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WPFiftool.Driver;

namespace WPFiftool.ViewModels.LogViewModel
{
    public class WriteLogData : Window
    {
        private static StreamWriter writer;
        public static void WriteStartTimeToCsv(DateTime startTime, string filePath)
        {
            writer = new StreamWriter(filePath, true);
            writer.WriteLine($"Start, {(string)startTime.ToString("dd/MM/yyyy HH:mm:ss")}");
            writer.WriteLine("Timestamp(s),ID,TX/RX,DLC,Data");
        }

        public static void Write_CAN_Data(string ConvertlogTime, string CANID, string CAN_Type, string CANData)
        {

            writer.WriteLine($"{ConvertlogTime},{CANID},{CAN_Type},{"8"},{CANData}");
            writer.Flush();
        }

        public static void WriteStopLogFile(DateTime stopTime, string Path)
        {

            writer.WriteLine($"Stop, {stopTime.ToString("dd/MM/yyyy HH:mm:ss")}");
            writer.Close();

            string[] lines = System.IO.File.ReadAllLines(Path);

            // Check the log file has more than 2 lines?
            if (lines.Length >= 2)
            {
                // Save data from the last line into a temporary variable
                string lastLine = lines[lines.Length - 1];

                // Duyệt qua các dòng từ dòng cuối thứ hai đến dòng đầu tiên
                for (int i = lines.Length - 2; i >= 0; i--)
                {
                    // Move data from the previous line to the next line
                    lines[i + 1] = lines[i];
                }

                // Assign the data of the last line to the second line
                lines[1] = lastLine;

                // Write all the contents of the array of lines to the file
                System.IO.File.WriteAllLines(Path, lines);
            }
        }

        public static void SaveAndClose()
        {
            writer.Dispose();
        }

        public static string DecimalToHex(int decimalNumber)
        {
            // Kiểm tra nếu số đầu vào là 0
            if (decimalNumber == 0)
                return "00";

            // Tạo một mảng để lưu trữ các chữ số hệ thập lục phân
            char[] hexChars = "0123456789ABCDEF".ToCharArray();

            // Chuỗi để lưu trữ kết quả
            string hexResult = "";

            // Lặp cho đến khi số đầu vào là 0
            while (decimalNumber > 0)
            {
                // Lấy phần dư của phép chia cho 16
                int remainder = decimalNumber % 16;

                // Chuyển đổi phần dư thành chữ số hệ thập lục phân và thêm vào đầu chuỗi kết quả
                hexResult = hexChars[remainder] + hexResult;

                // Chia số cho 16 để tiếp tục lặp
                decimalNumber /= 16;
            }

            // Kiểm tra và thêm số 0 trước nếu kích thước của chuỗi kết quả là 1
            if (hexResult.Length == 1)
            {
                hexResult = "0" + hexResult;
            }

            return hexResult;
        }

    }
}