using AutoMapper;
using CateringPro.Application.Dtos;
using CateringPro.WebApi.Presentation.Presenters.Recipes;
using CateringPro.WebApi.Presentation.ViewModels.RecipeIngredients;
using CateringPro.WebApi.Presentation.ViewModels.Recipes;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CateringPro.WebApi.Tests.Unit.Presentation.Presenters.Recipes
{

    public class GetRecipesPresenterTests
    {

        #region - - - - - - Fields - - - - - -

        private readonly Mock<IMapper> m_MockMapper = new();

        private readonly List<RecipeDto> m_RecipeDtos = new();
        private readonly List<RecipeViewModel> m_RecipeViewModels = new();
        private readonly GetRecipesPresenter m_GetRecipesPresenter;

        public GetRecipesPresenterTests()
        {
            this.m_GetRecipesPresenter = new(this.m_MockMapper.Object);

            this.m_MockMapper
                .Setup(mock => mock.ConfigurationProvider)
                .Returns(new MapperConfiguration(opts =>
                {
                    opts.CreateMap<RecipeDto, RecipeViewModel>();
                    opts.CreateMap<RecipeIngredientDto, RecipeIngredientViewModel>();
                }));
        }

        #endregion Fields

        #region - - - - - - PresentRecipesAsync Tests - - - - - -

        [Fact]
        public void PresentRecipesAsync_AnyRequest_PresentsOkObjectResult()
        {
            // Act
            var _Expected = new OkObjectResult(this.m_RecipeViewModels.AsQueryable());

            // Arrange
            this.m_GetRecipesPresenter.PresentRecipesAsync(this.m_RecipeDtos.AsQueryable(), default);

            // Assert
            this.m_GetRecipesPresenter.Result.Should().BeEquivalentTo(_Expected);
        }

        #endregion PresentRecipesAsync Tests

    }

}
