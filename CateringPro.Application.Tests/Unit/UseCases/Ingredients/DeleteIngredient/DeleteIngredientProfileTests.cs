using AutoMapper;
using CateringPro.Application.UseCases.Ingredients.DeleteIngredient;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Ingredients.DeleteIngredient
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
