using CateringPro.Application.UseCases.Recipes.CreateRecipe;
using CateringPro.Application.UseCases.Recipes.DeleteRecipe;
using CateringPro.Application.UseCases.Recipes.GetRecipes;
using CleanArchitecture.Mediator;

namespace CateringPro.InterfaceAdapters.Controllers
{

    public class RecipeController
    {

        #region - - - - - - Fields - - - - - -

        private readonly IUseCaseInvoker m_UseCaseInvoker;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public RecipeController(IUseCaseInvoker useCaseInvoker)
            => this.m_UseCaseInvoker = useCaseInvoker ?? throw new ArgumentNullException(nameof(useCaseInvoker));

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        public Task CreateRecipeAsync(CreateRecipeInputPort inputPort, ICreateRecipeOutputPort outputPort, CancellationToken cancellationToken)
            => this.m_UseCaseInvoker.InvokeUseCaseAsync(inputPort, outputPort, cancellationToken);

        public Task DeleteRecipeAsync(DeleteRecipeInputPort inputPort, IDeleteRecipeOutputPort outputPort, CancellationToken cancellationToken)
            => this.m_UseCaseInvoker.InvokeUseCaseAsync(inputPort, outputPort, cancellationToken);

        public Task GetRecipesAsync(IGetRecipesOutputPort outputPort, CancellationToken cancellationToken)
            => this.m_UseCaseInvoker.InvokeUseCaseAsync(new GetRecipesInputPort(), outputPort, cancellationToken);

        #endregion Methods

    }

}
