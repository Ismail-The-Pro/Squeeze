namespace Squeeze.Repository.IRepository
{
    public interface ILemonadeRepository
    {
        Task<IEnumerable<Lemonade>> GetAllAsync();
        Task<Lemonade> GetByIdAsync(int id);
        Task AddAsync(Lemonade lemonade);
        Task UpdateAsync(Lemonade lemonade);
        Task DeleteAsync(int id);

    }
}
