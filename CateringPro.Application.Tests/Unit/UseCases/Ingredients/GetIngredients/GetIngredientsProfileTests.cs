using AutoMapper;
using CateringPro.Application.UseCases.Ingredients.GetIngredients;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Ingredients.GetIngredients
{

    public class GetIngredientsProfileTests
    {

        #region - - - - - - Profile Configuration Tests - - - - - -

        [Fact]
        public void ErrorMappingProfile_ConfigurationValidation_Successful()
        {
            // Arrange
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile<GetIngredientsProfile>());

            // Act

            // Assert
            configuration.AssertConfigurationIsValid();
        }

        #endregion Profile Configuration Tests

    }

}
