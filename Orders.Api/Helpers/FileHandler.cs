using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using Orders.Domain.Commands;

namespace Orders.Api.Helpers
{
    public static class FileHandler
    {
        public static IList<CreateImportItemCommand> Excel(IFormFile file)
        {
            var items = new List<CreateImportItemCommand>();

            using var stream = new MemoryStream();

            file.CopyTo(stream);
            using var package = new ExcelPackage(stream);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
            var rowcount = worksheet.Dimension.Rows;
            for (var row = 2; row < rowcount; row++)
            {
                items.Add(new CreateImportItemCommand
                {
                    Line = row,
                    DeliveryDate = DateTime.Parse(worksheet.Cells[row, 1].Value.ToString()?.Trim() ?? string.Empty),
                    Name = worksheet.Cells[row, 2].Value.ToString()?.Trim(),
                    Quantity = short.Parse(worksheet.Cells[row, 3].Value.ToString()?.Trim() ?? string.Empty),
                    UnitPrice = decimal.Parse(worksheet.Cells[row, 4].Value.ToString()?.Trim() ?? string.Empty),
                });
            }

            return items;
        }
    }
}
