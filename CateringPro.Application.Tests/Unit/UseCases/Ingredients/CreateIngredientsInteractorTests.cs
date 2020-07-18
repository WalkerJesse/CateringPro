using AutoMapper;
using CateringPro.Application.Services.Persistence;
using CateringPro.Application.UseCases.Ingredients.CreateIngredient;
using CateringPro.Domain.Entities;
using FluentAssertions;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Ingredients
{

    public class CreateIngredientsInteractorTests
    {

        #region - - - - - - Handle Tests - - - - - -

        [Fact]
        public async Task Handle_ValidRequest_Successful()
        {
            // Arrange
            var _Request = new CreateIngredientRequest();
            var _CancellationToken = new CancellationToken();
            var _Ingredient = new Ingredient();

            var _MockMapper = new Mock<IMapper>();
            _MockMapper
                .Setup(mock => mock.Map<Ingredient>(_Request))
                .Returns(_Ingredient);

            var _MockPersistenceContext = new Mock<IPersistenceContext>();
            var _Interactor = new CreateIngredientInteractor(_MockMapper.Object, _MockPersistenceContext.Object);

            // Act
            var _Exception = await Record.ExceptionAsync(async () => await _Interactor.Handle(_Request, _CancellationToken));

            // Assert
            _MockMapper.Verify(mock => mock.Map<Ingredient>(_Request), Times.Once);
            _MockPersistenceContext.Verify(mock => mock.AddAsync(_Ingredient, _CancellationToken));
            _MockMapper.Verify(mock => mock.Map<CreateIngredientResponse>(_Ingredient), Times.Once);
            _Exception.Should().BeNull();
        }

        #endregion Handle Tests

    }

}
