using CateringPro.Application.Dtos;
using CateringPro.Application.Infrastructure.Authorisation;
using CateringPro.Application.Infrastructure.Validation;
using CleanArchitecture.Mediator;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Ingredients.UpdateIngredient
{

    public interface IUpdateIngredientOutputPort :
        IAuthenticationOutputPort,
        //IAuthorisationOutputPort<AuthorisationResult>,
        IValidationOutputPort<CleanValidationResult>
    {

        #region - - - - - - Methods - - - - - -

        Task PresentIngredientAsync(IngredientDto ingredient, CancellationToken cancellationToken);

        Task PresentIngredientNotFound(long ingredientID, CancellationToken cancellationToken);

        #endregion Methods

    }

}
