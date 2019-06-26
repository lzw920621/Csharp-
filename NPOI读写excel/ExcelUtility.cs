using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;

namespace NPOI读写excel
{
    class ExcelUtility
    {
        /// <summary>  
        /// 将excel导入到datatable  
        /// </summary>  
        /// <param name="filePath">excel路径</param>  
        /// <param name="isColumnName">第一行是否是列名</param>
        /// <param name="sheetName">sheet名称</param>
        /// <returns>返回datatable</returns>  
        public static DataTable ExcelToDataTable(string filePath,string sheetName, bool isColumnName)
        {
            //判断excel文件是否存在
            if(!File.Exists(filePath))
            {
                throw new Exception("指定的excel文件不存在");
            }
            //判断文件类型是否正确
            string extension = Path.GetExtension(filePath);
            if (extension != ".xls" && extension != ".xlsx")
            {
                throw new Exception("文件类型错误,不是excel文件");
            }

            DataTable dataTable = null;
            FileStream fs = null;
            DataColumn column = null;
            DataRow dataRow = null;
            IWorkbook workbook = null;
            ISheet sheet = null;
            IRow row = null;
            ICell cell = null;
            int startRow = 0;

            using (fs = File.OpenRead(filePath))//读取excel文件
            {
                if (extension.Equals(".xlsx"))// 2007版本  
                {
                    workbook = new XSSFWorkbook(fs);
                }
                else if (extension.Equals(".xls")) // 2003版本  
                {
                    workbook = new HSSFWorkbook(fs);
                }
            }

            if (workbook != null)
            {
                sheet = workbook.GetSheet(sheetName);//根据给出的sheetName获取相应的sheet                 
                if (sheet != null)
                {
                    int rowCount = sheet.LastRowNum;//总行数  
                    if (rowCount > 0)
                    {
                        dataTable = new DataTable();

                        IRow firstRow = sheet.GetRow(0);//第一行
                        int cellCount = firstRow.LastCellNum;//列数  

                        //构建datatable的列  
                        if (isColumnName)
                        {
                            startRow = 1;//如果第一行是列名，则从第二行开始读取  
                            for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                            {
                                cell = firstRow.GetCell(i);
                                if (cell != null)
                                {
                                    if (cell.StringCellValue != null)
                                    {
                                        column = new DataColumn(cell.StringCellValue);
                                        dataTable.Columns.Add(column);
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                            {
                                column = new DataColumn("column" + (i + 1));
                                dataTable.Columns.Add(column);
                            }
                        }


                        //填充行元素  
                        for (int i = startRow; i <= rowCount; ++i)
                        {
                            row = sheet.GetRow(i);
                            if (row == null) continue;

                            dataRow = dataTable.NewRow();
                            for (int j = row.FirstCellNum; j < cellCount; ++j)
                            {
                                cell = row.GetCell(j);
                                if (cell == null)
                                {
                                    dataRow[j] = "";
                                }
                                else
                                {
                                    //CellType(Unknown = -1,Numeric = 0,String = 1,Formula = 2,Blank = 3,Boolean = 4,Error = 5,)  
                                    switch (cell.CellType)
                                    {
                                        case CellType.Blank:
                                            dataRow[j] = "";
                                            break;
                                        case CellType.Numeric:
                                            short format = cell.CellStyle.DataFormat;
                                            //对时间格式（2015.12.5、2015/12/5、2015-12-5等）的处理  
                                            if (format == 14 || format == 31 || format == 57 || format == 58)
                                                dataRow[j] = cell.DateCellValue;
                                            else
                                                dataRow[j] = cell.NumericCellValue;
                                            break;
                                        case CellType.String:
                                            dataRow[j] = cell.StringCellValue;
                                            break;
                                        case CellType.Boolean:
                                            dataRow[j] = cell.BooleanCellValue;
                                            break;
                                        default:
                                            dataRow[j] = cell.StringCellValue;
                                            break;
                                    }
                                }
                            }
                            dataTable.Rows.Add(dataRow);
                        }
                    }
                }

                workbook.Close();
            }

            return dataTable;
        }


        /// <summary>
        /// 将datatable导入到excel
        /// </summary>
        /// <param name="dt">要导入的datable</param>
        /// <param name="filePath">excel文件路径</param>
        /// <param name="sheetName">sheet名称</param>
        /// <returns>操作是否成功</returns>
        public static bool DataTableToExcel(DataTable dt,string filePath,string sheetName)
        {
            //先判断文件类型是否正确
            string extension = Path.GetExtension(filePath);
            if (extension != ".xls" && extension != ".xlsx")
            {
                throw new Exception("文件类型错误,不是excel文件");
            }
            if (dt == null || dt.Rows.Count == 0)//datatable为空 或 行数为0 
            {
                return false;
            }

            bool result = false;
            IWorkbook workbook = null;
            FileStream fs = null;
            IRow row = null;
            ISheet sheet = null;
            ICell cell = null;

            if(File.Exists(filePath))//若excel文件已存在
            {
                using (fs = File.OpenRead(filePath))//读取excel文件
                {
                    if (extension.Equals(".xlsx"))// 2007版本  
                    {
                        workbook = new XSSFWorkbook(fs);
                    }
                    else if (extension.Equals(".xls")) // 2003版本  
                    {
                        workbook = new HSSFWorkbook(fs);
                    }
                }

                sheet = workbook.GetSheet(sheetName);//获取指定名称的sheet
                if (sheet == null)//若不存在该sheet 则创建一个sheet
                {
                    sheet = workbook.CreateSheet(sheetName);//创建一个指定名称的sheet的表
                }
                int rowCount = dt.Rows.Count;//行数  
                int columnCount = dt.Columns.Count;//列数  

                //设置列头  
                row = sheet.CreateRow(0);//excel第一行设为列头  
                for (int c = 0; c < columnCount; c++)
                {
                    cell = row.CreateCell(c);
                    cell.SetCellValue(dt.Columns[c].ColumnName);
                }

                //设置每行每列的单元格,  
                for (int i = 0; i < rowCount; i++)
                {
                    row = sheet.CreateRow(i + 1);
                    for (int j = 0; j < columnCount; j++)
                    {
                        cell = row.CreateCell(j);//excel第二行开始写入数据  
                        cell.SetCellValue(dt.Rows[i][j].ToString());
                    }
                }

                using (fs = File.OpenWrite(filePath))//将修改后的workbook再写入excel文件
                {
                    workbook.Write(fs);//向打开的这个xls文件中写入数据  
                    result = true;
                }
                workbook.Close();
            }
            else//excel文件不存在
            {
                if (extension.Equals(".xlsx"))// 2007版本  
                {
                    workbook = new XSSFWorkbook();
                }
                else if (extension.Equals(".xls")) // 2003版本  
                {
                    workbook = new HSSFWorkbook();
                }

                sheet = workbook.CreateSheet(sheetName);//创建一个指定名称的sheet的表

                int rowCount = dt.Rows.Count;//行数  
                int columnCount = dt.Columns.Count;//列数  

                //设置列头  
                row = sheet.CreateRow(0);//excel第一行设为列头  
                for (int c = 0; c < columnCount; c++)
                {
                    cell = row.CreateCell(c);
                    cell.SetCellValue(dt.Columns[c].ColumnName);
                }

                //设置每行每列的单元格,  
                for (int i = 0; i < rowCount; i++)
                {
                    row = sheet.CreateRow(i + 1);
                    for (int j = 0; j < columnCount; j++)
                    {
                        cell = row.CreateCell(j);//excel第二行开始写入数据  
                        cell.SetCellValue(dt.Rows[i][j].ToString());
                    }
                }

                using (fs = File.OpenWrite(filePath))//将修改后的workbook再写入excel文件
                {
                    workbook.Write(fs);
                    result = true;
                }
                workbook.Close();
            }
            return result;
        }

    }
}
