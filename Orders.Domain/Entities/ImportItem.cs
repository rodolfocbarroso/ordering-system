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
                    .AreNotEquals(line, 0, "Line", "A linha está inválida.")
                    .IsNotNullOrEmpty(name, "Name", "O nome não pode ser vazio.")
                    .HasMaxLen(name, 50, "Name", "O nome não pode ter tamanho maior que 50 caracteres.")
                    .AreNotEquals(deliveryDate, new DateTime(0001, 01, 01), "DeliveryDate", "A data de entrega não pode ser vazia.")
                    .AreNotEquals(deliveryDate, DateTime.Today, "DeliveryDate", "A data de entrega não pode ser igual ao dia de hoje.")
                    .IsGreaterThan(deliveryDate, DateTime.Today, "DeliveryDate", "A data de entrega não pode ser menor que o dia de hoje.")
                    .AreNotEquals(quantity, 0, "Quantity", "A quantidade não pode ser igual a zero.")
                    .IsGreaterThan(quantity, 0, "Quantity", "A quantidade não pode ser menor que zero.")
                    .AreNotEquals(unitPrice, 0, "UnitPrice", "O preço unitário não pode ser igual a zero.")
                    .IsGreaterThan(unitPrice, 0, "UnitPrice", "O preço unitário não pode ser menor que zero.")
            );

            Line = line;
            Name = name;
            DeliveryDate = deliveryDate;
            Quantity = quantity;
            UnitPrice = Math.Round(unitPrice, 2);
        }

        public long Line { get; private set; }
        public string Name { get; private set; }
        public DateTime DeliveryDate { get; private set; }
        public int Quantity { get; private set; }
        public decimal UnitPrice { get; private set; }
        public Import Import { get; set; }
    }
}
