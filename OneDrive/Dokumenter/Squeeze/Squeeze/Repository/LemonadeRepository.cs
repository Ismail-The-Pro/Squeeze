using Microsoft.EntityFrameworkCore;
using Squeeze.Models.DTO;
using Squeeze.Repository.IRepository;

namespace Squeeze.Repository
{
    public class LemonadeRepository : ILemonadeRepository
    {
        private readonly AppDbContext _context;

        public LemonadeRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Lemonade lemonade)
        {
            _context.Lemonades.Add(lemonade);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var lemonade = await _context.Lemonades.FindAsync(id);
            if (lemonade != null)
            {
                _context.Lemonades.Remove(lemonade);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Lemonade>> GetAllAsync()
        {
            return await _context.Lemonades.ToListAsync();
        }

        public async Task<Lemonade> GetByIdAsync(int id)
        {
            return await _context.Lemonades.FindAsync(id);
        }

        public async Task UpdateAsync(Lemonade lemonade)
        {
            _context.Entry(lemonade).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
