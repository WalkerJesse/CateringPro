using AutoMapper;
using CateringPro.Application.Services;
using CateringPro.Application.Services.Persistence;
using CateringPro.Application.UseCases.Ingredients.DeleteIngredient;
using CateringPro.Domain.Entities;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Ingredients.DeleteIngredient
{

    public class DeleteIngredientInteractorTests
    {

        #region - - - - - - HandleAsync Tests - - - - - -

        [Fact]
        public async Task HandleAsync_IngredientDoesNotExist_PresentsNotFoundResponse()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _Request = new DeleteIngredientRequest() { ID = 1 };
            var _Response = new DeleteIngredientResponse();

            var _MockMapper = new Mock<IMapper>();
            var _MockPersistenceContext = new Mock<IPersistenceContext>();
            _MockPersistenceContext
                .Setup(mock => mock.FindAsync<Ingredient>(new object[] { _Request.ID }, CancellationToken.None))
                .Returns(Task.FromResult((Ingredient)null));

            var _MockPresenter = new Mock<IPresenter<DeleteIngredientResponse>>();

            var _IngredientsInteractor = new DeleteIngredientInteractor(_MockMapper.Object, _MockPersistenceContext.Object);

            // Act
            await _IngredientsInteractor.HandleAsync(_Request, _MockPresenter.Object, _CancellationToken);

            // Assert
            _MockPersistenceContext.Verify(mock => mock.FindAsync<Ingredient>(new object[] { _Request.ID }, CancellationToken.None), Times.Once);
            _MockPresenter.Verify(mock => mock.PresentNotFoundAsync(It.IsAny<EntityRequest>(), _CancellationToken), Times.Once);
            _MockMapper.VerifyNoOtherCalls();
            _MockPersistenceContext.VerifyNoOtherCalls();
            _MockPresenter.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task HandleAsync_ValidRequest_PresentsSuccessResponse()
        {
            // Arrange
            var _Ingredient = new Ingredient() { ID = 1 };
            var _CancellationToken = new CancellationToken();
            var _Request = new DeleteIngredientRequest() { ID = _Ingredient.ID };
            var _Response = new DeleteIngredientResponse();


            var _MockMapper = new Mock<IMapper>();
            _MockMapper
                .Setup(mock => mock.Map(_Request, _Ingredient))
                .Returns(_Ingredient);
            _MockMapper
                .Setup(mock => mock.Map<DeleteIngredientResponse>(_Ingredient))
                .Returns(_Response); ;

            var _MockPersistenceContext = new Mock<IPersistenceContext>();
            _MockPersistenceContext
                .Setup(mock => mock.FindAsync<Ingredient>(new object[] { _Request.ID }, CancellationToken.None))
                .Returns(Task.FromResult(_Ingredient));
            _MockPersistenceContext
                .Setup(mock => mock.RemoveAsync(_Ingredient))
                .Returns(Task.FromResult(_Ingredient));

            var _MockPresenter = new Mock<IPresenter<DeleteIngredientResponse>>();

            var _IngredientsInteractor = new DeleteIngredientInteractor(_MockMapper.Object, _MockPersistenceContext.Object);

            // Act
            await _IngredientsInteractor.HandleAsync(_Request, _MockPresenter.Object, _CancellationToken);

            // Assert
            _MockMapper.Verify(mock => mock.Map<DeleteIngredientResponse>(_Ingredient), Times.Once);
            _MockPersistenceContext.Verify(mock => mock.FindAsync<Ingredient>(new object[] { _Request.ID }, CancellationToken.None), Times.Once);
            _MockPersistenceContext.Verify(mock => mock.RemoveAsync(_Ingredient), Times.Once);
            _MockPresenter.Verify(mock => mock.PresentAsync(_Response, _CancellationToken), Times.Once);
            _MockMapper.VerifyNoOtherCalls();
            _MockPersistenceContext.VerifyNoOtherCalls();
            _MockPresenter.VerifyNoOtherCalls();
        }

        #endregion HandleAsync Tests

    }

}
