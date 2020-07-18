using AutoMapper;
using CateringPro.WebApi.Infrastructure;
using Xunit;

namespace CateringPro.WebApi.Tests.Unit.Infrastructure
{

    public class ErrorMappingProfileTests
    {

        #region - - - - - - Profile Tests - - - - - -

        [Fact]
        public void ErrorMappingProfile_ConfigurationValidation_Successful()
        {
            // Arrange
            var configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile<ErrorMappingProfile>());

            // Act

            // Assert
            configuration.AssertConfigurationIsValid();
        }

        #endregion Profile Tests

    }

}
