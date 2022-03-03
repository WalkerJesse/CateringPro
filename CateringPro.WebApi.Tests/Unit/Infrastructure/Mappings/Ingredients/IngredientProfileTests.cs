using AutoMapper;
using CateringPro.WebApi.Infrastructure.Mappings.Ingredients;
using Xunit;

namespace CateringPro.WebApi.Tests.Unit.Infrastructure.Mappings.Ingredients
{

    public class IngredientProfileTests
    {

        #region - - - - - - Profile Configuration Tests - - - - - -

        [Fact]
        public void IngredientProfile_ConfigurationValidation_Successful()
            => new MapperConfiguration(cfg => cfg.AddProfile<IngredientProfile>()).AssertConfigurationIsValid();

        #endregion Profile Configuration Tests

    }

}
