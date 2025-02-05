using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using OfficeOpenXml;

public static class ExcelHelper
{
    public static List<T> ReadExcel<T>(string filePath) where T : new()
    {
        var result = new List<T>();

        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            var worksheet = package.Workbook.Worksheets[0];
            var columnMapping = new Dictionary<string, int>();

            // Read header row
            for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
            {
                columnMapping[worksheet.Cells[1, col].Text.Trim()] = col;
            }

            // Read data rows
            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var obj = new T();
                foreach (var prop in typeof(T).GetProperties())
                {
                    if (columnMapping.ContainsKey(prop.Name))
                    {
                        int colIndex = columnMapping[prop.Name];
                        string cellValue = worksheet.Cells[row, colIndex].Text;

                        if (!string.IsNullOrEmpty(cellValue))
                        {
                            object convertedValue = Convert.ChangeType(cellValue, prop.PropertyType);
                            prop.SetValue(obj, convertedValue);
                        }
                    }
                }
                result.Add(obj);
            }
        }
        return result;
    }
}
