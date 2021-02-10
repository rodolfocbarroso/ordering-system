using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Notifications;

namespace Orders.Domain.Entities.Base
{
    public abstract class Entity : Notifiable
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
