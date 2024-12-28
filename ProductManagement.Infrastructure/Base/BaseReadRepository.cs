using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Base;
using ProductManagement.Infrastructure.Data;

namespace ProductManagement.Infrastructure.Base;

public class BaseReadRepository<T> : IBaseReadRepository<T> where T : BaseEntity
{
    private readonly ProductManagmentDbContext _context;

    public BaseReadRepository(ProductManagmentDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _context.Set<T>().FirstOrDefaultAsync(x=>!x.IsDeleted && x.Id==id);
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().Where(x => !x.IsDeleted).ToListAsync();
    }
}
