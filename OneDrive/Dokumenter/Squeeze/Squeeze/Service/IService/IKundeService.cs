using Squeeze.Models;
using Squeeze.Models.DTO;

namespace Squeeze.Service.IService
{
    public interface IKundeService
    {
        Task<IEnumerable<KundeDTO>> GetAllKunderAsync();  
        Task<KundeDTO> GetKundeByIdAsync(int id);         
        Task<KundeDTO> CreateKundeAsync(KundeDTO kundeDto); 
        Task<bool> UpdateKundeAsync(KundeDTO kundeDto);      
        Task<bool> DeleteKundeAsync(int id);                 
    }

}
