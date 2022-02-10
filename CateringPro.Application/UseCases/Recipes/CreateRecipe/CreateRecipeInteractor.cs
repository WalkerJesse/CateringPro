using AutoMapper;
using CateringPro.Application.Services;
using CateringPro.Application.Services.Persistence;
using CateringPro.Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Recipes.CreateRecipe
{

    public class CreateRecipeInteractor : IUseCaseInteractor<CreateRecipeRequest, CreateRecipeResponse>
    {

        #region - - - - - - Fields - - - - - -

        private readonly IMapper m_Mapper;
        private readonly IPersistenceContext m_PersistenceContext;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public CreateRecipeInteractor(IMapper mapper, IPersistenceContext persistenceContext)
        {
            this.m_Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.m_PersistenceContext = persistenceContext ?? throw new ArgumentNullException(nameof(persistenceContext));
        }

        #endregion Constructors

        #region - - - - - - IUseCaseInteractor Implementation - - - - - -

        public async Task HandleAsync(CreateRecipeRequest request, IPresenter<CreateRecipeResponse> presenter, CancellationToken cancellationToken)
        {
            var _Recipe = this.m_Mapper.Map<Recipe>(request);

            await this.m_PersistenceContext.AddAsync(_Recipe, cancellationToken);

            await presenter.PresentAsync(this.m_Mapper.Map<CreateRecipeResponse>(_Recipe), cancellationToken);
        }

        #endregion IUseCaseInteractor Implementation

    }

}
