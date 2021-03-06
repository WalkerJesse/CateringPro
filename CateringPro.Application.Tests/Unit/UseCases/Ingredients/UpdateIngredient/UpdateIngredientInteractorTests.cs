using AutoMapper;
using CateringPro.Application.Dtos;
using CateringPro.Application.Services.Persistence;
using CateringPro.Application.UseCases.Ingredients.UpdateIngredient;
using CateringPro.Domain.Entities;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Ingredients.UpdateIngredient
{

    public class UpdateIngredientInteractorTests
    {

        #region - - - - - - Fields - - - - - -

        private readonly Mock<IMapper> m_MockMapper = new();
        private readonly Mock<IUpdateIngredientOutputPort> m_MockOutputPort = new();
        private readonly Mock<IPersistenceContext> m_MockPersistenceContext = new();

        private readonly Ingredient m_Ingredient = new() { ID = 5 };
        private readonly IngredientDto m_IngredientDto = new();
        private readonly UpdateIngredientInputPort m_InputPort = new();
        private readonly UpdateIngredientInteractor m_Interactor;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public UpdateIngredientInteractorTests()
        {
            this.m_InputPort.IngredientID = this.m_Ingredient.ID;

            this.m_Interactor = new(this.m_MockMapper.Object, this.m_MockPersistenceContext.Object);

            this.m_MockPersistenceContext
                .Setup(mock => mock.Find<Ingredient>(It.Is<object[]>(k => Equals(k[0], this.m_Ingredient.ID))))
                .Returns(this.m_Ingredient);

            this.m_MockMapper
                .Setup(mock => mock.Map(this.m_InputPort, this.m_Ingredient))
                .Returns(this.m_Ingredient);

            this.m_MockMapper
                .Setup(mock => mock.Map<IngredientDto>(this.m_Ingredient))
                .Returns(this.m_IngredientDto);
        }

        #endregion Constructors

        #region - - - - - - HandleAsync Tests - - - - - -

        [Fact]
        public async Task HandleAsync_IngredientExists_UpdatesIngredient()
        {
            // Arrange

            // Act
            await this.m_Interactor.HandleAsync(this.m_InputPort, this.m_MockOutputPort.Object, default);

            // Assert
            this.m_MockMapper.Verify(mock => mock.Map(this.m_InputPort, this.m_Ingredient), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_IngredientExists_MapsIngredientToDto()
        {
            // Arrange

            // Act
            await this.m_Interactor.HandleAsync(this.m_InputPort, this.m_MockOutputPort.Object, default);

            // Assert
            this.m_MockMapper.Verify(mock => mock.Map<IngredientDto>(this.m_Ingredient), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_IngredientExists_PresentsIngredientDto()
        {
            // Arrange

            // Act
            await this.m_Interactor.HandleAsync(this.m_InputPort, this.m_MockOutputPort.Object, default);

            // Assert
            this.m_MockOutputPort.Verify(mock => mock.PresentIngredientAsync(this.m_IngredientDto, default), Times.Once);

            this.m_MockOutputPort.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task HandleAsync_IngredientDoesNotExist_PresentsIngredientNotFound()
        {
            // Arrange
            this.m_InputPort.IngredientID = 0;

            // Act
            await this.m_Interactor.HandleAsync(this.m_InputPort, this.m_MockOutputPort.Object, default);

            // Assert
            this.m_MockOutputPort.Verify(mock => mock.PresentIngredientNotFound(this.m_InputPort.IngredientID, default), Times.Once);

            this.m_MockOutputPort.VerifyNoOtherCalls();
        }

        #endregion HandleAsync Tests

    }

}
