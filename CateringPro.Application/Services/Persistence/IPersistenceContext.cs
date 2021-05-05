using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.Services.Persistence
{

    public interface IPersistenceContext
    {

        Task AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class;

        Task<TEntity> FindAsync<TEntity>(object[] keyValues, CancellationToken cancellationToken) where TEntity : class;

        Task<IQueryable<TEntity>> GetEntitiesAsync<TEntity>() where TEntity : class;

        Task RemoveAsync<TEntity>(TEntity entity) where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }

}
