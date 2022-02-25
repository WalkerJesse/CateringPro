using AutoMapper;
using CateringPro.Application.Services.Persistence;
using CateringPro.Application.UseCases.Recipes.CreateRecipe;
using CateringPro.Domain.Entities;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Recipes.CreateRecipe
{

    public class CreateRecipeInteractorTests
    {

        #region - - - - - - Fields - - - - - -

        private readonly Mock<IMapper> m_MockMapper = new();
        private readonly Mock<ICreateRecipeOutputPort> m_MockOutputPort = new();
        private readonly Mock<IPersistenceContext> m_MockPersistenceContext = new();

        private readonly CreatedRecipeDto m_CreatedRecipeDto = new();
        private readonly CreateRecipeInputPort m_InputPort = new();
        private readonly CreateRecipeInteractor m_Interactor;
        private readonly Recipe m_Recipe = new();

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public CreateRecipeInteractorTests()
        {
            this.m_Interactor = new(this.m_MockMapper.Object, this.m_MockPersistenceContext.Object);

            this.m_MockMapper
                .Setup(mock => mock.Map<Recipe>(this.m_InputPort))
                .Returns(this.m_Recipe);

            this.m_MockMapper
                .Setup(mock => mock.Map<CreatedRecipeDto>(this.m_Recipe))
                .Returns(this.m_CreatedRecipeDto);
        }

        #endregion Constructors

        #region - - - - - - HandleAsync Tests - - - - - -

        [Fact]
        public async Task HandleAsync_ValidRequest_CreatesRecipe()
        {
            // Arrange

            // Act
            await this.m_Interactor.HandleAsync(this.m_InputPort, this.m_MockOutputPort.Object, default);

            // Assert
            this.m_MockMapper.Verify(mock => mock.Map<Recipe>(this.m_InputPort), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_ValidRequest_AddsRecipeToPersistence()
        {
            // Arrange

            // Act
            await this.m_Interactor.HandleAsync(this.m_InputPort, this.m_MockOutputPort.Object, default);

            // Assert
            this.m_MockPersistenceContext.Verify(mock => mock.Add(this.m_Recipe), Times.Once);

            this.m_MockPersistenceContext.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task HandleAsync_ValidRequest_MapsRecipeToDto()
        {
            // Arrange

            // Act
            await this.m_Interactor.HandleAsync(this.m_InputPort, this.m_MockOutputPort.Object, default);

            // Assert
            this.m_MockMapper.Verify(mock => mock.Map<CreatedRecipeDto>(this.m_Recipe), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_ValidRequest_PresentsCreatedRecipeDto()
        {
            // Arrange

            // Act
            await this.m_Interactor.HandleAsync(this.m_InputPort, this.m_MockOutputPort.Object, default);

            // Assert
            this.m_MockOutputPort.Verify(mock => mock.PresentRecipeAsync(this.m_CreatedRecipeDto, default), Times.Once);

            this.m_MockOutputPort.VerifyNoOtherCalls();
        }

        #endregion HandleAsync Tests

    }

}
