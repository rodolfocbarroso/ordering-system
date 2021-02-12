using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Orders.Domain.Entities;

namespace Orders.Domain.Repositories.Contracts
{
    public interface IImportRepository
    {
        void Save(Import import);
        Task<Import> GetById(Guid id);
        Task<IEnumerable<dynamic>> GetAll();

    }
}
