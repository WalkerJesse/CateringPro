using CleanArchitecture.Mediator;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.Application.UseCases.Ingredients.DeleteIngredient
{

    public interface IDeleteIngredientOutputPort :
        IAuthenticationOutputPort
    //IAuthorisationOutputPort<AuthorisationResult>
    {

        #region - - - - - - Methods - - - - - -

        Task PresentDeletedIngredientAsync(long ingredientID, CancellationToken cancellationToken);

        Task PresentIngredientNotFound(long ingredientID, CancellationToken cancellationToken);

        #endregion Methods

    }

}
