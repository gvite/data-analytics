using System;
using System.Threading.Tasks;
using PuntosVerdes.Models;
using PuntosVerdes.Context;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PuntosVerdes.Managers
{
    public class ComunaManager : Manager
    {
        public ComunaManager(ApplicationDbContext context) : base(context) { }
        public async Task<List<Comuna>> GetAllAsync()
        {
            var query = _context.Comuna.AsQueryable();
            TotalRegiters = query.Count();
            return await query.ToListAsync();
        }
        public async Task<Comuna> GetByIdAsync(int id)
        {
            return await _context.Comuna.Where(item => item.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Comuna> GetByNameAsync(string name)
        {
            return await _context.Comuna.Where(item => item.Nombre == name).FirstOrDefaultAsync();
        }
        public async Task<int> AddAsync(Comuna comuna)
        {
            await _context.Comuna.AddAsync(comuna);
            if (AutoSave)
                await _context.SaveChangesAsync();
            return comuna.Id;
        }
        public void Update(Comuna comuna)
        {
            _context.Comuna.Update(comuna);
            if (AutoSave)
                _context.SaveChanges();
        }
    }
}
