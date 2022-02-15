using CateringPro.Application.Infrastructure;
using CleanArchitecture.Services;
using FluentValidation.Results;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Ingredients.CreateIngredient
{

    public interface ICreateIngredientOutputPort :
        IAuthenticationOutputPort,
        IAuthorisationOutputPort<AuthorisationResult>,
        IBusinessRuleValidationOutputPort<ValidationResult>
    {

        #region - - - - - - Methods - - - - - -

        Task PresentCreatedIngredientAsync(CreatedIngredientDto ingredient, CancellationToken cancellationToken);

        #endregion Methods

    }

}
