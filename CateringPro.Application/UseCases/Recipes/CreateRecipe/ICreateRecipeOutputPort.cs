using CateringPro.Application.Infrastructure.Authorisation;
using CateringPro.Application.Infrastructure.Validation;
using CleanArchitecture.Services;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Recipes.CreateRecipe
{

    public interface ICreateRecipeOutputPort :
        IAuthenticationOutputPort,
        IAuthorisationOutputPort<AuthorisationResult>,
        IValidationOutputPort<CleanValidationResult>
    {

        #region - - - - - - Methods - - - - - -

        Task PresentRecipeAsync(CreatedRecipeDto recipe, CancellationToken cancellationToken);

        #endregion Methods

    }

}
