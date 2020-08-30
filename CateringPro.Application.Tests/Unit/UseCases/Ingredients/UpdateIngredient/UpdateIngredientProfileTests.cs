using AutoMapper;
using CateringPro.Application.UseCases.Ingredients.UpdateIngredient;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Ingredients.UpdateIngredient
{

    public class UpdateIngredientProfileTests
    {

        #region - - - - - - Profile Configuration Tests - - - - - -

        [Fact]
        public void ErrorMappingProfile_ConfigurationValidation_Successful()
        {
            // Arrange
            var _Configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile<UpdateIngredientProfile>());

            // Act

            // Assert
            _Configuration.AssertConfigurationIsValid();
        }

        #endregion Profile Configuration Tests

    }

}
