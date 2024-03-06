using System;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace WPFiftool.ViewModels.ConfigfileViewModel
{
    static class Function_Excel
    {
        public static String get_value_cell(IXLWorksheet sheet, uint Row_ub, uint Col_ub)/* get value cell*/
        {
            string Value_cell_s;
            if (Row_ub == 0 || Col_ub == 0)
            {
                Value_cell_s = "";
            }
            else if (sheet.Cell((int)Row_ub, (int)Col_ub).HasFormula == true)
            {
                Value_cell_s = sheet.Cell((int)Row_ub, (int)Col_ub).ToString();
            }
            else if (sheet.Cell((int)Row_ub, (int)Col_ub).Value.ToString().Length > 0)
            {
                Value_cell_s = sheet.Cell((int)Row_ub, (int)Col_ub).Value.ToString();
            }
            else
            {
                Value_cell_s = "";
            }

            return Value_cell_s;
        }


        public static uint Get_index_column(IXLWorksheet sheet, uint Row_ub, String Key_s)  /* get index column*/
        {
            uint Col_last_ub = (uint)sheet.LastColumnUsed().ColumnNumber(); /*get the last column*/
            uint ret_ub = 0;

            if (Key_s.Trim().Length == 0) /* length of key is " " */
            {
                ret_ub = 0;
            }
            else
            {
                for (uint col_ub = 1; col_ub <= Col_last_ub; col_ub++)
                {

                    if (get_value_cell(sheet, Row_ub, col_ub).Equals(Key_s)) /* value == key_s*/
                    {
                        ret_ub = col_ub;
                        break;
                    }


                }
            }
            return ret_ub;
        }


        public static DataValidation GetDataValidation(IXLWorksheet cell)
        {
            return (DataValidation)cell.DataValidations;
        }

        internal static object GetDataValidation(IXLCell cell)
        {
            throw new NotImplementedException();
        }
    }
}
