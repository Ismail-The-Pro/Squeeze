using Squeeze.Models;
using Squeeze.Models.DTO;

public interface IKundeRepository
{
    Task<IEnumerable<KundeDTO>> GetAllKunderAsync();
    Task<KundeDTO> GetKundeByIdAsync(int id);
    Task<KundeDTO> CreateKundeAsync(KundeDTO kundeDto);
    Task UpdateKundeAsync(KundeDTO kundeDto);
    Task DeleteKundeAsync(int id);  // This is your delete method
}



