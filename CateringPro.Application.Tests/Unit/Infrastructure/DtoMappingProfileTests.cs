using AutoMapper;
using CateringPro.Application.Infrastructure.Mappings;
using Xunit;

namespace CateringPro.Application.Tests.Unit.Infrastructure
{

    public class DtoMappingProfileTests
    {

        #region - - - - - - Profile Configuration Tests - - - - - -

        [Fact]
        public void DtoMappingProfile_ConfigurationValidation_Successful()
            => new MapperConfiguration(cfg => cfg.AddProfile<DtoMappingProfile>()).AssertConfigurationIsValid();

        #endregion Profile Configuration Tests

    }

}
