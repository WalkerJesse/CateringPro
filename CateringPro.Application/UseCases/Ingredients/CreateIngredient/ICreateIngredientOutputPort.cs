using CateringPro.Application.Infrastructure.Authorisation;
using CateringPro.Application.Infrastructure.Validation;
using CleanArchitecture.Services;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Ingredients.CreateIngredient
{

    public interface ICreateIngredientOutputPort :
        IAuthenticationOutputPort,
        IAuthorisationOutputPort<AuthorisationResult>,
        IValidationOutputPort<CleanValidationResult>
    {

        #region - - - - - - Methods - - - - - -

        Task PresentIngredientAsync(CreatedIngredientDto ingredient, CancellationToken cancellationToken);

        #endregion Methods

    }

}
