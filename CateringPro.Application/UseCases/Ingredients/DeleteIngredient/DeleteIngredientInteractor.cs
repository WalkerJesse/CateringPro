using AutoMapper;
using CateringPro.Application.Services;
using CateringPro.Application.Services.Persistence;
using CateringPro.Common.CodeContracts;
using CateringPro.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Ingredients.DeleteIngredient
{

    public class DeleteIngredientInteractor : IUseCaseInteractor<DeleteIngredientRequest, DeleteIngredientResponse>
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
            var _Ingredient = await this.m_PersistenceContext.FindAsync<Ingredient>(new object[] { request.ID }, cancellationToken);

            if (_Ingredient == null)
                await presenter.PresentNotFoundAsync(EntityRequest.GetEntityRequest(nameof(request.ID), request.ID), cancellationToken);
            else
            {
                await this.m_PersistenceContext.RemoveAsync(_Ingredient);
                await presenter.PresentAsync(this.m_Mapper.Map<DeleteIngredientResponse>(_Ingredient), cancellationToken);
            }
        }

        #endregion IUseCaseInteractor Implementation

    }

}
