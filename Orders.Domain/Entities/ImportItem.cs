using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Validations;
using Orders.Domain.Entities.Base;

namespace Orders.Domain.Entities
{
    public class ImportItem : Entity
    {
        public ImportItem(long line, string name, DateTime deliveryDate, int quantity, decimal unitPrice)
        {
            AddNotifications(
                new Contract()
                    .Requires()
                    .IsNotNullOrEmpty(name, "Name", "O nome não pode ser vazio.")
                    .HasMaxLen(name, 50, "Name", "O nome não pode ter tamanho maior que 50 caracteres.")
                    .IsNotNull(deliveryDate, "DeliveryDate", "A data de entrega não pode ser vazia.")
                    .IsLowerOrEqualsThan(deliveryDate, DateTime.Today, "DeliveryDate", "A data de entrega não pode ser menor ou igual ao dia de hoje.")
                    .IsLowerOrEqualsThan(quantity, 0, "Quantity", "A quantidade não pode ser menor ou igual a zero.")
                    .IsLowerOrEqualsThan(unitPrice, 0, "UnitPrice", "O preço unitário não pode menor ou igual a zero.")
            );

            Line = line;
            Name = name;
            DeliveryDate = deliveryDate;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public long Line { get; private set; }
        public string Name { get; private set; }
        public DateTime DeliveryDate { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
    }
}
