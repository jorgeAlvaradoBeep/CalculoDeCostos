using Calculo_De_Costos.Models;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculo_De_Costos.Services
{
    public class ExcelClass
    {
        public static List<PIProducts> GetBaseProductInfo(string[] col, int startRow, int endRow, string path)
        {
            List<PIProducts> pIProducts = new List<PIProducts>();
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(path);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            
            for(int y = startRow;y<=endRow;y++)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (xlRange.Cells[y, col[i]] == null || xlRange.Cells[y, col[i]].Value2 == null)
                    {
                        MessageBox.Show($"Error en la columna {col[i]}, valor o celda nula", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return pIProducts;
                    }
                }
                pIProducts.Add(new PIProducts
                {
                    id_product = xlRange.Cells[y, col[0]].Value2,
                    name = xlRange.Cells[y, col[1]].Value2,
                    quantity = (float)xlRange.Cells[y, col[2]].Value2,
                    price = (float)xlRange.Cells[y, col[3]].Value2,
                    weight = (float)xlRange.Cells[y, col[4]].Value2
                });
                
            }
            //cleanup  
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:  
            //  never use two dots, all COM objects must be referenced and released individually  
            //  ex: [somthing].[something].[something] is bad  

            //release com objects to fully kill excel process from running in the background  
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release  
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release  
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);

            return pIProducts;
        }
        private string[] GetRange(string range, Worksheet excelWorksheet)
        {
            Microsoft.Office.Interop.Excel.Range workingRangeCells =
              excelWorksheet.get_Range(range, Type.Missing);
            //workingRangeCells.Select();

            System.Array array = (System.Array)workingRangeCells.Cells.Value2;

            return null;
        }
    }
}
