using AutoMapper;
using CateringPro.Application.UseCases.Ingredients.DeleteIngredient;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Ingredients.DeleteIngredient
{

    public class DeleteIngredientProfileTests
    {

        #region - - - - - - Profile Configuration Tests - - - - - -

        [Fact]
        public void ErrorMappingProfile_ConfigurationValidation_Successful()
        {
            // Arrange
            var _Configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile<DeleteIngredientProfile>());

            // Act

            // Assert
            _Configuration.AssertConfigurationIsValid();
        }

        #endregion Profile Configuration Tests

    }

}
