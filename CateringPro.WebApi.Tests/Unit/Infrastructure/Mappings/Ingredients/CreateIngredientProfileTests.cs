using AutoMapper;
using CateringPro.WebApi.Infrastructure.Mappings.Ingredients;
using Xunit;

namespace CateringPro.WebApi.Tests.Unit.Infrastructure.Mappings.Ingredients
{

    public class CreateIngredientProfileTests
    {

        #region - - - - - - Profile Configuration Tests - - - - - -

        [Fact]
        public void CreateIngredientProfile_ConfigurationValidation_Successful()
            => new MapperConfiguration(cfg => cfg.AddProfile<CreateIngredientProfile>()).AssertConfigurationIsValid();

        #endregion Profile Configuration Tests

    }

}
