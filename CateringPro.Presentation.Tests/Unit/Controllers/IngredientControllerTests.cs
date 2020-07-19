using AutoMapper;
using CateringPro.Application.Services.Persistence;
using CateringPro.Application.UseCases.Ingredients.CreateIngredient;
using CateringPro.Presentation.Controllers;
using CateringPro.Presentation.Models.Ingredients.CreateIngredient;
using FluentAssertions;
using MediatR;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CateringPro.Presentation.Tests.Unit.Controllers
{

    public class IngredientControllerTests
    {

        #region - - - - - - CreateIngredientAsync Tests - - - - - -

        [Fact]
        public async Task Handle_ValidRequest_Successful()
        {
            // Arrange
            var _Command = new CreateIngredientCommand();
            var _Request = new CreateIngredientRequest();
            var _Response = new CreateIngredientResponse();
            var _ViewModel = new CreateIngredientViewModel();
            var _CancellationToken = new CancellationToken();

            var _MockMapper = new Mock<IMapper>();
            _MockMapper
                .Setup(mock => mock.Map<CreateIngredientRequest>(_Command))
                .Returns(_Request);
            _MockMapper
                .Setup(mock => mock.Map<CreateIngredientViewModel>(_Response))
                .Returns(_ViewModel);

            var _MockMediator = new Mock<IMediator>();
            _MockMediator
                .Setup(mock => mock.Send(_Request, _CancellationToken))
                .Returns(Task.FromResult(_Response));

            var _MockPersistenceContext = new Mock<IPersistenceContext>();
            var _Controller = new IngredientController(_MockMapper.Object, _MockMediator.Object, _MockPersistenceContext.Object);

            // Act
            var _Exception = await Record.ExceptionAsync(async () => await _Controller.CreateIngredientAsync(_Command, _CancellationToken));

            // Assert
            _MockMapper.Verify(mock => mock.Map<CreateIngredientRequest>(_Command), Times.Once);
            _MockMediator.Verify(mock => mock.Send(_Request, _CancellationToken), Times.Once);
            _MockPersistenceContext.Verify(mock => mock.SaveChangesAsync(_CancellationToken), Times.Once);
            _MockMapper.Verify(mock => mock.Map<CreateIngredientViewModel>(_Response), Times.Once);
            _Exception.Should().BeNull();
        }

        #endregion CreateIngredientAsync Tests

    }

}
