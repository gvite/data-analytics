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
    public class CooperativaManager : Manager
    {
        public CooperativaManager(ApplicationDbContext context) : base(context) { }
        public async Task<List<Cooperativa>> GetAllAsync()
        {
            var query = _context.Cooperativa.AsQueryable();
            TotalRegiters = query.Count();
            return await query.ToListAsync();
        }
        public async Task<Cooperativa> GetByIdAsync(int id)
        {
            return await _context.Cooperativa.Where(item => item.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Cooperativa> GetByNameAsync(string name)
        {
            return await _context.Cooperativa.Where(item => item.Nombre == name).FirstOrDefaultAsync();
        }
        public async Task<int> AddAsync(Cooperativa cooperativa)
        {
            await _context.Cooperativa.AddAsync(cooperativa);
            if (AutoSave)
                await _context.SaveChangesAsync();
            return cooperativa.Id;
        }
        public void Update(Cooperativa cooperativa)
        {
            _context.Cooperativa.Update(cooperativa);
            if (AutoSave)
                _context.SaveChanges();
        }
    }
}
