using CateringPro.Application.Services;
using CateringPro.Application.Services.Persistence;
using CateringPro.Application.UseCases.Recipes.CreateRecipe;
using CateringPro.Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Recipes.CreateRecipe
{

    public class CreateRecipeBusinessRuleValidatorTests
    {

        #region - - - - - - ValidateAsync Tests - - - - - -

        [Fact]
        public async Task ValidateAsync_IngredientNotFound_PresentNotFoundAsync()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _Ingredient1 = new Ingredient() { ID = 1 };
            var _Ingredient2 = new Ingredient() { ID = 2 };
            var _IngredientObject = new object[] { _Ingredient1.ID };
            var _RecipeIngredientDto1 = new RecipeIngredientDto() { IngredientID = _Ingredient1.ID };
            var _RecipeIngredientDto2 = new RecipeIngredientDto() { IngredientID = _Ingredient2.ID };
            var _Request = new CreateRecipeRequest()
            {
                Ingredients = new List<RecipeIngredientDto>() { _RecipeIngredientDto1, _RecipeIngredientDto2 }
            };

            var _MockPersistenceContext = new Mock<IPersistenceContext>();
            _MockPersistenceContext
                .Setup(mock => mock.FindAsync<Ingredient>(_IngredientObject, _CancellationToken))
                .Returns(Task.FromResult(_Ingredient1));

            var _MockPresenter = new Mock<IPresenter<CreateRecipeResponse>>();
            var _BusinessRuleValidator = new CreateRecipeBusinessRuleValidator(_MockPersistenceContext.Object);

            // Act
            await _BusinessRuleValidator.ValidateAsync(_Request, _MockPresenter.Object, _CancellationToken);

            // Assert
            _MockPersistenceContext.Verify(mock => mock.FindAsync<Ingredient>(It.IsAny<object[]>(), _CancellationToken), Times.Exactly(2));
            _MockPresenter.Verify(mock => mock.PresentNotFoundAsync(It.IsAny<EntityRequest>(), _CancellationToken), Times.Once);
            _MockPersistenceContext.VerifyNoOtherCalls();
            _MockPresenter.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ValidateAsync_NoIngredientsInRequest_DoesNotFail()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _Request = new CreateRecipeRequest();
            var _MockPersistenceContext = new Mock<IPersistenceContext>();
            var _MockPresenter = new Mock<IPresenter<CreateRecipeResponse>>();
            var _BusinessRuleValidator = new CreateRecipeBusinessRuleValidator(_MockPersistenceContext.Object);

            // Act
            await _BusinessRuleValidator.ValidateAsync(_Request, _MockPresenter.Object, _CancellationToken);

            // Assert
            _MockPersistenceContext.VerifyNoOtherCalls();
            _MockPresenter.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ValidateAsync_ValidRequest_Successful()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _Ingredient = new Ingredient() { ID = 1 };
            var _RecipeIngredientDto = new RecipeIngredientDto() { IngredientID = _Ingredient.ID };
            var _Request = new CreateRecipeRequest()
            {
                Ingredients = new List<RecipeIngredientDto>() { _RecipeIngredientDto }
            };

            var _MockPersistenceContext = new Mock<IPersistenceContext>();
            _MockPersistenceContext
                .Setup(mock => mock.FindAsync<Ingredient>(It.IsAny<object[]>(), _CancellationToken))
                .Returns(Task.FromResult(_Ingredient));

            var _MockPresenter = new Mock<IPresenter<CreateRecipeResponse>>();
            var _BusinessRuleValidator = new CreateRecipeBusinessRuleValidator(_MockPersistenceContext.Object);

            // Act
            await _BusinessRuleValidator.ValidateAsync(_Request, _MockPresenter.Object, _CancellationToken);

            // Assert
            _MockPersistenceContext.Verify(mock => mock.FindAsync<Ingredient>(It.IsAny<object[]>(), _CancellationToken), Times.Once);
            _MockPersistenceContext.VerifyNoOtherCalls();
            _MockPresenter.VerifyNoOtherCalls();
        }

        #endregion ValidateAsync Tests

    }

}
