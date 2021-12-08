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
    public class PuntoVerdeManager : Manager
    {
        public PuntoVerdeManager(ApplicationDbContext context) : base(context) { }
        public async Task<PuntoVerde> GetByNameAsync(string name)
        {
            return await _context.PuntoVerde.Where(item => item.Nombre == name).FirstOrDefaultAsync();
        }
        public async Task<int> AddAsync(PuntoVerde puntoVerde)
        {
            await _context.PuntoVerde.AddAsync(puntoVerde);
            if (AutoSave)
                await _context.SaveChangesAsync();
            return puntoVerde.Id;
        }
        public void Update(PuntoVerde puntoVerde)
        {
            _context.PuntoVerde.Update(puntoVerde);
            if (AutoSave)
                _context.SaveChanges();
        }
    }
}
