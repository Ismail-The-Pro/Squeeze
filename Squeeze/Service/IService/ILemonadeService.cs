using Squeeze.Models.DTO;

public interface ILemonadeService
{
    Task<IEnumerable<LemonadeDTO>> GetAllLemonadesAsync();
    Task<LemonadeDTO> GetLemonadeByIdAsync(int id);
    Task<LemonadeDTO> CreateLemonadeAsync(LemonadeDTO lemonadeDto);
    Task UpdateLemonadeAsync(LemonadeDTO lemonadeDto);
    Task DeleteLemonadeAsync(int id);

}