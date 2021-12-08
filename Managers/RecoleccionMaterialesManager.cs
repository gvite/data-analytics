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
    public class RecoleccionMaterialesManager : Manager
    {
        public RecoleccionMaterialesManager(ApplicationDbContext context) : base(context) { }
        public async Task<int> AddAsync(RecoleccionMateriales recoleccionMateriales)
        {
            await _context.RecoleccionMateriales.AddAsync(recoleccionMateriales);
            if (AutoSave)
                await _context.SaveChangesAsync();
            return recoleccionMateriales.Id;
        }
        public async Task<RecoleccionMateriales> GetByPvYearMonthMaterial(int pvId, int year, string month, int materialId)
        {
            return await _context.RecoleccionMateriales.Where(item => item.PuntoVerdeId == pvId && item.Anio == year && item.Mes == month && item.MaterialId == materialId).FirstOrDefaultAsync();
        }
        public void Update(RecoleccionMateriales recoleccionMateriales)
        {
            _context.RecoleccionMateriales.Update(recoleccionMateriales);
            if (AutoSave)
                _context.SaveChanges();
        }
    }
}
