using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Orders.Domain.Entities;
using Orders.Domain.Repositories.Contracts;
using Orders.Infra.Contexts;

namespace Orders.Infra.Repositories
{
    public class ImportRepository : IImportRepository

    {
        private readonly DataContext _context;

        public ImportRepository(DataContext context)
        {
            _context = context;
        }

        public void Save(Import import)
        {
            _context.Add(import);
            _context.SaveChanges();
        }

        public Import GetById(Guid id)
        {
            return _context.Imports
                .FirstOrDefault(import => import.Id == id);
        }

        public IEnumerable<Import> GetAll()
        {
            return _context.Imports
                .AsNoTracking()
                .OrderBy(import => import.Instant)
                .ToList();
        }
    }
}
