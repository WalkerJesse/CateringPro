using AutoMapper;
using CateringPro.Application.Dtos;
using CateringPro.Application.Services.Persistence;
using CateringPro.Application.UseCases.Ingredients.GetIngredients;
using CateringPro.Domain.Entities;
using FluentAssertions;
using Moq;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Ingredients.GetIngredients
{

    public class GetIngredientsInteractorTests
    {

        #region - - - - - - Fields - - - - - -

        private readonly Mock<IMapper> m_MockMapper = new();
        private readonly Mock<IGetIngredientsOutputPort> m_MockOutputPort = new();
        private readonly Mock<IPersistenceContext> m_MockPersistenceContext = new();

        private IQueryable<IngredientDto> m_Actual;
        private readonly GetIngredientsInputPort m_InputPort = new();
        private readonly GetIngredientsInteractor m_Interactor;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public GetIngredientsInteractorTests()
        {
            this.m_Interactor = new(this.m_MockMapper.Object, this.m_MockPersistenceContext.Object);

            this.m_MockMapper
                .Setup(mock => mock.ConfigurationProvider)
                .Returns(new MapperConfiguration(opts => opts.CreateMap<Ingredient, IngredientDto>()));

            this.m_MockOutputPort
                .Setup(mock => mock.PresentIngredientsAsync(It.IsAny<IQueryable<IngredientDto>>(), default))
                .Callback((IQueryable<IngredientDto> dtos, CancellationToken c) => this.m_Actual = dtos);

            this.m_MockPersistenceContext
                .Setup(mock => mock.GetEntities<Ingredient>())
                .Returns(new[] { new Ingredient() }.AsQueryable());
        }

        #endregion Constructors

        #region - - - - - - HandleAsync Tests - - - - - -

        [Fact]
        public async Task HandleAsync_AnyRequest_PresentsIngredientDtos()
        {
            // Arrange
            var _Expected = new[] { new IngredientDto() };

            // Act
            await this.m_Interactor.HandleAsync(this.m_InputPort, this.m_MockOutputPort.Object, default);

            // Assert
            this.m_Actual.Should().BeEquivalentTo(_Expected);

            this.m_MockOutputPort.Verify(mock => mock.PresentIngredientsAsync(It.IsAny<IQueryable<IngredientDto>>(), default), Times.Once);

            this.m_MockOutputPort.VerifyNoOtherCalls();
        }

        #endregion HandleAsync Tests

    }

}
