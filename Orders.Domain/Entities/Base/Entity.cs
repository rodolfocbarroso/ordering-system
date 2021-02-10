using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;

namespace Orders.Domain.Entities.Base
{
    public class Entity : Notifiable
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
