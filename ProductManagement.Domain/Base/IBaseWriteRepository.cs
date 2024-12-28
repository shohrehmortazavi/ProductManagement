namespace ProductManagement.Domain.Base
{
    public interface IBaseWriteRepository<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task SoftDeleteAsync(T entity);
    }
}
