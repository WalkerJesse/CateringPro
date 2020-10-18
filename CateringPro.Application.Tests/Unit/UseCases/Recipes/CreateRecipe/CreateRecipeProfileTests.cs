using AutoMapper;
using CateringPro.Application.Services.Persistence;
using CateringPro.Application.UseCases.Recipes.CreateRecipe;
using CateringPro.Domain.Entities;
using FluentAssertions;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CateringPro.Application.Tests.Unit.UseCases.Recipes.CreateRecipe
{

    public class CreateRecipeProfileTests
    {

        #region - - - - - - Profile Configuration Tests - - - - - -

        [Fact]
        public void CreateRecipeProfile_ConfigurationValidation_Successful()
            => new MapperConfiguration(cfg => cfg.AddProfile<CreateRecipeProfile>()).AssertConfigurationIsValid();

        #endregion Profile Configuration Tests

    }

    public class IngredientResolverTests
    {

        #region - - - - - - Resolve Tests - - - - - -

        [Fact]
        public void Resolve_ValidID_Successful()
        {
            // Arrange
            var _CancellationToken = CancellationToken.None;
            var _IngredientID = 1;
            var _RecipeIngredientDto = new RecipeIngredientDto() { IngredientID = _IngredientID };
            var _Expected = new Ingredient() { ID = _IngredientID };

            var _MockPersistenceContext = new Mock<IPersistenceContext>();
            _MockPersistenceContext.Setup(mock => mock.FindAsync<Ingredient>(It.IsAny<object[]>(), _CancellationToken))
                .Returns(Task.FromResult(_Expected));

            var _Resolver = new IngredientResolver(_MockPersistenceContext.Object);

            // Act
            var _Actual = _Resolver.Resolve(_RecipeIngredientDto, null, null, null);

            // Assert
            _Actual.Should().Be(_Expected);
            _MockPersistenceContext.Verify(mock => mock.FindAsync<Ingredient>(It.IsAny<object[]>(), _CancellationToken));
            _MockPersistenceContext.VerifyNoOtherCalls();
        }

        #endregion Resolve Tests

    }

}
