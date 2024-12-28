using ProductManagement.Domain.Base;
using ProductManagement.Infrastructure.Data;

namespace ProductManagement.Infrastructure.Base;

public class BaseWriteRepository<T> : IBaseWriteRepository<T> where T : BaseEntity
{
    private readonly ProductManagmentDbContext _context;

    public BaseWriteRepository(ProductManagmentDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task AddAsync(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task SoftDeleteAsync(T entity)
    {
        entity.SetIsDeleted(true);
        _context.Set<T>().Update(entity);
        await _context.SaveChangesAsync();
    }
}
