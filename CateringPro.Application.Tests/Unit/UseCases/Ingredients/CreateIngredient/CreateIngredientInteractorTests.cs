using AutoMapper;
using CateringPro.Application.Services.Persistence;
using CateringPro.Application.UseCases.Ingredients.CreateIngredient;
using CateringPro.Domain.Entities;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Ingredients.CreateIngredient
{

    public class CreateIngredientInteractorTests
    {

        #region - - - - - - Fields - - - - - -

        private readonly Mock<IMapper> m_MockMapper = new();
        private readonly Mock<ICreateIngredientOutputPort> m_MockOutputPort = new();
        private readonly Mock<IPersistenceContext> m_MockPersistenceContext = new();

        private readonly CreatedIngredientDto m_CreatedIngredientDto = new();
        private readonly Ingredient m_Ingredient = new();
        private readonly CreateIngredientInputPort m_InputPort = new();
        private readonly CreateIngredientInteractor m_Interactor;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public CreateIngredientInteractorTests()
        {
            this.m_Interactor = new(this.m_MockMapper.Object, this.m_MockPersistenceContext.Object);

            this.m_MockMapper
                .Setup(mock => mock.Map<Ingredient>(this.m_InputPort))
                .Returns(this.m_Ingredient);

            this.m_MockMapper
                .Setup(mock => mock.Map<CreatedIngredientDto>(this.m_Ingredient))
                .Returns(this.m_CreatedIngredientDto);
        }

        #endregion Constructors

        #region - - - - - - HandleAsync Tests - - - - - -

        [Fact]
        public async Task HandleAsync_ValidRequest_CreatesIngredient()
        {
            // Arrange

            // Act
            await this.m_Interactor.HandleAsync(this.m_InputPort, this.m_MockOutputPort.Object, default);

            // Assert
            this.m_MockMapper.Verify(mock => mock.Map<Ingredient>(this.m_InputPort), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_ValidRequest_AddsIngredientToPersistence()
        {
            // Arrange

            // Act
            await this.m_Interactor.HandleAsync(this.m_InputPort, this.m_MockOutputPort.Object, default);

            // Assert
            this.m_MockPersistenceContext.Verify(mock => mock.Add(this.m_Ingredient), Times.Once);

            this.m_MockPersistenceContext.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task HandleAsync_ValidRequest_MapsIngredientToDto()
        {
            // Arrange

            // Act
            await this.m_Interactor.HandleAsync(this.m_InputPort, this.m_MockOutputPort.Object, default);

            // Assert
            this.m_MockMapper.Verify(mock => mock.Map<CreatedIngredientDto>(this.m_Ingredient), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_ValidRequest_PresentsCreatedIngredientDto()
        {
            // Arrange

            // Act
            await this.m_Interactor.HandleAsync(this.m_InputPort, this.m_MockOutputPort.Object, default);

            // Assert
            this.m_MockOutputPort.Verify(mock => mock.PresentIngredientAsync(this.m_CreatedIngredientDto, default), Times.Once);

            this.m_MockOutputPort.VerifyNoOtherCalls();
        }

        #endregion HandleAsync Tests

    }

}
