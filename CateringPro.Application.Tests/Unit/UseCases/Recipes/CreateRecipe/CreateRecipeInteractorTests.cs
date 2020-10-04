using AutoMapper;
using CateringPro.Application.Services;
using CateringPro.Application.Services.Persistence;
using CateringPro.Application.UseCases.Recipes.CreateRecipe;
using CateringPro.Domain.Entities;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Recipes.CreateRecipe
{

    public class CreateRecipeInteractorTests
    {

        #region - - - - - - HandleAsync Tests - - - - - -

        [Fact]
        public async Task HandleAsync_ValidRequest_Successful()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _Request = new CreateRecipeRequest();
            var _Response = new CreateRecipeResponse();
            var _Recipe = new Recipe();

            var _MockMapper = new Mock<IMapper>();
            _MockMapper
                .Setup(mock => mock.Map<Recipe>(_Request))
                .Returns(_Recipe);
            _MockMapper
                .Setup(mock => mock.Map<CreateRecipeResponse>(_Recipe))
                .Returns(_Response);

            var _MockPersistenceContext = new Mock<IPersistenceContext>();
            var _MockPresenter = new Mock<IPresenter<CreateRecipeResponse>>();

            var _Interactor = new CreateRecipeInteractor(_MockMapper.Object, _MockPersistenceContext.Object);

            // Act
            await _Interactor.HandleAsync(_Request, _MockPresenter.Object, _CancellationToken);

            // Assert
            _MockMapper.Verify(mock => mock.Map<Recipe>(_Request), Times.Once);
            _MockMapper.Verify(mock => mock.Map<CreateRecipeResponse>(_Recipe), Times.Once);
            _MockPersistenceContext.Verify(mock => mock.AddAsync(_Recipe, _CancellationToken), Times.Once);
            _MockPresenter.Verify(mock => mock.PresentAsync(_Response, _CancellationToken), Times.Once);
            _MockMapper.VerifyNoOtherCalls();
            _MockPersistenceContext.VerifyNoOtherCalls();
            _MockPresenter.VerifyNoOtherCalls();
        }

        #endregion HandleAsync Tests

    }

}
