using AutoMapper;
using CateringPro.Application.UseCases.Ingredients.GetIngredients;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Ingredients.GetIngredients
{

    public class GetIngredientsProfileTests
    {

        #region - - - - - - Profile Configuration Tests - - - - - -

        [Fact]
        public void GetIngredientsProfile_ConfigurationValidation_Successful()
            => new MapperConfiguration(cfg => cfg.AddProfile<GetIngredientsProfile>()).AssertConfigurationIsValid();

        #endregion Profile Configuration Tests

    }

}
