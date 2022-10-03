using Code.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Code.Aplication.Common.Interfaces
{
    public interface IAplicationDbContext
    { 
        DbSet<Category> Categories { get; set; }
        DbSet<Product>  Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
