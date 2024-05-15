using Squeeze.Mapper;
using Squeeze.Models.DTO;
using Squeeze.Repository.IRepository;

namespace Squeeze.Service
{
    public class LemonadeService : ILemonadeService
    {
        private readonly ILemonadeRepository _repository;

        public LemonadeService(ILemonadeRepository repository)
        {
            _repository = repository;
        }

        public async Task<LemonadeDTO> CreateLemonadeAsync(LemonadeDTO lemonadeDto)
        {
            var lemonade = LemonadeMapper.FromDTO(lemonadeDto);
            await _repository.AddAsync(lemonade);
            return LemonadeMapper.ToDTO(lemonade);
        }

        public async Task DeleteLemonadeAsync(int id)
        {
            await _repository.DeleteAsync(id);

        }

        public async Task<IEnumerable<LemonadeDTO>> GetAllLemonadesAsync()
        {
            var lemonades = await _repository.GetAllAsync();
            return lemonades.Select(LemonadeMapper.ToDTO);
        }

        public async Task<LemonadeDTO> GetLemonadeByIdAsync(int id)
        {
            var lemonade = await _repository.GetByIdAsync(id);
            return lemonade != null ? LemonadeMapper.ToDTO(lemonade) : null;
        }

        public async Task UpdateLemonadeAsync(LemonadeDTO lemonadeDto)
        {
            var lemonade = LemonadeMapper.FromDTO(lemonadeDto);
            await _repository.UpdateAsync(lemonade);
        }
    }
}