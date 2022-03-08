using AutoMapper;
using AutoMapper.QueryableExtensions;
using CateringPro.Application.Dtos;
using CateringPro.Application.Services.Persistence;
using CateringPro.Domain.Entities;
using CleanArchitecture.Mediator;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Ingredients.GetIngredients
{

    public class GetIngredientsInteractor : IUseCaseInteractor<GetIngredientsInputPort, IGetIngredientsOutputPort>
    {

        #region - - - - - - Fields - - - - - -

        private readonly IMapper m_Mapper;
        private readonly IPersistenceContext m_PersistenceContext;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public GetIngredientsInteractor(IMapper mapper, IPersistenceContext persistenceContext)
        {
            this.m_Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.m_PersistenceContext = persistenceContext ?? throw new ArgumentNullException(nameof(persistenceContext));
        }

        #endregion Constructors

        #region - - - - - - IUseCaseInteractor Implementation - - - - - -

        public Task HandleAsync(GetIngredientsInputPort inputPort, IGetIngredientsOutputPort outputPort, CancellationToken cancellationToken)
            => outputPort.PresentIngredientsAsync(
                this.m_PersistenceContext
                    .GetEntities<Ingredient>()
                    .ProjectTo<IngredientDto>(this.m_Mapper.ConfigurationProvider),
                cancellationToken);

        #endregion IUseCaseInteractor Implementation

    }

}
