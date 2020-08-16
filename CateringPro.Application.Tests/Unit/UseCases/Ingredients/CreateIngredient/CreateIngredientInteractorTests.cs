using AutoMapper;
using CateringPro.Application.Services;
using CateringPro.Application.Services.Persistence;
using CateringPro.Application.UseCases.Ingredients.CreateIngredient;
using CateringPro.Domain.Entities;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Ingredients.CreateIngredient
{

    public class CreateIngredientInteractorTests
    {

        #region - - - - - - HandleAsync Tests - - - - - -

        [Fact]
        public async Task HandleAsync_ValidRequest_Successful()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _Request = new CreateIngredientRequest();
            var _Response = new CreateIngredientResponse();
            var _Ingredient = new Ingredient() { Name = "Ingredient" };

            var _MockMapper = new Mock<IMapper>();
            _MockMapper
                .Setup(mock => mock.Map<Ingredient>(_Request))
                .Returns(_Ingredient);
            _MockMapper
                .Setup(mock => mock.Map<CreateIngredientResponse>(_Ingredient))
                .Returns(_Response);

            var _MockPersistenceContext = new Mock<IPersistenceContext>();
            var _MockPresenter = new Mock<IPresenter<CreateIngredientResponse>>();

            var _Interactor = new CreateIngredientInteractor(_MockMapper.Object, _MockPersistenceContext.Object);

            // Act
            await _Interactor.HandleAsync(_Request, _MockPresenter.Object, _CancellationToken);

            // Assert
            _MockMapper.Verify(mock => mock.Map<Ingredient>(_Request), Times.Once);
            _MockMapper.Verify(mock => mock.Map<CreateIngredientResponse>(_Ingredient), Times.Once);
            _MockPersistenceContext.Verify(mock => mock.AddAsync(_Ingredient, _CancellationToken), Times.Once);
            _MockPresenter.Verify(mock => mock.PresentAsync(_Response, _CancellationToken), Times.Once);
            _MockMapper.VerifyNoOtherCalls();
            _MockPersistenceContext.VerifyNoOtherCalls();
            _MockPresenter.VerifyNoOtherCalls();
        }

        #endregion HandleAsync Tests

    }

}
