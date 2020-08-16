using AutoMapper;
using CateringPro.WebApi.Infrastructure.Mappings.Ingredients;
using Xunit;

namespace CateringPro.WebApi.Tests.Unit.Infrastructure.Mappings.Ingredients
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
