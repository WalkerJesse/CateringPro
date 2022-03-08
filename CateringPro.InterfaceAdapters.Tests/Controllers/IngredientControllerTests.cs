using CateringPro.Application.UseCases.Ingredients.CreateIngredient;
using CateringPro.Application.UseCases.Ingredients.DeleteIngredient;
using CateringPro.Application.UseCases.Ingredients.GetIngredients;
using CateringPro.Application.UseCases.Ingredients.UpdateIngredient;
using CateringPro.InterfaceAdapters.Controllers;
using CleanArchitecture.Mediator;
using Moq;
using Xunit;

namespace CateringPro.InterfaceAdapters.Tests.Controllers
{

    public class IngredientControllerTests
    {

        #region - - - - - - Fields - - - - - -

        private readonly Mock<IUseCaseInvoker> m_MockUseCaseInvoker = new();

        private readonly IngredientController m_Controller;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public IngredientControllerTests()
            => this.m_Controller = new(this.m_MockUseCaseInvoker.Object);

        #endregion Constructors

        #region - - - - - - CreateIngredientAsync Tests - - - - - -

        [Fact]
        public void CreateIngredientAsync_ValidInputPort_InvokesUseCaseWithInputPortAndOutPutPort()
        {
            // Arrange
            var _InputPort = new CreateIngredientInputPort();
            var _OutputPort = new Mock<ICreateIngredientOutputPort>().Object;

            // Act
            this.m_Controller.CreateIngredientAsync(_InputPort, _OutputPort, default);

            // Assert
            this.m_MockUseCaseInvoker.Verify(mock => mock.InvokeUseCaseAsync(_InputPort, _OutputPort, default));
        }

        #endregion CreateIngredientAsync Tests

        #region - - - - - - DeleteIngredientAsync Tests - - - - - -

        [Fact]
        public void DeleteIngredientAsync_ValidInputPort_InvokesUseCaseWithInputPortAndOutPutPort()
        {
            // Arrange
            var _InputPort = new DeleteIngredientInputPort();
            var _OutputPort = new Mock<IDeleteIngredientOutputPort>().Object;

            // Act
            this.m_Controller.DeleteIngredientAsync(_InputPort, _OutputPort, default);

            // Assert
            this.m_MockUseCaseInvoker.Verify(mock => mock.InvokeUseCaseAsync(_InputPort, _OutputPort, default));
        }

        #endregion DeleteIngredientAsync Tests

        #region - - - - - - GetIngredientsAsync Tests - - - - - -

        [Fact]
        public void GetIngredientsAsync_ValidInputPort_InvokesUseCaseWithInputPortAndOutPutPort()
        {
            // Arrange

            var _OutputPort = new Mock<IGetIngredientsOutputPort>().Object;

            // Act
            this.m_Controller.GetIngredientsAsync(_OutputPort, default);

            // Assert
            this.m_MockUseCaseInvoker.Verify(mock => mock.InvokeUseCaseAsync(It.IsAny<GetIngredientsInputPort>(), _OutputPort, default));
        }

        #endregion GetIngredientsAsync Tests

        #region - - - - - - UpdateIngredientAsync Tests - - - - - -

        [Fact]
        public void UpdateIngredientAsync_ValidInputPort_InvokesUseCaseWithInputPortAndOutPutPort()
        {
            // Arrange
            var _InputPort = new UpdateIngredientInputPort();
            var _OutputPort = new Mock<IUpdateIngredientOutputPort>().Object;

            // Act
            this.m_Controller.UpdateIngredientAsync(_InputPort, _OutputPort, default);

            // Assert
            this.m_MockUseCaseInvoker.Verify(mock => mock.InvokeUseCaseAsync(_InputPort, _OutputPort, default));
        }

        #endregion UpdateIngredientAsync Tests

    }

}
