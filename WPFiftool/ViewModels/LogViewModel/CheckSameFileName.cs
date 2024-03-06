using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFiftool.ViewModels.LogViewModel
{
    public class CheckSameFileName
    {
        public static string CheckFileName(string savedPath, string baseFileName, string fileType)
        {
            string fullFileName = System.IO.Path.Combine(savedPath, baseFileName + fileType);

            if (!System.IO.File.Exists(fullFileName))
            {
                return fullFileName; // Tên file không trùng, trả về ngay lập tức
            }

            // Nếu tên file trùng, thêm số thứ tự vào tên file
            int counter = 1;
            string newFileName = baseFileName + $"({counter})" + fileType;

            while (System.IO.File.Exists(System.IO.Path.Combine(savedPath, newFileName)))
            {
                counter++;
                newFileName = baseFileName + $"({counter})" + fileType;
            }

            return System.IO.Path.Combine(savedPath, newFileName);
        }
    }
}
