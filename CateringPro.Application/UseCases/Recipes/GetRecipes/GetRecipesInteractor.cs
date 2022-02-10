using AutoMapper;
using CateringPro.Application.Services;
using CateringPro.Application.Services.Persistence;
using CateringPro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Recipes.GetRecipes
{

    public class GetRecipesInteractor : IUseCaseInteractor<GetRecipesRequest, GetRecipesResponse>
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

        public async Task HandleAsync(GetRecipesRequest request, IPresenter<GetRecipesResponse> presenter, CancellationToken cancellationToken)
        {
            var _Recipes = await this.m_PersistenceContext.GetEntitiesAsync<Recipe>();

            await presenter.PresentAsync(this.m_Mapper.Map<GetRecipesResponse>(this.m_Mapper.Map<List<RecipeDto>>(_Recipes)), cancellationToken);
        }

        #endregion IUseCaseInteractor Implementation

    }

}
