using System;
using System.Collections.Generic;
using System.Text;
using Orders.Domain.Commands.Contracts;

namespace Orders.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        void Handle();
    }
}
