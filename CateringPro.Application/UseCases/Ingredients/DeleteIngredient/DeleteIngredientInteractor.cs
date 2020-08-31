using AutoMapper;
using CateringPro.Application.Services;
using CateringPro.Application.Services.Persistence;
using CateringPro.Common.CodeContracts;
using CateringPro.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Ingredients.DeleteIngredient
{

    public class DeleteIngredientInteractor
    {
        #region - - - - - - Fields - - - - - -

        private readonly IMapper m_Mapper;
        private readonly IPersistenceContext m_PersistenceContext;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public DeleteIngredientInteractor(IMapper mapper, IPersistenceContext persistenceContext)
        {
            this.m_Mapper = mapper ?? throw CodeContract.ArgumentNullException(nameof(mapper));
            this.m_PersistenceContext = persistenceContext ?? throw CodeContract.ArgumentNullException(nameof(persistenceContext));
        }

        #endregion Constructors

        #region - - - - - - IUseCaseInteractor Implementation - - - - - -

        public async Task HandleAsync(DeleteIngredientRequest request, IPresenter<DeleteIngredientResponse> presenter, CancellationToken cancellationToken)
        {
            var _Ingredient = this.m_PersistenceContext
                                .GetEntities<Ingredient>()
                                .FirstOrDefault(i => i.ID == request.IngredientID);

            if (_Ingredient == null)
                await presenter.PresentNotFoundAsync(EntityRequest.GetEntityRequest(nameof(request.IngredientID), request.IngredientID), cancellationToken);
            else
            {
                this.m_PersistenceContext.Remove(_Ingredient);
                await presenter.PresentAsync(this.m_Mapper.Map<DeleteIngredientResponse>(_Ingredient), cancellationToken);
            }
        }

        #endregion IUseCaseInteractor Implementation
    }

}
