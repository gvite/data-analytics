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
    public class MaterialManager : Manager
    {
        public MaterialManager(ApplicationDbContext context) : base(context) { }
        public async Task<List<Material>> GetAllAsync()
        {
            var query = _context.Material.AsQueryable();
            TotalRegiters = query.Count();
            return await query.ToListAsync();
        }
        public async Task<Material> GetByIdAsync(int id)
        {
            return await _context.Material.Where(item => item.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Material> GetByNameAsync(string name)
        {
            return await _context.Material.Where(item => item.Nombre == name).FirstOrDefaultAsync();
        }
        public async Task<int> AddAsync(Material material)
        {
            await _context.Material.AddAsync(material);
            if (AutoSave)
                await _context.SaveChangesAsync();
            return material.Id;
        }
        public void Update(Material material)
        {
            _context.Material.Update(material);
            if (AutoSave)
                _context.SaveChanges();
        }
        
    }
}
