using CateringPro.Application.UseCases.Recipes.CreateRecipe;
using CateringPro.Application.UseCases.Recipes.GetRecipes;
using CateringPro.Common.CodeContracts;
using CateringPro.WebApi.Interface.Recipes.Commands;
using CateringPro.WebApi.Interface.Recipes.Queries;
using CateringPro.WebApi.Interface.Recipes.ViewModels;
using CateringPro.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.WebApi.Controllers
{

    public class RecipesController : BaseController
    {

        #region - - - - - - Fields - - - - - -

        private readonly ControllerAction m_ControllerAction;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public RecipesController(ControllerAction controllerAction)
        {
            this.m_ControllerAction = controllerAction ?? throw CodeContract.ArgumentNullException(nameof(controllerAction));
        }

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        [HttpPost]
        [ProducesResponseType(typeof(RecipeViewModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        public Task<IActionResult> CreateRecipe([FromBody] CreateRecipeCommand command)
            => this.m_ControllerAction.CreateAsync<RecipeViewModel, CreateRecipeRequest, CreateRecipeResponse>(command, CancellationToken.None);

        [HttpGet]
        [ProducesResponseType(typeof(RecipesViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        public Task<IActionResult> GetRecipes(GetRecipesQuery query)
            => this.m_ControllerAction.ReadAsync<RecipesViewModel, GetRecipesRequest, GetRecipesResponse>(query, CancellationToken.None);

        #endregion Methods

    }

}
