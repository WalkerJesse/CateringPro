using AutoMapper;
using CateringPro.Application.Services;
using CateringPro.Application.Services.Persistence;
using CateringPro.Common.CodeContracts;
using CateringPro.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Ingredients.GetIngredients
{

    public class GetIngredientsInteractor : IUseCaseInteractor<GetIngredientsRequest, GetIngredientsResponse>
    {

        #region - - - - - - Fields - - - - - -

        private readonly IMapper m_Mapper;
        private readonly IPersistenceContext m_PersistenceContext;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public GetIngredientsInteractor(IMapper mapper, IPersistenceContext persistenceContext)
        {
            this.m_Mapper = mapper ?? throw CodeContract.ArgumentNullException(nameof(mapper));
            this.m_PersistenceContext = persistenceContext ?? throw CodeContract.ArgumentNullException(nameof(persistenceContext));
        }

        #endregion Constructors

        #region - - - - - - IUseCaseInteractor Implementation - - - - - -

        public async Task HandleAsync(GetIngredientsRequest request, IPresenter<GetIngredientsResponse> presenter, CancellationToken cancellationToken)
        {
            var _Ingredients = this.m_PersistenceContext
                                .GetEntitiesAsync<Ingredient>()
                                .Result;

            var _IngredientDtos = this.m_Mapper.Map<List<IngredientDto>>(_Ingredients.ToList());

            var _Response = this.m_Mapper.Map<GetIngredientsResponse>(_IngredientDtos.ToList());

            await presenter.PresentAsync(_Response, cancellationToken);
        }

        #endregion IUseCaseInteractor Implementation

    }

}
