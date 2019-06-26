using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;

namespace NPOI读写excel
{
    class NPOIExcelHelper
    {
        /// <summary>
		/// open excel workbook(工作簿) 
		/// </summary>
		/// <param name="path">文件路径</param>
		/// <returns></returns>
		public static IWorkbook OpenWorkbook(string path)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Write);
            NPOI.SS.UserModel.IWorkbook workbook = WorkbookFactory.Create(fileStream);
            //var ext = System.IO.Path.GetExtension(path);
            //if (ext == ".xls")
            //	workbook = new NPOI.HSSF.UserModel.HSSFWorkbook(fileStream);
            //else if (ext == ".xlsx")
            //	workbook = new NPOI.XSSF.UserModel.XSSFWorkbook(fileStream);
            //else
            //{ }
            return workbook;
        }
        /// <summary>
        /// search first or default excel worksheet whose name is started with pattern(在工作簿中查找以pattern开头的工作表)
        /// </summary>
        /// <param name="workbook">要查找的工作簿</param>
        /// <param name="pattern">指定开头字符串</param>
        /// <returns></returns>
        public static ISheet FirstOrDefaultWorksheetNameStartWith(IWorkbook workbook, string pattern)
        {
            NPOI.SS.UserModel.ISheet worksheet = null;
            var length = workbook.NumberOfSheets;
            for (int i = 0; i < length; i++)
            {
                worksheet = workbook.GetSheetAt(i);
                if (worksheet.SheetName.StartsWith(pattern))
                    break;
                worksheet = null;
            }
            return worksheet;
        }
        /// <summary>
        /// 从指定的sheet中获取指定的cell
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public static ICell GetCell(ISheet sheet,int row,int column)
        {
            NPOI.SS.UserModel.ICell cell = null;
            if(sheet!=null)
            {
                cell = sheet.GetRow(row).GetCell(column);
            }            
            return cell;
        }
        
        
        /// <summary>
        /// read excel worksheet
        /// </summary>
        /// <param name="worksheet">要读取的工作表</param>
        /// <param name="rows">指定读取多少行</param>
        /// <param name="columns">指定读取多少列</param>
        /// <param name="startIndex">通常前3行是:注释,字段名和字段类型,如果注释全部不填,该行也应该读取</param>
        /// <returns></returns>
        public static List<string[]> ReadLines(ISheet worksheet, int rows = 0, int columns = 0, int startIndex = 3)
        {
            if (rows <= 0)
                rows = worksheet.LastRowNum + 1;
            else
                rows = Math.Min(rows, worksheet.LastRowNum + 1);
            if (rows == 0)
                return new List<string[]>();

            int rownum = 0;
            IRow row = worksheet.GetRow(rownum);
            if (columns <= 0)
                columns = row.LastCellNum + 1;
            else
                columns = Math.Min(columns, row.LastCellNum + 1);
            //List<>的每一个元素是一行数据,string[]的每一个元素是对应单元格的string值
            List<string[]> lines = new List<string[]>(rows);
            while (rownum < rows)
            {
                if (row != null)
                {
                    bool add = false;
                    var line = new string[columns];
                    for (int i = 0; i < columns; i++)
                    {
                        var cell = row.GetCell(i);
                        if (cell != null)
                        {
                            if (cell.CellType != CellType.Formula)
                                line[i] = cell.ToString().Trim();
                            else
                            {
                                if (cell.CachedFormulaResultType == CellType.Numeric)
                                    line[i] = cell.NumericCellValue.ToString();
                                else if (cell.CachedFormulaResultType == CellType.String)
                                    line[i] = cell.StringCellValue.Trim();
                                else if (cell.CachedFormulaResultType == CellType.Boolean)
                                    line[i] = cell.BooleanCellValue.ToString();
                            }
                        }
                        else
                        {
                            line[i] = null;
                        }
                        if (!string.IsNullOrEmpty(line[i]))
                            add = true;
                    }
                    if (add)
                        lines.Add(line);
                }
                else
                {
                    if (rownum < startIndex)
                    {
                        var line = new string[columns];
                        lines.Add(line);
                    }
                }
                rownum++;
                row = worksheet.GetRow(rownum);
            }
            return lines;
        }
        /// <summary>
        /// close excel workbook
        /// </summary>
        /// <param name="workbook"></param>
        public static void CloseWorkbook(IWorkbook workbook)
        {
            workbook.Close();
        }




        
        /// <summary>
        /// 获取cell的数据，并设置为对应的数据类型
        /// </summary>
        /// <param name="cell">cell对象</param>
        /// <returns></returns>
        public static object GetCellValue(ICell cell)
        {
            object value = null;
            try
            {
                if (cell.CellType != CellType.Blank)
                {
                    switch (cell.CellType)
                    {
                        case CellType.Numeric:
                            // Date comes here
                            if (DateUtil.IsCellDateFormatted(cell))
                            {
                                value = cell.DateCellValue;
                            }
                            else
                            {
                                // Numeric type
                                value = cell.NumericCellValue;
                            }
                            break;
                        case CellType.Boolean:
                            // Boolean type
                            value = cell.BooleanCellValue;
                            break;
                        case CellType.Formula:
                            value = cell.CellFormula;
                            break;
                        default:
                            // String type
                            value = cell.StringCellValue;
                            break;
                    }
                }
            }
            catch (Exception)
            {
                value = "";
            }

            return value;
        }


        
        /// <summary>
        /// 根据数据类型设置不同类型的cell
        /// </summary>
        /// <param name="cell">cell对象</param>
        /// <param name="obj">要写入cell的值</param>
        public static void SetCellValue(ICell cell, object obj)
        {
            if (obj.GetType() == typeof(int))
            {
                cell.SetCellType(CellType.Numeric);
                cell.SetCellValue((int)obj);
            }
            else if (obj.GetType() == typeof(double))
            {
                cell.SetCellType(CellType.Numeric);
                cell.SetCellValue((double)obj);
            }
            else if (obj.GetType() == typeof(IRichTextString))
            {
                cell.SetCellType(CellType.String);
                cell.SetCellValue((IRichTextString)obj);
            }
            else if (obj.GetType() == typeof(string))
            {
                cell.SetCellType(CellType.String);
                cell.SetCellValue(obj.ToString());
            }
            else if (obj.GetType() == typeof(DateTime))
            {
                cell.SetCellType(CellType.Numeric);
                cell.SetCellValue((DateTime)obj);
            }
            else if (obj.GetType() == typeof(bool))
            {
                cell.SetCellType(CellType.Boolean);
                cell.SetCellValue((bool)obj);
            }
            else
            {
                cell.SetCellType(CellType.String);
                cell.SetCellValue(obj.ToString());
            }
        }






        /// <summary>
        /// 获取excel文件的sheet名称列表
        /// </summary>
        /// <param name="filePath">excel文件路径</param>
        /// <returns></returns>
        public static List<string> GetSheetName(string filePath)
        {
            //先判断文件类型是否正确
            string extension = Path.GetExtension(filePath);
            if(extension!=".xls"&&extension!=".xlsx")
            {
                throw new Exception("文件类型错误,不是excel文件");
            }

            List<string> sheetNamelist = new List<string>();
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {                
                IWorkbook workbook;
                
                if (extension.Equals(".xls")) //针对2003版本  
                {
                    workbook = new HSSFWorkbook(file);
                }                    
                else //2010版本
                {
                    workbook = new XSSFWorkbook(file);
                }
       
                for (int i = 0; i < workbook.NumberOfSheets; i++)
                {
                    sheetNamelist.Add(workbook.GetSheetName(i));
                }

                workbook.Close();
            }
            return sheetNamelist;
        }
        
    }
}
