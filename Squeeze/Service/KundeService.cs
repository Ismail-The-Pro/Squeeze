using Squeeze.Mapper;
using Squeeze.Models;
using Squeeze.Models.DTO;
using Squeeze.Service.IService;

namespace Squeeze.Service
{
    public class KundeService : IKundeService
    {
        private readonly IKundeRepository _repository;

        public KundeService(IKundeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Kunde> CreateKundeAsync(Kunde kunde)
        {
            var kundeDTO = KundeMapper.ToDTO(kunde);
            var createdKundeDTO = await _repository.CreateKundeAsync(kundeDTO);
            return KundeMapper.FromDTO(createdKundeDTO);
        }

        public async Task DeleteKundeAsync(int id)
        {
            await _repository.DeleteKundeAsync(id);
        }

        public async Task<IEnumerable<Kunde>> GetAllKunderAsync()
        {
            var kundeDTOs = await _repository.GetAllKunderAsync();
            return kundeDTOs.Select(KundeMapper.FromDTO).ToList();
        }

        public async Task<Kunde> GetKundeByIdAsync(int id)
        {
            var kundeDTO = await _repository.GetKundeByIdAsync(id);
            return KundeMapper.FromDTO(kundeDTO);
        }

        public async Task UpdateKundeAsync(Kunde kunde)
        {
            var kundeDTO = KundeMapper.ToDTO(kunde); // Convert Domain Model to DTO
            await _repository.UpdateKundeAsync(kundeDTO);
        }
    }
}