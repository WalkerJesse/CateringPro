using CateringPro.Application.Dtos;
using CateringPro.Application.Infrastructure.Authorisation;
using CleanArchitecture.Services;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Ingredients.GetIngredients
{

    public interface IGetIngredientsOutputPort :
        IAuthenticationOutputPort,
        IAuthorisationOutputPort<AuthorisationResult>
    {

        #region - - - - - - Methods - - - - - -

        Task PresentIngredientsAsync(IQueryable<IngredientDto> ingredient, CancellationToken cancellationToken);

        #endregion Methods

    }

}
