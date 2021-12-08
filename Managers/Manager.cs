using PuntosVerdes.Context;
using System.Threading.Tasks;

namespace PuntosVerdes.Managers
{
    public class Manager
    {
        protected readonly ApplicationDbContext _context;
        protected bool AutoSave { set; get; }
        protected int TotalRegiters { get; set; }
        public Manager(ApplicationDbContext context)
        {
            _context = context;
            AutoSave = true;
            TotalRegiters = 0;
        }
        public void SetAutoSave(bool autoSave)
        {
            AutoSave = autoSave;
        }
        public bool GetAutoSave()
        {
            return AutoSave;
        }
        public int GetTotalRegisters()
        {
            return TotalRegiters;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
