using Sqyeeze.Models.DTO;

namespace Squeeze.Service.IService
{
   
        public interface IBestillingService
        {
            Task<IEnumerable<BestillingDTO>> GetAllBestillingerAsync();  // Get all bestillings
            Task<BestillingDTO> GetBestillingByIdAsync(int id);          // Get a single bestilling by ID
            Task<BestillingDTO> CreateBestillingAsync(BestillingDTO bestillingDto);  // Create a new bestilling
            Task<bool> UpdateBestillingAsync(BestillingDTO bestillingDto);           // Update an existing bestilling
            Task<bool> DeleteBestillingAsync(int id);                   // Delete a bestilling
        }


}

