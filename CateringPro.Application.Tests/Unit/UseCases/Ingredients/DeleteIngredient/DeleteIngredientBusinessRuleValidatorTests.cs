using CateringPro.Application.Services.Persistence;
using CateringPro.Application.UseCases.Ingredients.DeleteIngredient;
using CateringPro.Domain.Entities;
using FluentAssertions;
using FluentValidation.Results;
using Moq;
using System.Linq;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Ingredients.DeleteIngredient
{

    public class DeleteIngredientBusinessRuleValidatorTests
    {

        #region - - - - - - Fields - - - - - -

        private readonly Mock<IPersistenceContext> m_MockPersistenceContext = new();

        private readonly DeleteIngredientInputPort m_InputPort = new();
        private readonly Ingredient m_Ingredient = new() { ID = 5 };
        private DeleteIngredientBusinessRuleValidator m_Validator;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public DeleteIngredientBusinessRuleValidatorTests()
        {
            this.m_Validator = new(this.m_MockPersistenceContext.Object);

            this.m_MockPersistenceContext
                .Setup(mock => mock.GetEntities<RecipeIngredient>())
                .Returns(new RecipeIngredient[] { new RecipeIngredient() { Ingredient = m_Ingredient } }.AsQueryable());
        }

        #endregion Constructors

        #region - - - - - - ValidateAsync Tests - - - - - -

        [Fact]
        public async void ValidateAsync_IngredientNotBeingUsed_ReturnsSuccess()
        {
            // Arrange
            var _Expected = new ValidationResult();

            // Act
            var _Actual = await this.m_Validator.ValidateAsync(this.m_InputPort, default);

            // Assert
            _Actual.Should().BeEquivalentTo(_Expected);
        }

        [Fact]
        public async void ValidateAsync_IngredientIsBeingUsed_ReturnsValidationFailure()
        {
            // Arrange
            this.m_InputPort.IngredientID = this.m_Ingredient.ID;

            var _Expected = new ValidationResult(new[] { new ValidationFailure(string.Empty, "You cannot delete an Ingredient that is being used by a recipe.") });

            // Act
            var _Actual = await this.m_Validator.ValidateAsync(this.m_InputPort, default);

            // Assert
            _Actual.Should().BeEquivalentTo(_Expected);
        }

        #endregion ValidateAsync Tests

    }

}
