using System;
using System.Collections.Generic;
using System.Text;
using Orders.Domain.Entities.Base;
using Orders.Domain.Enums;

namespace Orders.Domain.Entities.Base
{
    public class Import : Entity
    {
        public Import(FileExtension fileExtension, ImportStatus importStatus)
        {
            Instant = DateTime.Now;
            FileType = fileExtension;
            ImportStatus = importStatus;
            Items = new List<ImportItem>();
        }

        public DateTime Instant { get; private set; }
        public ImportStatus ImportStatus { get; private set; }
        public FileExtension FileType { get; private set; }

        public IList<ImportItem> Items { get; private set; }

        public void AddItem(long line, string name, DateTime deliveryDate, int quantity, decimal unitPrice)
        {
            var item = new ImportItem(line, name, deliveryDate, quantity, unitPrice);
            if (item.Valid)
                Items.Add(item);
        }
    }
}
