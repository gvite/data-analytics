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
    public class BarrioManager : Manager
    {
        public BarrioManager(ApplicationDbContext context) : base(context) { }
        public async Task<List<Barrio>> GetAllAsync()
        {
            var query = _context.Barrio.AsQueryable();
            TotalRegiters = query.Count();
            return await query.ToListAsync();
        }
        public async Task<Barrio> GetByIdAsync(int id)
        {
            return await _context.Barrio.Where(item => item.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Barrio> GetByNameAsync(string name)
        {
            return await _context.Barrio.Where(item => item.Nombre == name).FirstOrDefaultAsync();
        }
        public async Task<int> AddAsync(Barrio barrio)
        {
            await _context.Barrio.AddAsync(barrio);
            if (AutoSave)
                await _context.SaveChangesAsync();
            return barrio.Id;
        }
        public void Update(Barrio barrio)
        {
            _context.Barrio.Update(barrio);
            if (AutoSave)
                _context.SaveChanges();
        }
    }
}
