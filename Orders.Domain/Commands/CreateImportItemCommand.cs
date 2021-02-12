using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;
using Flunt.Validations;
using Orders.Domain.Commands.Contracts;

namespace Orders.Domain.Commands
{
    public class CreateImportItemCommand : Notifiable, ICommand
    {
        public CreateImportItemCommand()
        {
        }

        public CreateImportItemCommand(long line, string name, DateTime deliveryDate, int quantity, decimal unitPrice)
        {
            Line = line;
            Name = name;
            DeliveryDate = deliveryDate;
            Quantity = quantity;
            UnitPrice = Math.Round(unitPrice, 2);
        }

        public long Line { get; set; }
        public string Name { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public void Validate()
        {

        }
    }
}
