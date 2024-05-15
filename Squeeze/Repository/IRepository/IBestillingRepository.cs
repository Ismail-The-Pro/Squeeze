namespace Squeeze.Repository.IRepository
{
    public interface IBestillingRepository
    {
        Task<Bestilling> AddAsync(Bestilling bestilling);

        Task<IEnumerable<Bestilling>> GetAllAsync();
        Task<Bestilling> GetByIdAsync(int id);
       
        Task<bool>UpdateAsync(Bestilling bestilling);
        Task<bool> DeleteAsync(int id);
    }
}