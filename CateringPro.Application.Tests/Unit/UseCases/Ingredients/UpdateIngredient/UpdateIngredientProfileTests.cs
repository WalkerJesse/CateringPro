using AutoMapper;
using CateringPro.Application.UseCases.Ingredients.UpdateIngredient;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Ingredients.UpdateIngredient
{

    public class UpdateIngredientProfileTests
    {

        #region - - - - - - Profile Configuration Tests - - - - - -

        [Fact]
        public void UpdateIngredientProfile_ConfigurationValidation_Successful()
            => new MapperConfiguration(cfg => cfg.AddProfile<UpdateIngredientProfile>()).AssertConfigurationIsValid();

        #endregion Profile Configuration Tests

    }

}
