using Squeeze.Models;
using Squeeze.Repository.IRepository;
using Squeeze.Mapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Squeeze.Service.IService;

namespace Squeeze.Service
{
    public class BestillingService : IBestillingService
    {

        private readonly IBestillingRepository _repository;

        public BestillingService(IBestillingRepository repository)
        {
            _repository = repository;
        }

        public async Task<BestillingDTO> CreateBestillingAsync(BestillingDTO bestillingDto)
        {
            var bestilling = BestillingMapper.FromDTO(bestillingDto);
            var createdBestilling = await _repository.AddAsync(bestilling);
            return BestillingMapper.ToDTO(createdBestilling);
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
            var bestilling = BestillingMapper.FromDTO(bestillingDto);
            return await _repository.UpdateAsync(bestilling);
        }
    }
}
   
