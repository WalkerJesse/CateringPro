using AutoMapper;
using CateringPro.Application.Services;
using CateringPro.Application.Services.Persistence;
using CateringPro.Application.UseCases.Ingredients.GetIngredients;
using CateringPro.Domain.Entities;
using Moq;
using System.Collections.Generic;
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
            var _Response = new GetIngredientsResponse();
            var _IngredientDtos = new List<IngredientDto>();
            var _Ingredients = new List<Ingredient>();

            var _MockConfigurationProvider = new Mock<IConfigurationProvider>();

            var _MockMapper = new Mock<IMapper>();
            _MockMapper
                .Setup(mock => mock.ConfigurationProvider)
                .Returns(_MockConfigurationProvider.Object);
            _MockMapper
                .Setup(mock => mock.Map<GetIngredientsResponse>(_IngredientDtos))
                .Returns(_Response);

            var _MockIngredientDtos = new Mock<IEntities<IngredientDto>>();
            _MockIngredientDtos
                .Setup(mock => mock.ToList())
                .Returns(_IngredientDtos);

            var _MockIngredients = new Mock<IEntities<Ingredient>>();
            _MockIngredients
                .Setup(mock => mock.ProjectTo<IngredientDto>(_MockConfigurationProvider.Object))
                .Returns(_MockIngredientDtos.Object);

            var _MockPersistenceContext = new Mock<IPersistenceContext>();
            _MockPersistenceContext
                .Setup(mock => mock.GetEntities<Ingredient>())
                .Returns(_MockIngredients.Object);

            var _MockPresenter = new Mock<IPresenter<GetIngredientsResponse>>();

            var _Interactor = new GetIngredientsInteractor(_MockMapper.Object, _MockPersistenceContext.Object);

            // Act
            await _Interactor.HandleAsync(_Request, _MockPresenter.Object, _CancellationToken);

            // Assert
            _MockMapper.Verify(mock => mock.Map<GetIngredientsResponse>(_IngredientDtos), Times.Once);
            _MockMapper.Verify(Mock => Mock.ConfigurationProvider, Times.Once);
            _MockPersistenceContext.Verify(mock => mock.GetEntities<Ingredient>(), Times.Once);
            _MockPresenter.Verify(mock => mock.PresentAsync(_Response, _CancellationToken), Times.Once);
            _MockIngredientDtos.Verify(mock => mock.ToList(), Times.Once);
            _MockIngredients.Verify(mock => mock.ProjectTo<IngredientDto>(_MockConfigurationProvider.Object), Times.Once);
            _MockMapper.VerifyNoOtherCalls();
            _MockPersistenceContext.VerifyNoOtherCalls();
            _MockPresenter.VerifyNoOtherCalls();
            _MockIngredientDtos.VerifyNoOtherCalls();
            _MockIngredients.VerifyNoOtherCalls();
        }

        #endregion HandleAsync Tests

    }

}
