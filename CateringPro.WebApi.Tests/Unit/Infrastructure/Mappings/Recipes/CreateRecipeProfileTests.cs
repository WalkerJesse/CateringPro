using AutoMapper;
using CateringPro.WebApi.Infrastructure.Mappings.Recipes;
using Xunit;

namespace CateringPro.WebApi.Tests.Unit.Infrastructure.Mappings.Recipes
{

    public class CreateRecipeProfileTests
    {

        #region - - - - - - Profile Configuration Tests - - - - - -

        [Fact]
        public void CreateRecipeProfile_ConfigurationValidation_Successful()
            => new MapperConfiguration(cfg => cfg.AddProfile<CreateRecipeProfile>()).AssertConfigurationIsValid();

        #endregion Profile Configuration Tests

    }

}
