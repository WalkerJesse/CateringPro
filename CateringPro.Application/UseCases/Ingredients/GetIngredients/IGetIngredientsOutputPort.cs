using CateringPro.Application.Dtos;
using CleanArchitecture.Mediator;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Ingredients.GetIngredients
{

    public interface IGetIngredientsOutputPort :
        IAuthenticationOutputPort
    //IAuthorisationOutputPort<AuthorisationResult>
    {

        #region - - - - - - Methods - - - - - -

        Task PresentIngredientsAsync(IQueryable<IngredientDto> ingredients, CancellationToken cancellationToken);

        #endregion Methods

    }

}
