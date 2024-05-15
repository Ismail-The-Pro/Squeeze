using Squeeze.Models.DTO;
using Squeeze.Repository;
using Squeeze.Service.IService;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Squeeze.Mapper;
using Squeeze.Models;

namespace Squeeze.Service
{



    namespace Squeeze.Service
    {
        public class KundeService : IKundeService
        {
            private readonly IKundeRepository _repository;
         


            public KundeService(IKundeRepository repository)
            {
                _repository = repository;
                
            }

            public async Task<IEnumerable<KundeDTO>> GetAllKunderAsync()
            {
                var kunder = await _repository.GetAllKunderAsync();
                var kundeDTOs = kunder.Select(k => KundeMapper.ToDTO(k)).ToList();
                return kundeDTOs;
            }

            public async Task<KundeDTO> GetKundeByIdAsync(int id)
            {
                var kunde = await _repository.GetKundeByIdAsync(id);
                return kunde;
            }

            public async Task<KundeDTO> CreateKundeAsync(KundeDTO kundeDto)
            {
                return await _repository.CreateKundeAsync(kundeDto);
            }

            public async Task<bool> UpdateKundeAsync(KundeDTO kundeDto)
            {
                try
                {
                    await _repository.UpdateKundeAsync(kundeDto);
                    return true;
                }
                catch (Exception ex)
                {
                    
                    return false;
                }
            }

            public async Task<bool> DeleteKundeAsync(int id)
            {
                await _repository.DeleteKundeAsync(id);
                return true;
            }
        }
    }




}
