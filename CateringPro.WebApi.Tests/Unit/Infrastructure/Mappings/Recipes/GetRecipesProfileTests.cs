using AutoMapper;
using CateringPro.WebApi.Infrastructure.Mappings.Recipes;
using Xunit;

namespace CateringPro.WebApi.Tests.Unit.Infrastructure.Mappings.Recipes
{

    public class GetRecipesProfileTests
    {

        #region - - - - - - Profile Configuration Tests - - - - - -

        [Fact]
        public void GetRecipesProfile_ConfigurationValidation_Successful()
            => new MapperConfiguration(cfg => cfg.AddProfile<GetRecipesProfile>()).AssertConfigurationIsValid();

        #endregion Profile Configuration Tests
    }

}
