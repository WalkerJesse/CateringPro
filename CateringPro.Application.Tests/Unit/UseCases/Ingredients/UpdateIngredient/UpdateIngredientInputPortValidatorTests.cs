using CateringPro.Application.Tests.Support;
using CateringPro.Application.UseCases.Ingredients.UpdateIngredient;
using FluentValidation.TestHelper;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Ingredients.UpdateIngredient
{

    public class UpdateIngredientInputPortValidatorTests
    {

        #region - - - - - - UpdateIngredientInputPortValidator Tests - - - - - -

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(StringConstants.LengthOf_100 + "1")]
        public void Validate_InvalidName_ReturnsValidationError(string input)
            => new UpdateIngredientInputPortValidator().ShouldHaveValidationErrorFor(i => i.Name, input);

        [Theory]
        [InlineData("1")]
        [InlineData(StringConstants.LengthOf_100)]
        public void Validate_ValidName_PassesValidation(string input)
            => new UpdateIngredientInputPortValidator().ShouldNotHaveValidationErrorFor(i => i.Name, input);

        #endregion UpdateIngredientInputPortValidator Tests

    }

}
