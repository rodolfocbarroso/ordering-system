using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<Import> GetById(Guid id)
        {
            return await _context.Imports
                .FirstOrDefaultAsync(import => import.Id == id);
        }

        public async Task<IEnumerable<dynamic>> GetAll()
        {
            return await _context.Imports
                .AsNoTracking()
                .OrderBy(import => import.Instant)
                .Select(Import =>
                    new
                    {
                        Date = Import.Instant,
                        total = Import.Items.Count
                    })
                .ToListAsync();

        }
    }
}
