using CateringPro.Application.Services;
using CateringPro.Application.Services.Persistence;
using CateringPro.Common.CodeContracts;
using CateringPro.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Recipes.CreateRecipe
{

    public class CreateRecipeBusinessRuleValidator : IBusinessRuleValidator<CreateRecipeRequest, CreateRecipeResponse>
    {

        #region - - - - - - Fields - - - - - -

        private readonly IPersistenceContext m_PersistenceContext;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public CreateRecipeBusinessRuleValidator(IPersistenceContext persistenceContext)
        {
            this.m_PersistenceContext = persistenceContext ?? throw CodeContract.ArgumentNullException(nameof(persistenceContext));
        }

        #endregion Constructors

        #region - - - - - - IBusinessRuleValidator Implementation - - - - - -

        public async Task ValidateAsync(CreateRecipeRequest request, IPresenter<CreateRecipeResponse> presenter, CancellationToken cancellationToken)
        {
            if (request.Ingredients != null)
                foreach (var _IngredientDto in request.Ingredients)
                {
                    var _Ingredient = await this.m_PersistenceContext.FindAsync<Ingredient>(new object[] { _IngredientDto.IngredientID }, CancellationToken.None);
                    if (_Ingredient == null)
                        await presenter.PresentNotFoundAsync(EntityRequest.GetEntityRequest(nameof(_IngredientDto.IngredientID), _IngredientDto.IngredientID), cancellationToken);
                }
        }

        #endregion IBusinessRuleValidator Implementation

    }

}
