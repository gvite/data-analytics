using System;
using Microsoft.EntityFrameworkCore;
using PuntosVerdes.Models;
namespace PuntosVerdes.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Barrio> Barrio { get; set; }
        public DbSet<Comuna> Comuna { get; set; }
        public DbSet<Cooperativa> Cooperativa { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<PuntoVerde> PuntoVerde { get; set; }
        public DbSet<PuntoverdeMateriales> PuntoverdeMateriales { get; set; }
        public DbSet<RecoleccionMateriales> RecoleccionMateriales { get; set; }
        public DbSet<Visitas> Visitas { get; set; }
        public DbSet<Poblacion> Poblacion { get; set; }
        public ApplicationDbContext() : base()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
