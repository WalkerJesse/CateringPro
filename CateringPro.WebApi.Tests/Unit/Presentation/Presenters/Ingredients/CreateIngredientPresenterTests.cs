using AutoMapper;
using CateringPro.Application.UseCases.Ingredients.CreateIngredient;
using CateringPro.WebApi.Presentation.Presenters.Ingredients;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace CateringPro.WebApi.Tests.Unit.Presentation.Presenters.Ingredients
{

    public class CreateIngredientPresenterTests
    {

        #region - - - - - - Fields - - - - - -

        private readonly Mock<IMapper> m_MockMapper = new();

        private readonly CreateIngredientPresenter m_CreateIngredientPresenter;

        public CreateIngredientPresenterTests()
            => this.m_CreateIngredientPresenter = new(this.m_MockMapper.Object);

        #endregion Fields

        #region - - - - - - PresentIngredientAsync Tests - - - - - -

        [Fact]
        public void PresentIngredientAsync_AnyRequest_PresentsCreatedResult()
        {
            // Act

            // Arrange
            this.m_CreateIngredientPresenter.PresentIngredientAsync(new CreatedIngredientDto(), default);

            // Assert
            this.m_CreateIngredientPresenter.Result.Should().BeAssignableTo<CreatedResult>();
        }

        [Fact]
        public void PresentIngredientAsync_AnyRequest_SetsPresentedSuccessfullyTrue()
        {
            // Act

            // Arrange
            this.m_CreateIngredientPresenter.PresentIngredientAsync(new CreatedIngredientDto(), default);

            // Assert
            this.m_CreateIngredientPresenter.PresentedSuccessfully.Should().BeTrue();
        }

        #endregion PresentIngredientAsync Tests

    }

}
