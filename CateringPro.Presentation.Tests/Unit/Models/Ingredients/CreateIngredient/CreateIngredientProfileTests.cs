using AutoMapper;
using CateringPro.Presentation.Models.Ingredients.CreateIngredient;
using Xunit;

namespace CateringPro.Presentation.Tests.Unit.Models.Ingredients.CreateIngredient
{

    public class CreateIngredientProfileTests
    {

        #region - - - - - - Profile Configuration Tests - - - - - -

        [Fact]
        public void ErrorMappingProfile_ConfigurationValidation_Successful()
        {
            // Arrange
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile<CreateIngredientProfile>());

            // Act

            // Assert
            configuration.AssertConfigurationIsValid();
        }

        #endregion Profile Configuration Tests

    }

}
