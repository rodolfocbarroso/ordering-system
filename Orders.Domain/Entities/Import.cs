using System;
using System.Collections.Generic;
using System.Text;
using Orders.Domain.Entities.Base;
using Orders.Domain.Enums;

namespace Orders.Domain.Entities
{
    public class Import : Entity
    {
        public Import(FileExtension fileExtension)
        {
            Instant = DateTime.Now;
            FileExtension = fileExtension;
            Items = new List<ImportItem>();
        }

        public DateTime Instant { get; private set; }
        public FileExtension FileExtension { get; private set; }

        public IList<ImportItem> Items { get; private set; }

        public void AddItem(long line, string name, DateTime deliveryDate, int quantity, decimal unitPrice)
        {
            var item = new ImportItem(line, name, deliveryDate, quantity, unitPrice);
            if (item.Valid)
                Items.Add(item);
        }
    }
}
