using System;
using System.Collections.Generic;
using System.Text;
using Orders.Domain.Entities.Base;
using Orders.Domain.Enums;

namespace Orders.Domain.Entities
{
    public class SpreadsheetImport : Import
    {

        public SpreadsheetImport(FileExtension fileExtension, ImportStatus importStatus) : base(fileExtension, importStatus)
        {
            Items = new List<SpreadsheetItem>();
        }


        public IList<SpreadsheetItem> Items { get; private set; }

        public void AddItem(long line, string name, DateTime deliveryDate, int quantity, decimal unitPrice)
        {
            var item = new SpreadsheetItem(line, name, deliveryDate, quantity, unitPrice);
            if (item.Valid)
                Items.Add(item);
        }
    }
}
