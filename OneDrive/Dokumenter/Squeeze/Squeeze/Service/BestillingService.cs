using Squeeze.Models;
using Squeeze.Repository.IRepository;
using Squeeze.Mapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Squeeze.Service.IService;
using Sqyeeze.Models.DTO;

namespace Squeeze.Service
{
    public class BestillingService : IBestillingService
    {

        private readonly IBestillingRepository _repository;
        private readonly AppDbContext _context;


        public BestillingService(IBestillingRepository repository, AppDbContext context)
        {
            _repository = repository;
            _context = context;

        }

        public async Task<BestillingDTO> CreateBestillingAsync(BestillingDTO bestillingDto)
        {
            if (bestillingDto == null)
            {
                throw new ArgumentNullException(nameof(bestillingDto));
            }

            // Bruker BestillingMapper for å konvertere DTO til entitet
            var bestilling = BestillingMapper.ToEntity(bestillingDto);

            // Validerer at kunden eksisterer
            var kunde = await _context.Kunder.FindAsync(bestilling.KundeId);
            if (kunde == null)
            {
                throw new KeyNotFoundException("Kunden finnes ikke.");
            }

            // Legger til og lagrer bestillingen
            _context.Bestillinger.Add(bestilling);
            await _context.SaveChangesAsync();

            // Bruker BestillingMapper for å konvertere entitet tilbake til DTO
            return BestillingMapper.ToDTO(bestilling);
        }

        public async Task<bool> DeleteBestillingAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<BestillingDTO>> GetAllBestillingerAsync()
        {
            var bestillinger = await _repository.GetAllAsync();
            return bestillinger.Select(BestillingMapper.ToDTO).ToList();
        }

        public async Task<BestillingDTO> GetBestillingByIdAsync(int id)
        {
            var bestilling = await _repository.GetByIdAsync(id);
            return bestilling != null ? BestillingMapper.ToDTO(bestilling) : null;
        }

        public async Task<bool> UpdateBestillingAsync(BestillingDTO bestillingDto)
        {
            var bestilling = BestillingMapper.ToEntity(bestillingDto);
            return await _repository.UpdateAsync(bestilling);
        }
    }
}
   
