using CateringPro.Application.Services.Persistence;
using CateringPro.Application.UseCases.Ingredients.DeleteIngredient;
using CateringPro.Domain.Entities;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Ingredients.DeleteIngredient
{

    public class DeleteIngredientInteractorTests
    {

        #region - - - - - - Fields - - - - - -

        private readonly Mock<IDeleteIngredientOutputPort> m_MockOutputPort = new();
        private readonly Mock<IPersistenceContext> m_MockPersistenceContext = new();

        private readonly Ingredient m_Ingredient = new() { ID = 5 };
        private readonly DeleteIngredientInputPort m_InputPort = new();
        private readonly DeleteIngredientInteractor m_Interactor;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public DeleteIngredientInteractorTests()
        {
            this.m_InputPort.IngredientID = this.m_Ingredient.ID;

            this.m_Interactor = new(this.m_MockPersistenceContext.Object);

            this.m_MockPersistenceContext
                .Setup(mock => mock.Find<Ingredient>(It.Is<object[]>(k => Equals(k[0], this.m_Ingredient.ID))))
                .Returns(this.m_Ingredient);
        }

        #endregion Constructors

        #region - - - - - - HandleAsync Tests - - - - - -

        [Fact]
        public async Task HandleAsync_IngredientExists_RemovesIngredientFromPersistence()
        {
            // Arrange

            // Act
            await this.m_Interactor.HandleAsync(this.m_InputPort, this.m_MockOutputPort.Object, default);

            // Assert
            this.m_MockPersistenceContext.Verify(mock => mock.Remove(this.m_Ingredient), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_IngredientExists_PresentsDeletedIngredientID()
        {
            // Arrange

            // Act
            await this.m_Interactor.HandleAsync(this.m_InputPort, this.m_MockOutputPort.Object, default);

            // Assert
            this.m_MockOutputPort.Verify(mock => mock.PresentDeletedIngredientAsync(this.m_InputPort.IngredientID, default), Times.Once);

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
