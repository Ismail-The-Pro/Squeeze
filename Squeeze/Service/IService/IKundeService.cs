using Squeeze.Models;

namespace Squeeze.Service.IService
{
    public interface IKundeService
    {
        Task<IEnumerable<Kunde>> GetAllKunderAsync();
        Task<Kunde> GetKundeByIdAsync(int id);
        Task<Kunde> CreateKundeAsync(Kunde kunde);
        Task UpdateKundeAsync(Kunde kunde);
        Task DeleteKundeAsync(int id);
    }
}
