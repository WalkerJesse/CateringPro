using CateringPro.Application.UseCases.Ingredients.CreateIngredient;
using CateringPro.Common.CodeContracts;
using CateringPro.Presentation.Models.Ingredients.CreateIngredient;
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
        [ProducesResponseType(typeof(CreateIngredientViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        public Task<IActionResult> CreateIngredient([FromBody] CreateIngredientCommand command)
            => this.m_ControllerAction.CreateAsync<CreateIngredientViewModel, CreateIngredientRequest, CreateIngredientResponse>(command, CancellationToken.None);

        #endregion Methods

    }

}
