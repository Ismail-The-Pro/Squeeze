using Microsoft.EntityFrameworkCore;
using Squeeze.Models;
using Squeeze.Repository.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Squeeze.Repository
{
    public class BestillingRepository : IBestillingRepository
    {
        private readonly AppDbContext _context;

        public BestillingRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Bestilling> AddAsync(Bestilling bestilling)
        {
            _context.Bestillinger.Add(bestilling);
            await _context.SaveChangesAsync();
            return bestilling;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var bestilling = await _context.Bestillinger.FindAsync(id);
            if (bestilling == null)
            {
                return false;
            }
            _context.Bestillinger.Remove(bestilling);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Bestilling>> GetAllAsync()
        {
            return await _context.Bestillinger
                 .AsNoTracking()
                 .ToListAsync();




        }

        public async Task<Bestilling> GetByIdAsync(int id)
        {
            return await _context.Bestillinger.AsNoTracking()
                .FirstOrDefaultAsync(b => b.BestillingId == id);
        }

        public async Task<bool> UpdateAsync(Bestilling bestilling)
        {
            var existingBestilling = await _context.Bestillinger
                .FirstOrDefaultAsync(b => b.BestillingId == bestilling.BestillingId);

            if (existingBestilling == null)
            {
                return false;

            }

            _context.Entry(existingBestilling).CurrentValues.SetValues(bestilling);
            await _context.SaveChangesAsync();
            return true;

       }

            

        
    }
        
    

}