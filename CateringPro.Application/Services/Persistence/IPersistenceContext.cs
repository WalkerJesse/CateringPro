using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.Services.Persistence
{

    public interface IPersistenceContext
    {
        Task<TEntity> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class;

        Task<IQueryable<TEntity>> GetEntitiesAsync<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }

}
