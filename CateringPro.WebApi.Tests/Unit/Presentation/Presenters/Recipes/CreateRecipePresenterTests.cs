using AutoMapper;
using CateringPro.Application.UseCases.Recipes.CreateRecipe;
using CateringPro.WebApi.Presentation.Presenters.Recipes;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CateringPro.WebApi.Tests.Unit.Presentation.Presenters.Recipes
{

    public class CreateRecipePresenterTests
    {

        #region - - - - - - Fields - - - - - -

        private readonly Mock<IMapper> m_MockMapper = new();

        private readonly CreateRecipePresenter m_CreateRecipePresenter;

        public CreateRecipePresenterTests()
            => this.m_CreateRecipePresenter = new(this.m_MockMapper.Object);

        #endregion Fields

        #region - - - - - - PresentRecipeAsync Tests - - - - - -

        [Fact]
        public void PresentRecipeAsync_AnyRequest_PresentsCreatedResult()
        {
            // Act

            // Arrange
            this.m_CreateRecipePresenter.PresentRecipeAsync(new CreatedRecipeDto(), default);

            // Assert
            this.m_CreateRecipePresenter.Result.Should().BeAssignableTo<CreatedResult>();
        }

        [Fact]
        public void PresentRecipeAsync_AnyRequest_SetsPresentedSuccessfullyTrue()
        {
            // Act

            // Arrange
            this.m_CreateRecipePresenter.PresentRecipeAsync(new CreatedRecipeDto(), default);

            // Assert
            this.m_CreateRecipePresenter.PresentedSuccessfully.Should().BeTrue();
        }

        #endregion PresentRecipeAsync Tests

    }

}
