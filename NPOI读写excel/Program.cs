using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI;
using System.Data;
using System.IO;

namespace NPOI读写excel
{
    class Program
    {
        static void Main(string[] args)
        {
            string testExcelFilePath= System.IO.Directory.GetCurrentDirectory()+"\\test2.xls";
            //string testExcelFilePath = System.AppDomain.CurrentDomain.BaseDirectory + "test.xlsx";

            //将excel导出到datatable
            DataTable table = ExcelUtility.ExcelToDataTable(testExcelFilePath, "Sheet2", true);
            ShowTable(table);//显示table

            //将datatable导入到excel
            string path= System.IO.Directory.GetCurrentDirectory() + "\\test2.xls";
            ExcelUtility.DataTableToExcel(table, path,"Sheet3");

            //获取excel的sheet名称列表
            List<string> list = NPOIExcelHelper.GetSheetName(path);
            list.ForEach((sheetName) => Console.WriteLine(sheetName));
            Console.ReadKey();
        }

        private static void ShowTable(DataTable table)
        {
            if(table==null)
            {
                return;
            }
            foreach (DataColumn col in table.Columns)
            {
                Console.Write("{0,-14}", col.ColumnName);
            }
            Console.WriteLine();

            foreach (DataRow row in table.Rows)
            {
                foreach (DataColumn col in table.Columns)
                {
                    if (col.DataType.Equals(typeof(DateTime)))
                        Console.Write("{0,-14:d}", row[col]);
                    else if (col.DataType.Equals(typeof(Decimal)))
                        Console.Write("{0,-14:C}", row[col]);
                    else
                        Console.Write("{0,-14}", row[col]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }
}
