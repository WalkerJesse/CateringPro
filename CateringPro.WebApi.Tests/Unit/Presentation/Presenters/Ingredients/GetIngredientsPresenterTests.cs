using AutoMapper;
using CateringPro.Application.Dtos;
using CateringPro.WebApi.Presentation.Presenters.Ingredients;
using CateringPro.WebApi.Presentation.ViewModels.Ingredients;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CateringPro.WebApi.Tests.Unit.Presentation.Presenters.Ingredients
{

    public class GetIngredientsPresenterTests
    {

        #region - - - - - - Fields - - - - - -

        private readonly Mock<IMapper> m_MockMapper = new();

        private readonly List<IngredientDto> m_IngredientDtos = new();
        private readonly List<IngredientViewModel> m_IngredientViewModels = new();
        private readonly GetIngredientsPresenter m_GetIngredientsPresenter;

        public GetIngredientsPresenterTests()
        {
            this.m_GetIngredientsPresenter = new(this.m_MockMapper.Object);

            this.m_MockMapper
                .Setup(mock => mock.ConfigurationProvider)
                .Returns(new MapperConfiguration(opts => opts.CreateMap<IngredientDto, IngredientViewModel>()));
        }

        #endregion Fields

        #region - - - - - - PresentIngredientsAsync Tests - - - - - -

        [Fact]
        public void PresentIngredientsAsync_AnyRequest_PresentsOkObjectResult()
        {
            // Act
            var _Expected = new OkObjectResult(this.m_IngredientViewModels.AsQueryable());

            // Arrange
            this.m_GetIngredientsPresenter.PresentIngredientsAsync(this.m_IngredientDtos.AsQueryable(), default);

            // Assert
            this.m_GetIngredientsPresenter.Result.Should().BeEquivalentTo(_Expected);
        }

        #endregion PresentIngredientsAsync Tests

    }

}
