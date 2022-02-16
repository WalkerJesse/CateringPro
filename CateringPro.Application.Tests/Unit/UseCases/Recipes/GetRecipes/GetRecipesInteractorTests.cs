using AutoMapper;
using CateringPro.Application.Services;
using CateringPro.Application.Services.Persistence;
using CateringPro.Application.UseCases.Recipes.GetRecipes;
using CateringPro.Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Recipes.GetRecipes
{

    public class GetRecipesInteractorTests
    {

        #region - - - - - - HandleAsync Tests - - - - - -

        [Fact]
        public async Task HandleAsync_ValidRequest_Successful()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _Request = new GetRecipesInputPort();
            var _Response = new IGetRecipesOutputPort();
            var _RecipeDto = new RecipeDto();
            var _RecipeDtos = new List<RecipeDto>() { _RecipeDto };
            var _Recipe = new Recipe();
            var _Recipes = new List<Recipe>() { _Recipe };

            var _MockMapper = new Mock<IMapper>();
            _MockMapper
                .Setup(mock => mock.Map<List<RecipeDto>>(_Recipes))
                .Returns(_RecipeDtos);
            _MockMapper
                .Setup(mock => mock.Map<IGetRecipesOutputPort>(_RecipeDtos))
                .Returns(_Response);

            var _MockPersistenceContext = new Mock<IPersistenceContext>();
            _MockPersistenceContext
                .Setup(mock => mock.GetEntitiesAsync<Recipe>())
                .Returns(Task.FromResult(
                    new List<Recipe>() { _Recipe }.AsQueryable()));

            var _MockPresenter = new Mock<IPresenter<IGetRecipesOutputPort>>();

            var _Interactor = new GetRecipesInteractor(_MockMapper.Object, _MockPersistenceContext.Object);

            // Act
            await _Interactor.HandleAsync(_Request, _MockPresenter.Object, _CancellationToken);

            // Assert
            _MockMapper.Verify(mock => mock.Map<List<RecipeDto>>(_Recipes), Times.Once);
            _MockMapper.Verify(mock => mock.Map<IGetRecipesOutputPort>(_RecipeDtos), Times.Once);
            _MockPersistenceContext.Verify(mock => mock.GetEntitiesAsync<Recipe>(), Times.Once);
            _MockPresenter.Verify(mock => mock.PresentAsync(_Response, _CancellationToken), Times.Once);
            _MockMapper.VerifyNoOtherCalls();
            _MockPersistenceContext.VerifyNoOtherCalls();
            _MockPresenter.VerifyNoOtherCalls();
        }

        #endregion HandleAsync Tests

    }

}
