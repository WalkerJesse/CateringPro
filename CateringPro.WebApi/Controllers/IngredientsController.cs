using CateringPro.Application.UseCases.Ingredients.CreateIngredient;
using CateringPro.Application.UseCases.Ingredients.DeleteIngredient;
using CateringPro.Application.UseCases.Ingredients.GetIngredients;
using CateringPro.Application.UseCases.Ingredients.UpdateIngredient;
using CateringPro.Common.CodeContracts;
using CateringPro.WebApi.Interface.Ingredients.Commands;
using CateringPro.WebApi.Interface.Ingredients.Queries;
using CateringPro.WebApi.Interface.Ingredients.ViewModels;
using CateringPro.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.WebApi.Controllers
{

    public class IngredientsController : BaseController
    {

        #region - - - - - - Fields - - - - - -

        private readonly ControllerAction m_ControllerAction;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public IngredientsController(ControllerAction controllerAction)
        {
            this.m_ControllerAction = controllerAction ?? throw CodeContract.ArgumentNullException(nameof(controllerAction));
        }

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        [HttpPost]
        [ProducesResponseType(typeof(IngredientViewModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        public Task<IActionResult> CreateIngredient([FromBody] CreateIngredientCommand command)
            => this.m_ControllerAction.CreateAsync<IngredientViewModel, CreateIngredientRequest, CreateIngredientResponse>(command, CancellationToken.None);


        [HttpDelete("/{ingredientID:long}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.NotFound)]
        public Task<IActionResult> DeleteIngredient([FromBody] DeleteIngredientCommand command, [FromRoute] long ingredientID)
            => this.m_ControllerAction.UpdateAsync<DeleteIngredientRequest, DeleteIngredientResponse>(command, r => r.IngredientID = ingredientID, CancellationToken.None);

        [HttpGet]
        [ProducesResponseType(typeof(IngredientsViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        public Task<IActionResult> GetIngredients(GetIngredientsQuery query)
            => this.m_ControllerAction.ReadAsync<IngredientsViewModel, GetIngredientsRequest, GetIngredientsResponse>(query, CancellationToken.None);

        [HttpPut("/{ingredientID:long}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.NotFound)]
        public Task<IActionResult> UpdateIngredient([FromBody] UpdateIngredientCommand command, [FromRoute] long ingredientID)
            => this.m_ControllerAction.UpdateAsync<UpdateIngredientRequest, UpdateIngredientResponse>(command, r => r.IngredientID = ingredientID, CancellationToken.None);

        #endregion Methods

    }

}
