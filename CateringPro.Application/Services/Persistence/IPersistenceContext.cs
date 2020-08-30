using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.Services.Persistence
{

    public interface IPersistenceContext
    {
        Task<TEntity> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken) where TEntity : class;

        IEntities<TEntity> GetEntities<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }

    public interface IEntities<TEntity>
    {

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        IEntities<TDestinationEntity> ProjectTo<TDestinationEntity>(IConfigurationProvider configurationProvider);

        List<TEntity> ToList();

    }

}
