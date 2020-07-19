using CateringPro.Presentation.Extensions;
using FluentAssertions;
using FluentValidation;
using Xunit;

namespace CateringPro.Presentation.Tests.Unit.Extensions
{

    public class StringExtensionsTests
    {

        #region - - - - - - SnakeCaseToTitleCase Tests - - - - - -

        [Fact]
        public void ScreamingSnakeCaseToTitleCase_NullInput_NoExceptions()
        {
            // Arrange
            var _Input = null as string;

            // Act
            var _Output = Record.Exception(() => _Input.ScreamingSnakeCaseToTitleCase(nameof(_Input)));

            // Assert
            _Output.Should().BeNull();
        }

        [Theory]
        [InlineData("This_Is_A_Test")]
        [InlineData("this_is_a_test")]
        [InlineData("ThIs_Is_A_tEsT")]
        [InlineData("ThIsIsAtEsT")]
        [InlineData("_THISISATEST")]
        [InlineData("THISISATEST_")]
        public void ScreamingSnakeCaseToTitleCase_InvalidStrings_ThrowsValidationException(string input)
        {
            // Arrange

            // Act
            var _Output = Record.Exception(() => input.ScreamingSnakeCaseToTitleCase(nameof(input)));

            // Assert
            _Output.Should().BeOfType<ValidationException>();
        }

        [Theory]
        [InlineData("THIS_IS_A_TEST", "This Is A Test")]
        [InlineData("TEST", "Test")]
        public void ScreamingSnakeCaseToTitleCase_ValidScreamingSnakeCaseStrings_TitleCaseString(string input, string expected)
        {
            // Arrange

            // Act
            var _Output = input.ScreamingSnakeCaseToTitleCase(nameof(input));

            // Assert
            _Output.Should().Be(expected);
        }

        #endregion SnakeCaseToTitleCase Tests

    }

}