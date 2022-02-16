using CateringPro.Application.Infrastructure.Authorisation;
using CleanArchitecture.Services;
using FluentValidation.Results;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Recipes.CreateRecipe
{

    public interface ICreateRecipeOutputPort :
        IAuthenticationOutputPort,
        IAuthorisationOutputPort<AuthorisationResult>,
        IValidationOutputPort<ValidationResult> // IUseCaseInputPortValidator<ValidationResult>
    {

        #region - - - - - - Methods - - - - - -

        Task PresentRecipeAsync(CreatedRecipeDto recipe, CancellationToken cancellationToken);

        #endregion Methods

    }

}
