using AutoMapper;
using CateringPro.WebApi.Infrastructure.Mappings.Recipes;
using Xunit;

namespace CateringPro.WebApi.Tests.Unit.Infrastructure.Mappings.Recipes
{

    public class RecipeProfileTests
    {

        #region - - - - - - Profile Configuration Tests - - - - - -

        [Fact]
        public void RecipeProfile_ConfigurationValidation_Successful()
            => new MapperConfiguration(cfg => cfg.AddProfile<RecipeProfile>()).AssertConfigurationIsValid();

        #endregion Profile Configuration Tests

    }

}
