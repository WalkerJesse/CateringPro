using CateringPro.Application.UseCases.Recipes.CreateRecipe;
using CateringPro.Application.UseCases.Recipes.DeleteRecipe;
using CateringPro.Application.UseCases.Recipes.GetRecipes;
using CateringPro.InterfaceAdapters.Controllers;
using CleanArchitecture.Mediator;
using Moq;
using Xunit;

namespace CateringPro.InterfaceAdapters.Tests.Controllers
{

    public class RecipeControllerTests
    {

        #region - - - - - - Fields - - - - - -

        private readonly Mock<IUseCaseInvoker> m_MockUseCaseInvoker = new();

        private readonly RecipeController m_Controller;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public RecipeControllerTests()
            => this.m_Controller = new(this.m_MockUseCaseInvoker.Object);

        #endregion Constructors

        #region - - - - - - CreateRecipeAsync Tests - - - - - -

        [Fact]
        public void CreateRecipeAsync_ValidInputPort_InvokesUseCaseWithInputPortAndOutPutPort()
        {
            // Arrange
            var _InputPort = new CreateRecipeInputPort();
            var _OutputPort = new Mock<ICreateRecipeOutputPort>().Object;

            // Act
            this.m_Controller.CreateRecipeAsync(_InputPort, _OutputPort, default);

            // Assert
            this.m_MockUseCaseInvoker.Verify(mock => mock.InvokeUseCaseAsync(_InputPort, _OutputPort, default));
        }

        #endregion CreateRecipeAsync Tests

        #region - - - - - - DeleteRecipeAsync Tests - - - - - -

        [Fact]
        public void DeleteRecipeAsync_ValidInputPort_InvokesUseCaseWithInputPortAndOutPutPort()
        {
            // Arrange
            var _InputPort = new DeleteRecipeInputPort();
            var _OutputPort = new Mock<IDeleteRecipeOutputPort>().Object;

            // Act
            this.m_Controller.DeleteRecipeAsync(_InputPort, _OutputPort, default);

            // Assert
            this.m_MockUseCaseInvoker.Verify(mock => mock.InvokeUseCaseAsync(_InputPort, _OutputPort, default));
        }

        #endregion DeleteRecipeAsync Tests

        #region - - - - - - GetRecipesAsync Tests - - - - - -

        [Fact]
        public void GetRecipesAsync_ValidInputPort_InvokesUseCaseWithInputPortAndOutPutPort()
        {
            // Arrange

            var _OutputPort = new Mock<IGetRecipesOutputPort>().Object;

            // Act
            this.m_Controller.GetRecipesAsync(_OutputPort, default);

            // Assert
            this.m_MockUseCaseInvoker.Verify(mock => mock.InvokeUseCaseAsync(It.IsAny<GetRecipesInputPort>(), _OutputPort, default));
        }

        #endregion GetRecipesAsync Tests

    }

}
