using System;
using System.Threading.Tasks;
using PuntosVerdes.Models;
using PuntosVerdes.Context;

namespace PuntosVerdes.Managers
{
    public class PuntoVerdeMaterialesManager : Manager
    {
        public PuntoVerdeMaterialesManager(ApplicationDbContext context) : base(context) { }
        public async Task<int> AddAsync(PuntoverdeMateriales puntoverdeMateriales)
        {
            await _context.PuntoverdeMateriales.AddAsync(puntoverdeMateriales);
            if (AutoSave)
                await _context.SaveChangesAsync();
            return puntoverdeMateriales.Id;
        }
        public void Update(PuntoverdeMateriales puntoverdeMateriales)
        {
            _context.PuntoverdeMateriales.Update(puntoverdeMateriales);
            if (AutoSave)
                _context.SaveChanges();
        }
    }
}
