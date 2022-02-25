using CateringPro.Application.Tests.Support;
using CateringPro.Application.UseCases.Ingredients.CreateIngredient;
using FluentValidation.TestHelper;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Ingredients.CreateIngredient
{

    public class CreateIngredientInputPortValidatorTests
    {

        #region - - - - - - CreateIngredientInputPortValidator Tests - - - - - -

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(StringConstants.LengthOf_100 + "1")]
        public void Validate_InvalidName_ReturnsValidationError(string input)
            => new CreateIngredientInputPortValidator().ShouldHaveValidationErrorFor(i => i.Name, input);

        [Theory]
        [InlineData("1")]
        [InlineData(StringConstants.LengthOf_100)]
        public void Validate_ValidName_PassesValidation(string input)
            => new CreateIngredientInputPortValidator().ShouldNotHaveValidationErrorFor(i => i.Name, input);

        #endregion CreateIngredientInputPortValidator Tests

    }

}
