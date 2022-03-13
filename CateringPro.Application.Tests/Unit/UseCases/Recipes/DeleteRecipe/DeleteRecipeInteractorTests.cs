using AutoMapper;
using CateringPro.Application.Dtos;
using CateringPro.Application.Services.Persistence;
using CateringPro.Application.UseCases.Recipes.DeleteRecipe;
using CateringPro.Domain.Entities;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Recipes.DeleteRecipe
{

    public class DeleteRecipeInteractorTests
    {

        #region - - - - - - Fields - - - - - -

        private readonly Mock<IMapper> m_MockMapper = new();
        private readonly Mock<IDeleteRecipeOutputPort> m_MockOutputPort = new();
        private readonly Mock<IPersistenceContext> m_MockPersistenceContext = new();

        private readonly DeleteRecipeInputPort m_InputPort = new();
        private readonly DeleteRecipeInteractor m_Interactor;
        private readonly Recipe m_Recipe = new() { ID = 5 };
        private readonly RecipeDto m_RecipeDto = new();

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public DeleteRecipeInteractorTests()
        {
            this.m_InputPort.RecipeID = this.m_Recipe.ID;

            this.m_Interactor = new(this.m_MockMapper.Object, this.m_MockPersistenceContext.Object);

            this.m_MockMapper
                .Setup(mock => mock.Map<RecipeDto>(this.m_Recipe))
                .Returns(this.m_RecipeDto);

            this.m_MockPersistenceContext
                .Setup(mock => mock.Find<Recipe>(It.Is<object[]>(k => Equals(k[0], this.m_Recipe.ID))))
                .Returns(this.m_Recipe);
        }

        #endregion Constructors

        #region - - - - - - HandleAsync Tests - - - - - -

        [Fact]
        public async Task HandleAsync_RecipeExists_RemovesRecipeFromPersistence()
        {
            // Arrange

            // Act
            await this.m_Interactor.HandleAsync(this.m_InputPort, this.m_MockOutputPort.Object, default);

            // Assert
            this.m_MockPersistenceContext.Verify(mock => mock.Remove(this.m_Recipe), Times.Once);
        }

        [Fact]
        public async Task HandleAsync_RecipeExists_PresentsDeletedRecipe()
        {
            // Arrange

            // Act
            await this.m_Interactor.HandleAsync(this.m_InputPort, this.m_MockOutputPort.Object, default);

            // Assert
            this.m_MockOutputPort.Verify(mock => mock.PresentDeletedRecipeAsync(this.m_RecipeDto, default), Times.Once);

            this.m_MockOutputPort.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task HandleAsync_RecipeDoesNotExist_PresentsRecipeNotFound()
        {
            // Arrange
            this.m_InputPort.RecipeID = 0;

            // Act
            await this.m_Interactor.HandleAsync(this.m_InputPort, this.m_MockOutputPort.Object, default);

            // Assert
            this.m_MockOutputPort.Verify(mock => mock.PresentRecipeNotFound(this.m_InputPort.RecipeID, default), Times.Once);

            this.m_MockOutputPort.VerifyNoOtherCalls();
        }

        #endregion HandleAsync Tests

    }

}
