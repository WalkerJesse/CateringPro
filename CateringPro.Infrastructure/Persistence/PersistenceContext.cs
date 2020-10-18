using CateringPro.Application.Services.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Infrastructure.Persistence
{

    public class PersistenceContext : DbContext, IPersistenceContext
    {

        #region - - - - - - Constructors - - - - - -

        public PersistenceContext(DbContextOptions<PersistenceContext> options) : base(options) { }

        #endregion Constructors

        #region - - - - - - IPersistenceContext Implementation - - - - - -

        Task IPersistenceContext.AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken)
            => this.AddAsync(entity, cancellationToken).AsTask();

        Task<TEntity> IPersistenceContext.FindAsync<TEntity>(object[] keyValues, CancellationToken cancellationToken)
            => this.FindAsync<TEntity>(keyValues, cancellationToken).AsTask();

        public Task<IQueryable<TEntity>> GetEntitiesAsync<TEntity>() where TEntity : class
            => Task.FromResult(this.Set<TEntity>().AsQueryable());

        Task IPersistenceContext.RemoveAsync<TEntity>(TEntity entity)
            => Task.FromResult(this.Remove(entity));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersistenceContext).Assembly);
        }

        #endregion IPersistenceContext Implementation

    }

}
