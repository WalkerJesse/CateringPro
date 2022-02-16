using CateringPro.Application.Dtos;
using CateringPro.Application.Infrastructure.Authorisation;
using CleanArchitecture.Services;
using FluentValidation.Results;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Ingredients.UpdateIngredient
{

    public interface IUpdateIngredientOutputPort :
        IAuthenticationOutputPort,
        IAuthorisationOutputPort<AuthorisationResult>,
        IValidationOutputPort<ValidationResult> // IUseCaseInputPortValidator<ValidationResult>
    {

        #region - - - - - - Methods - - - - - -

        Task PresentIngredientAsync(IngredientDto ingredient, CancellationToken cancellationToken);

        Task PresentIngredientNotFound(long ingredientID, CancellationToken cancellationToken);

        #endregion Methods

    }

}
