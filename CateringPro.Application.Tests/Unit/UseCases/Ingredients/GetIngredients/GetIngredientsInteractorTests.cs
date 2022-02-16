using AutoMapper;
using CateringPro.Application.Services;
using CateringPro.Application.Services.Persistence;
using CateringPro.Application.UseCases.Ingredients.GetIngredients;
using CateringPro.Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Ingredients.GetIngredients
{

    public class GetIngredientsInteractorTests
    {

        #region - - - - - - HandleAsync Tests - - - - - -

        [Fact]
        public async Task HandleAsync_ValidRequest_Successful()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _Request = new GetIngredientsRequest();
            var _Response = new IGetIngredientsOutputPort();
            var _IngredientDto = new IngredientDto();
            var _IngredientDtos = new List<IngredientDto>() { _IngredientDto };
            var _Ingredient = new Ingredient();
            var _Ingredients = new List<Ingredient>() { _Ingredient };

            var _MockMapper = new Mock<IMapper>();
            _MockMapper
                .Setup(mock => mock.Map<List<IngredientDto>>(_Ingredients))
                .Returns(_IngredientDtos);
            _MockMapper
                .Setup(mock => mock.Map<IGetIngredientsOutputPort>(_IngredientDtos))
                .Returns(_Response);

            var _MockPersistenceContext = new Mock<IPersistenceContext>();
            _MockPersistenceContext
                .Setup(mock => mock.GetEntitiesAsync<Ingredient>())
                .Returns(Task.FromResult(
                    new List<Ingredient>() { _Ingredient }.AsQueryable()));

            var _MockPresenter = new Mock<IPresenter<IGetIngredientsOutputPort>>();

            var _Interactor = new GetIngredientsInteractor(_MockMapper.Object, _MockPersistenceContext.Object);

            // Act
            await _Interactor.HandleAsync(_Request, _MockPresenter.Object, _CancellationToken);

            // Assert
            _MockMapper.Verify(mock => mock.Map<List<IngredientDto>>(_Ingredients), Times.Once);
            _MockMapper.Verify(mock => mock.Map<IGetIngredientsOutputPort>(_IngredientDtos), Times.Once);
            _MockPersistenceContext.Verify(mock => mock.GetEntitiesAsync<Ingredient>(), Times.Once);
            _MockPresenter.Verify(mock => mock.PresentAsync(_Response, _CancellationToken), Times.Once);
            _MockMapper.VerifyNoOtherCalls();
            _MockPersistenceContext.VerifyNoOtherCalls();
            _MockPresenter.VerifyNoOtherCalls();
        }

        #endregion HandleAsync Tests

    }

}
