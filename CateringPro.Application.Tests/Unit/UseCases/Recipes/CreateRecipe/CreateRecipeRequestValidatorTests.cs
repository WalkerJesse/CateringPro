using CateringPro.Application.Tests.Support;
using CateringPro.Application.UseCases.Recipes.CreateRecipe;
using FluentValidation.TestHelper;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Recipes.CreateRecipe
{

    public class CreateRecipeRequestValidatorTests
    {

        #region - - - - - - CreateRecipeRequestValidator Tests - - - - - -

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(StringConstants.LengthOf_100 + "1")]
        public void Validate_NullOrEmptyOrLongName_ReturnsValidationError(string input)
        {
            new CreateRecipeInputPortValidator().ShouldHaveValidationErrorFor(i => i.Name, input);
        }

        [Theory]
        [InlineData("1")]
        [InlineData(StringConstants.LengthOf_100)]
        public void Validate_Name_PassesValidation(string input)
        {
            new CreateRecipeInputPortValidator().ShouldNotHaveValidationErrorFor(i => i.Name, input);
        }

        #endregion CreateRecipeRequestValidator Tests

    }

}
