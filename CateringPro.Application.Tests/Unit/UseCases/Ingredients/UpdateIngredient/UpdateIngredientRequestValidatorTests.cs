using CateringPro.Application.Tests.Support;
using CateringPro.Application.UseCases.Ingredients.UpdateIngredient;
using CateringPro.Domain.Enumerations;
using FluentValidation.TestHelper;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Ingredients.UpdateIngredient
{

    public class UpdateIngredientRequestValidatorTests
    {

        #region - - - - - - UpdateIngredientRequestValidator Tests - - - - - -

        [Fact]
        public void Validate_NullMeasurementType_ReturnsValidationError()
        {
            new UpdateIngredientRequestValidator().ShouldHaveValidationErrorFor(i => i.MeasurementType, (MeasurementType)null);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(StringConstants.LengthOf_100 + "1")]
        public void Validate_NullOrEmptyOrLongName_ReturnsValidationError(string input)
        {
            new UpdateIngredientRequestValidator().ShouldHaveValidationErrorFor(i => i.Name, input);
        }

        [Theory]
        [InlineData("1")]
        [InlineData(StringConstants.LengthOf_100)]
        public void Validate_Name_PassesValidation(string input)
        {
            new UpdateIngredientRequestValidator().ShouldNotHaveValidationErrorFor(i => i.Name, input);
        }

        #endregion UpdateIngredientRequestValidator Tests

    }

}
