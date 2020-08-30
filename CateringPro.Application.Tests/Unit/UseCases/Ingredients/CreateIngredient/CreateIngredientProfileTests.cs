﻿using AutoMapper;
using CateringPro.Application.UseCases.Ingredients.CreateIngredient;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Ingredients.CreateIngredient
{

    public class CreateIngredientProfileTests
    {

        #region - - - - - - Profile Configuration Tests - - - - - -

        [Fact]
        public void ErrorMappingProfile_ConfigurationValidation_Successful()
        {
            // Arrange
            var _Configuration = new MapperConfiguration(cfg =>
                cfg.AddProfile<CreateIngredientProfile>());

            // Act

            // Assert
            _Configuration.AssertConfigurationIsValid();
        }

        #endregion Profile Configuration Tests

    }

}