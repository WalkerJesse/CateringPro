using AutoMapper;
using CateringPro.Common.CodeContracts;
using CateringPro.Presentation.Controllers;
using CateringPro.Presentation.Models.Ingredients.CreateIngredient;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.WebApi.Controllers
{

    public class IngredientsController : BaseController
    {

        #region - - - - - - Fields - - - - - -

        private const string MISSING_GET_LOCATION = "";

        private readonly IngredientController m_IngredientController;
        private readonly IMapper m_Mapper;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public IngredientsController(IngredientController ingredientController, IMapper mapper)
        {
            this.m_IngredientController = ingredientController ?? throw CodeContract.ArgumentNullException(nameof(ingredientController));
            this.m_Mapper = mapper ?? throw CodeContract.ArgumentNullException(nameof(mapper));
        }

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        [HttpPost]
        [ProducesResponseType(typeof(CreateIngredientViewModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CreateIngredient([FromBody] CreateIngredientCommand command)
            => this.Created(MISSING_GET_LOCATION, await this.m_IngredientController.CreateIngredientAsync(command, CancellationToken.None));

        #endregion Methods

    }

}
