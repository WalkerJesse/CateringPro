using AutoMapper;
using AutoMapper.QueryableExtensions;
using CateringPro.Application.Dtos;
using CateringPro.Application.Services.Persistence;
using CateringPro.Domain.Entities;
using CleanArchitecture.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Recipes.GetRecipes
{

    public class GetRecipesInteractor : IUseCaseInteractor<GetRecipesInputPort, IGetRecipesOutputPort>
    {

        #region - - - - - - Fields - - - - - -

        private readonly IMapper m_Mapper;
        private readonly IPersistenceContext m_PersistenceContext;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public GetRecipesInteractor(IMapper mapper, IPersistenceContext persistenceContext)
        {
            this.m_Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.m_PersistenceContext = persistenceContext ?? throw new ArgumentNullException(nameof(persistenceContext));
        }

        #endregion Constructors

        #region - - - - - - IUseCaseInteractor Implementation - - - - - -

        public Task HandleAsync(GetRecipesInputPort inputPort, IGetRecipesOutputPort outputPort, CancellationToken cancellationToken)
            => outputPort.PresentRecipesAsync(
                this.m_PersistenceContext
                    .GetEntities<Recipe>()
                    .ProjectTo<RecipeDto>(this.m_Mapper.ConfigurationProvider),
                cancellationToken);

        #endregion IUseCaseInteractor Implementation

    }

}
