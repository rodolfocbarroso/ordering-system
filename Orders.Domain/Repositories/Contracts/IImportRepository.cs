using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using Orders.Domain.Entities;

namespace Orders.Domain.Repositories.Contracts
{
    public interface IImportRepository
    {
        void Save(Import import);
        Import GetById(Guid id);
        IEnumerable<Import> GetAll();

    }
}
