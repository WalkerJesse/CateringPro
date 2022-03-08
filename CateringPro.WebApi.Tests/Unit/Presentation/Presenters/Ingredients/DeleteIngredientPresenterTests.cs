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

    public class DeleteIngredientPresenterTests
    {

        #region - - - - - - Fields - - - - - -

        private readonly Mock<IMapper> m_MockMapper = new();

        private readonly IngredientDto m_DeletedIngredientDto = new();
        private readonly DeleteIngredientPresenter m_DeleteIngredientPresenter;
        private readonly IngredientViewModel m_DeletedIngredientViewModel = new();

        public DeleteIngredientPresenterTests()
        {
            this.m_DeleteIngredientPresenter = new(this.m_MockMapper.Object);

            this.m_MockMapper
                .Setup(mock => mock.Map<IngredientViewModel>(this.m_DeletedIngredientDto))
                .Returns(this.m_DeletedIngredientViewModel);
        }

        #endregion Fields

        #region - - - - - - PresentDeletedIngredientAsync Tests - - - - - -

        [Fact]
        public void PresentDeletedIngredientAsync_AnyRequest_PresentsOkObjectResult()
        {
            // Act
            var _Expected = new OkObjectResult(this.m_DeletedIngredientViewModel);

            // Arrange
            this.m_DeleteIngredientPresenter.PresentDeletedIngredientAsync(this.m_DeletedIngredientDto, default);

            // Assert
            this.m_DeleteIngredientPresenter.Result.Should().BeEquivalentTo(_Expected);
        }

        [Fact]
        public void PresentDeletedIngredientAsync_AnyRequest_SetsPresentedSuccessfullyTrue()
        {
            // Act

            // Arrange
            this.m_DeleteIngredientPresenter.PresentDeletedIngredientAsync(this.m_DeletedIngredientDto, default);

            // Assert
            this.m_DeleteIngredientPresenter.PresentedSuccessfully.Should().BeTrue();
        }

        [Fact]
        public void PresentDeletedIngredientAsync_AnyRequest_MapsIngredientDtoToIngredientViewModel()
        {
            // Act

            // Arrange
            this.m_DeleteIngredientPresenter.PresentDeletedIngredientAsync(this.m_DeletedIngredientDto, default);

            // Assert
            this.m_MockMapper.Verify(mock => mock.Map<IngredientViewModel>(this.m_DeletedIngredientDto));
        }

        #endregion PresentDeletedIngredientAsync Tests

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
            this.m_DeleteIngredientPresenter.PresentIngredientNotFound(5, default);

            // Assert
            this.m_DeleteIngredientPresenter.Result.Should().BeEquivalentTo(_Expected);
        }

        #endregion PresentIngredientNotFound Tests

    }

}
