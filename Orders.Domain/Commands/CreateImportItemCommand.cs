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
            UnitPrice = unitPrice;
        }

        public long Line { get; set; }
        public string Name { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public void Validate()
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .AreNotEquals(Line, 0, "Line", "A linha está inválida.")
                    .IsNotNullOrEmpty(Name, "Name", "O nome não pode ser vazio.")
                    .HasMaxLen(Name, 50, "Name", "O nome não pode ter tamanho maior que 50 caracteres.")
                    .AreNotEquals(DeliveryDate, new DateTime(0001, 01, 01), "DeliveryDate", "A data de entrega não pode ser vazia.")
                    .AreNotEquals(DeliveryDate, DateTime.Today, "DeliveryDate", "A data de entrega não pode ser igual ao dia de hoje.")
                    .IsGreaterThan(DeliveryDate, DateTime.Today, "DeliveryDate", "A data de entrega não pode ser menor que o dia de hoje.")
                    .AreNotEquals(Quantity, 0, "Quantity", "A quantidade não pode ser igual a zero.")
                    .IsGreaterThan(Quantity, 0, "Quantity", "A quantidade não pode ser menor que zero.")
                    .AreNotEquals(UnitPrice, 0, "UnitPrice", "O preço unitário não pode ser igual a zero.")
                    .IsGreaterThan(UnitPrice, 0, "UnitPrice", "O preço unitário não pode ser menor que zero.")
            );
        }
    }
}
