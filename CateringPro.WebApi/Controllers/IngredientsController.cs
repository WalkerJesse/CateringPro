﻿using CateringPro.Application.UseCases.Ingredients.CreateIngredient;
using CateringPro.Application.UseCases.Ingredients.GetIngredients;
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
        [ProducesResponseType(typeof(IngredientViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        public Task<IActionResult> CreateIngredient([FromBody] CreateIngredientCommand command)
            => this.m_ControllerAction.CreateAsync<IngredientViewModel, CreateIngredientRequest, CreateIngredientResponse>(command, CancellationToken.None);

        [HttpGet]
        [ProducesResponseType(typeof(IngredientsViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        public Task<IActionResult> GetIngredients([FromBody] GetIngredientsQuery query)
            => this.m_ControllerAction.ReadAsync<IngredientsViewModel, GetIngredientsRequest, GetIngredientsResponse>(query, CancellationToken.None);

        #endregion Methods

    }

}
