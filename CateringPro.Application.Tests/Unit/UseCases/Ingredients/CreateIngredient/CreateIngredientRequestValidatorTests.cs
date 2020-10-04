using CateringPro.Application.Tests.Support;
using CateringPro.Application.UseCases.Ingredients.CreateIngredient;
using FluentValidation.TestHelper;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Ingredients.CreateIngredient
{

    public class CreateIngredientRequestValidatorTests
    {

        #region - - - - - - CreateIngredientRequestValidator Tests - - - - - -

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(StringConstants.LengthOf_100 + "1")]
        public void Validate_NullOrEmptyOrLongName_ReturnsValidationError(string input)
        {
            new CreateIngredientRequestValidator().ShouldHaveValidationErrorFor(i => i.Name, input);
        }

        [Theory]
        [InlineData("1")]
        [InlineData(StringConstants.LengthOf_100)]
        public void Validate_Name_PassesValidation(string input)
        {
            new CreateIngredientRequestValidator().ShouldNotHaveValidationErrorFor(i => i.Name, input);
        }

        #endregion CreateIngredientRequestValidator Tests

    }

}
