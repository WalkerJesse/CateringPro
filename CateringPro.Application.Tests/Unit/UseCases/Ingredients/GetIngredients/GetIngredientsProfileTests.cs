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
            var _Configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile<GetIngredientsProfile>());

            // Act

            // Assert
            _Configuration.AssertConfigurationIsValid();
        }

        #endregion Profile Configuration Tests

    }

}
