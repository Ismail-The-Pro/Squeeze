namespace Squeeze.Repository.IRepository
{
    public interface IBestillingRepository
    {
        Task<IEnumerable<Bestilling>> GetAllAsync();
        Task<Bestilling> GetByIdAsync(int id);
        Task <Bestilling> AddAsync(Bestilling bestilling);
        Task<bool>UpdateAsync(Bestilling bestilling);
        Task<bool> DeleteAsync(int id);
    }
}