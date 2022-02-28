using CateringPro.Application.Dtos;
using CleanArchitecture.Mediator;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Recipes.GetRecipes
{

    public interface IGetRecipesOutputPort :
        IAuthenticationOutputPort
    //IAuthorisationOutputPort<AuthorisationResult>
    {

        #region - - - - - - Methods - - - - - -

        Task PresentRecipesAsync(IQueryable<RecipeDto> ingredient, CancellationToken cancellationToken);

        #endregion Methods

    }

}
