using AutoMapper;
using CateringPro.Application.UseCases.Recipes.GetRecipes;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Recipes.GetRecipes
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
