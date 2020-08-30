using AutoMapper;
using CateringPro.WebApi.Infrastructure.Mappings.Ingredients;
using Xunit;

namespace CateringPro.WebApi.Tests.Unit.Infrastructure.Mappings.Ingredients
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
