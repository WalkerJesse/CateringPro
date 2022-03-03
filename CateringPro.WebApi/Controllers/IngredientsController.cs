using AutoMapper;
using CateringPro.Application.Services.Persistence;
using CateringPro.Application.UseCases.Ingredients.CreateIngredient;
using CateringPro.Application.UseCases.Ingredients.DeleteIngredient;
using CateringPro.Application.UseCases.Ingredients.UpdateIngredient;
using CateringPro.InterfaceAdapters.Controllers;
using CateringPro.WebApi.Presentation.Commands.Ingredients;
using CateringPro.WebApi.Presentation.Presenters.Ingredients;
using CateringPro.WebApi.Presentation.ViewModels.Ingredients;
using CateringPro.WebApi.Services.Attributes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.WebApi.Controllers
{

    public class IngredientsController : BaseController
    {

        #region - - - - - - Fields - - - - - -

        private readonly IngredientController m_IngredientController;
        private readonly IMapper m_Mapper;
        private readonly IPersistenceContext m_PersistenceContext;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public IngredientsController(IngredientController ingredientController, IMapper mapper, IPersistenceContext persistenceContext)
        {
            this.m_IngredientController = ingredientController ?? throw new ArgumentNullException(nameof(ingredientController));
            this.m_Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.m_PersistenceContext = persistenceContext ?? throw new ArgumentNullException(nameof(persistenceContext));
        }

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        [HttpPost]
        [ProducesResponseType(typeof(IngredientViewModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateIngredient([FromBody] CreateIngredientCommand command)
        {
            var _Presenter = new CreateIngredientPresenter(this.m_Mapper);

            await this.m_IngredientController.CreateIngredientAsync(this.m_Mapper.Map<CreateIngredientInputPort>(command), _Presenter, CancellationToken.None);

            if (_Presenter.PresentedSuccessfully)
                await this.m_PersistenceContext.SaveChangesAsync(CancellationToken.None);

            return _Presenter.Result;
        }

        [HttpDelete("{ingredientID:long}")]
        [ProducesResponseType(typeof(List<IngredientViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteIngredient([FromBodyAndRoute] DeleteIngredientCommand command)
        {
            var _Presenter = new DeleteIngredientPresenter(this.m_Mapper);

            await this.m_IngredientController.DeleteIngredientAsync(this.m_Mapper.Map<DeleteIngredientInputPort>(command), _Presenter, CancellationToken.None);

            if (_Presenter.PresentedSuccessfully)
                await this.m_PersistenceContext.SaveChangesAsync(CancellationToken.None);

            return _Presenter.Result;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<IngredientViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetIngredients()
        {
            var _Presenter = new GetIngredientsPresenter(this.m_Mapper);

            await this.m_IngredientController.GetIngredientsAsync(_Presenter, CancellationToken.None);

            return _Presenter.Result;
        }

        [HttpPost("{ingredientID:long}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateIngredient([FromBodyAndRoute] UpdateIngredientCommand command)
        {
            var _Presenter = new UpdateIngredientPresenter(this.m_Mapper);

            await this.m_IngredientController.UpdateIngredientAsync(this.m_Mapper.Map<UpdateIngredientInputPort>(command), _Presenter, CancellationToken.None);

            if (_Presenter.PresentedSuccessfully)
                await this.m_PersistenceContext.SaveChangesAsync(CancellationToken.None);

            return _Presenter.Result;
        }

        #endregion Methods

    }

}
