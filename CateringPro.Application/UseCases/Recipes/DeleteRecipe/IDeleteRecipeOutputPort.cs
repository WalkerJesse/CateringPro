using CateringPro.Application.Dtos;
using CleanArchitecture.Mediator;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Recipes.DeleteRecipe
{

    public interface IDeleteRecipeOutputPort : IAuthenticationOutputPort
    {

        #region - - - - - - Properties - - - - - -

        Task PresentDeletedRecipeAsync(RecipeDto recipe, CancellationToken cancellationToken);

        Task PresentRecipeNotFound(long recipeID, CancellationToken cancellationToken);

        #endregion Properties

    }

}
