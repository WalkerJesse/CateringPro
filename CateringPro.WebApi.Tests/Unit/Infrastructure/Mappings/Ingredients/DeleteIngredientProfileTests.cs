using AutoMapper;
using CateringPro.WebApi.Infrastructure.Mappings.Ingredients;
using Xunit;

namespace CateringPro.WebApi.Tests.Unit.Infrastructure.Mappings.Ingredients
{

    public class DeleteIngredientProfileTests
    {

        #region - - - - - - Profile Configuration Tests - - - - - -

        [Fact]
        public void DeleteIngredientProfile_ConfigurationValidation_Successful()
            => new MapperConfiguration(cfg => cfg.AddProfile<DeleteIngredientProfile>()).AssertConfigurationIsValid();

        #endregion Profile Configuration Tests
    }

}
