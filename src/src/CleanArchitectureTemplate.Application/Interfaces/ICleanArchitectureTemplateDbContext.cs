using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitectureTemplate.Application.Interfaces
{
    public interface ICleanArchitectureTemplateDbContext
    {
        DbSet<T> Set<T>() where T : class;
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
