using AutoMapper;
using CateringPro.WebApi.Infrastructure.Mappings;
using Xunit;

namespace CateringPro.WebApi.Tests.Unit.Infrastructure.Mappings
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
