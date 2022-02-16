using CateringPro.Application.Dtos;
using CateringPro.Application.Infrastructure;
using CleanArchitecture.Services;
using FluentValidation.Results;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Ingredients.DeleteIngredient
{

    public interface IDeleteIngredientOutputPort :
        IAuthenticationOutputPort,
        IAuthorisationOutputPort<AuthorisationResult>,
        IBusinessRuleValidationOutputPort<ValidationResult>
    {

        #region - - - - - - Methods - - - - - -

        Task PresentDeletedIngredientAsync(IngredientDto ingredient, CancellationToken cancellationToken);

        Task PresentIngredientNotFound(long ingredientID, CancellationToken cancellationToken);

        #endregion Methods

    }

}
