using AutoMapper;
using CateringPro.Application.UseCases.Recipes.CreateRecipe;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Recipes.CreateRecipe
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
