using AutoMapper;
using CateringPro.Application.Services;
using CateringPro.Application.Services.Persistence;
using CateringPro.Common.CodeContracts;
using CateringPro.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Ingredients.CreateIngredient
{

    public class CreateIngredientInteractor : IUseCaseInteractor<CreateIngredientRequest, CreateIngredientResponse>
    {

        #region - - - - - - Fields - - - - - -

        private readonly IMapper m_Mapper;
        private readonly IPersistenceContext m_PersistenceContext;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public CreateIngredientInteractor(IMapper mapper, IPersistenceContext persistenceContext)
        {
            this.m_Mapper = mapper ?? throw CodeContract.ArgumentNullException(nameof(mapper));
            this.m_PersistenceContext = persistenceContext ?? throw CodeContract.ArgumentNullException(nameof(persistenceContext));
        }

        #endregion Constructors

        #region - - - - - - IUseCaseInteractor Implementation - - - - - -

        public async Task HandleAsync(CreateIngredientRequest request, IPresenter<CreateIngredientResponse> presenter, CancellationToken cancellationToken)
        {
            var _Ingredient = this.m_Mapper.Map<Ingredient>(request);

            await this.m_PersistenceContext.AddAsync(_Ingredient, cancellationToken);

            await presenter.PresentAsync(this.m_Mapper.Map<CreateIngredientResponse>(_Ingredient), cancellationToken);
        }

        #endregion IUseCaseInteractor Implementation

    }

}
