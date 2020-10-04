using AutoMapper;
using CateringPro.Application.UseCases.Ingredients.CreateIngredient;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Ingredients.CreateIngredient
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
