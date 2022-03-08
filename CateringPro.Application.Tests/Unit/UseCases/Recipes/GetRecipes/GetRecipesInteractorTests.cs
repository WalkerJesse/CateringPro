using AutoMapper;
using CateringPro.Application.Dtos;
using CateringPro.Application.Services.Persistence;
using CateringPro.Application.UseCases.Recipes.GetRecipes;
using CateringPro.Domain.Entities;
using CateringPro.Domain.Enumerations;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Recipes.GetRecipes
{

    public class GetRecipesInteractorTests
    {

        #region - - - - - - Fields - - - - - -

        private readonly Mock<IMapper> m_MockMapper = new();
        private readonly Mock<IGetRecipesOutputPort> m_MockOutputPort = new();
        private readonly Mock<IPersistenceContext> m_MockPersistenceContext = new();

        private IQueryable<RecipeDto> m_Actual;
        private readonly GetRecipesInputPort m_InputPort = new();
        private readonly GetRecipesInteractor m_Interactor;

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public GetRecipesInteractorTests()
        {
            this.m_Interactor = new(this.m_MockMapper.Object, this.m_MockPersistenceContext.Object);

            this.m_MockMapper
                .Setup(mock => mock.ConfigurationProvider)
                .Returns(new MapperConfiguration(opts =>
                {
                    opts.CreateMap<Ingredient, IngredientDto>();
                    opts.CreateMap<MeasurementType, MeasurementTypeDto>();
                    opts.CreateMap<Recipe, RecipeDto>();
                    opts.CreateMap<RecipeIngredient, RecipeIngredientDto>();
                }));

            this.m_MockOutputPort
                .Setup(mock => mock.PresentRecipesAsync(It.IsAny<IQueryable<RecipeDto>>(), default))
                .Callback((IQueryable<RecipeDto> dtos, CancellationToken c) => this.m_Actual = dtos);

            this.m_MockPersistenceContext
                .Setup(mock => mock.GetEntities<Recipe>())
                .Returns(new[] { new Recipe() { Ingredients = new List<RecipeIngredient>() } }.AsQueryable());
        }

        #endregion Constructors

        #region - - - - - - HandleAsync Tests - - - - - -

        [Fact]
        public async Task HandleAsync_AnyRequest_PresentsRecipeDtos()
        {
            // Arrange
            var _Expected = new[] { new RecipeDto() { Ingredients = new List<RecipeIngredientDto>() } };

            // Act
            await this.m_Interactor.HandleAsync(this.m_InputPort, this.m_MockOutputPort.Object, default);

            // Assert
            this.m_Actual.Should().BeEquivalentTo(_Expected);

            this.m_MockOutputPort.Verify(mock => mock.PresentRecipesAsync(It.IsAny<IQueryable<RecipeDto>>(), default), Times.Once);

            this.m_MockOutputPort.VerifyNoOtherCalls();
        }

        #endregion HandleAsync Tests

    }

}
