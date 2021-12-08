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
    public class VisitasManager : Manager
    {
        public VisitasManager(ApplicationDbContext context) : base(context) { }
        public async Task<int> AddAsync(Visitas visitas)
        {
            await _context.Visitas.AddAsync(visitas);
            if (AutoSave)
                await _context.SaveChangesAsync();
            return visitas.Id;
        }
        public async Task<Visitas> GetByPvYearMonth(int pvId, int year, string month)
        {
            return await _context.Visitas.Where(item => item.PuntoVerdeId == pvId && item.Anio == year && item.Mes == month).FirstOrDefaultAsync();
        }
        public void Update(Visitas visitas)
        {
            _context.Visitas.Update(visitas);
            if (AutoSave)
                _context.SaveChanges();
        }
    }
}
