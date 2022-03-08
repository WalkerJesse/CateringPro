using AutoMapper;
using CateringPro.Application.Services.Persistence;
using CateringPro.Application.UseCases.Recipes.CreateRecipe;
using CateringPro.InterfaceAdapters.Controllers;
using CateringPro.WebApi.Presentation.Commands.Recipes;
using CateringPro.WebApi.Presentation.Presenters.Recipes;
using CateringPro.WebApi.Presentation.ViewModels.Recipes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace CateringPro.WebApi.Controllers
{

    public class RecipesController : BaseController
    {

        #region - - - - - - Fields - - - - - -

        private readonly RecipeController m_RecipeController;
        private readonly IMapper m_Mapper;
        private readonly IPersistenceContext m_PersistenceContext;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public RecipesController(RecipeController RecipeController, IMapper mapper, IPersistenceContext persistenceContext)
        {
            this.m_RecipeController = RecipeController ?? throw new ArgumentNullException(nameof(RecipeController));
            this.m_Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.m_PersistenceContext = persistenceContext ?? throw new ArgumentNullException(nameof(persistenceContext));
        }

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        [HttpPost]
        [ProducesResponseType(typeof(RecipeViewModel), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ValidationProblemDetails), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateRecipe([FromBody] CreateRecipeCommand command)
        {
            var _Presenter = new CreateRecipePresenter(this.m_Mapper);

            await this.m_RecipeController.CreateRecipeAsync(this.m_Mapper.Map<CreateRecipeInputPort>(command), _Presenter, CancellationToken.None);

            if (_Presenter.PresentedSuccessfully)
                await this.m_PersistenceContext.SaveChangesAsync(CancellationToken.None);

            return _Presenter.Result;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<RecipeViewModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetRecipes()
        {
            var _Presenter = new GetRecipesPresenter(this.m_Mapper);

            await this.m_RecipeController.GetRecipesAsync(_Presenter, CancellationToken.None);

            return _Presenter.Result;
        }

        #endregion Methods

    }

}
