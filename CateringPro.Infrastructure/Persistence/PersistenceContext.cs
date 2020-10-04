using AutoMapper;
using AutoMapper.QueryableExtensions;
using CateringPro.Application.Services.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        async Task<TEntity> IPersistenceContext.AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken)
            => (await base.AddAsync(entity, cancellationToken)).Entity;

        public IEntities<TEntity> GetEntities<TEntity>() where TEntity : class
            => new Entities<TEntity>(this.Set<TEntity>());

        TEntity IPersistenceContext.Remove<TEntity>(TEntity entity)
            => base.Remove(entity).Entity;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersistenceContext).Assembly);
        }

        #endregion IPersistenceContext Implementation

    }

    public class Entities<TEntity> : IEntities<TEntity>
    {

        #region - - - - - - Fields - - - - - -

        private readonly IQueryable<TEntity> m_Entities;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public Entities(IQueryable<TEntity> entities)
            => this.m_Entities = entities;

        #endregion Constructors

        #region - - - - - - IEntities Implementation - - - - - -

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
            => this.m_Entities.FirstOrDefault(predicate);

        public IEntities<TDestinationEntity> ProjectTo<TDestinationEntity>(IConfigurationProvider configurationProvider)
            => new Entities<TDestinationEntity>(this.m_Entities.ProjectTo<TDestinationEntity>(configurationProvider));

        public List<TEntity> ToList()
            => this.m_Entities.ToList();

        #endregion IEntities Implementation

    }

}