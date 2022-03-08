using AutoMapper;
using CateringPro.Application.Dtos;
using CateringPro.WebApi.Presentation.Presenters.Ingredients;
using CateringPro.WebApi.Presentation.ViewModels.Ingredients;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;
using Xunit;

namespace CateringPro.WebApi.Tests.Unit.Presentation.Presenters.Ingredients
{

    public class UpdateIngredientPresenterTests
    {

        #region - - - - - - Fields - - - - - -

        private readonly Mock<IMapper> m_MockMapper = new();

        private readonly IngredientDto m_UpdatedIngredientDto = new();
        private readonly UpdateIngredientPresenter m_UpdateIngredientPresenter;
        private readonly IngredientViewModel m_UpdatedIngredientViewModel = new();

        public UpdateIngredientPresenterTests()
        {
            this.m_UpdateIngredientPresenter = new(this.m_MockMapper.Object);

            this.m_MockMapper
                .Setup(mock => mock.Map<IngredientViewModel>(this.m_UpdatedIngredientDto))
                .Returns(this.m_UpdatedIngredientViewModel);
        }

        #endregion Fields

        #region - - - - - - PresentIngredientAsync Tests - - - - - -

        [Fact]
        public void PresentIngredientAsync_AnyRequest_PresentsOkObjectResult()
        {
            // Act
            var _Expected = new OkObjectResult(this.m_UpdatedIngredientViewModel);

            // Arrange
            this.m_UpdateIngredientPresenter.PresentIngredientAsync(this.m_UpdatedIngredientDto, default);

            // Assert
            this.m_UpdateIngredientPresenter.Result.Should().BeEquivalentTo(_Expected);
        }

        [Fact]
        public void PresentIngredientAsync_AnyRequest_SetsPresentedSuccessfullyTrue()
        {
            // Act

            // Arrange
            this.m_UpdateIngredientPresenter.PresentIngredientAsync(this.m_UpdatedIngredientDto, default);

            // Assert
            this.m_UpdateIngredientPresenter.PresentedSuccessfully.Should().BeTrue();
        }

        [Fact]
        public void PresentIngredientAsync_AnyRequest_MapsIngredientDtoToIngredientViewModel()
        {
            // Act

            // Arrange
            this.m_UpdateIngredientPresenter.PresentIngredientAsync(this.m_UpdatedIngredientDto, default);

            // Assert
            this.m_MockMapper.Verify(mock => mock.Map<IngredientViewModel>(this.m_UpdatedIngredientDto));
        }

        #endregion PresentIngredientAsync Tests

        #region - - - - - - PresentIngredientNotFound Tests - - - - - -

        [Fact]
        public void PresentIngredientNotFoundAsync_AnyRequest_PresdentsNotFoundObjectResult()
        {
            // Act
            var _Expected = new NotFoundObjectResult(new ProblemDetails()
            {
                Detail = $"'Ingredient' with the ID '5' was not found.",
                Status = (int)HttpStatusCode.NotFound,
                Title = "Entity was not found.",
                Type = "https://httpstatuses.com/400"
            });

            // Arrange
            this.m_UpdateIngredientPresenter.PresentIngredientNotFound(5, default);

            // Assert
            this.m_UpdateIngredientPresenter.Result.Should().BeEquivalentTo(_Expected);
        }

        #endregion PresentIngredientNotFound Tests

    }

}
