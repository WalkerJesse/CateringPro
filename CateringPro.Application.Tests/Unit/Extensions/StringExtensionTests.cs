using CateringPro.Application.Extensions;
using FluentAssertions;
using Xunit;

namespace CateringPro.Application.Tests.Unit.Extensions
{

    public class StringExtensionsTests
    {

        #region - - - - - - IsNullOrEmpty Tests - - - - - -

        [Theory]
        [InlineData(null, true)]
        [InlineData("", true)]
        [InlineData("This is a string", false)]
        public void IsNullOrEmpty_VariousStrings_ReturnsExpectedResult(string input, bool expected)
        {
            // Arrange

            // Act
            var _Output = input.IsNullOrEmpty();

            // Assert
            _Output.Should().Be(expected);
        }

        #endregion IsNullOrEmpty Tests

        #region - - - - - - IsNullOrWhiteSpace Tests - - - - - -

        [Theory]
        [InlineData(null, true)]
        [InlineData(" ", true)]
        [InlineData("This is a string", false)]
        public void IsNullOrWhiteSpace_VariousStrings_ReturnsExpectedResult(string input, bool expected)
        {
            // Arrange

            // Act
            var _Output = input.IsNullOrWhiteSpace();

            // Assert
            _Output.Should().Be(expected);
        }

        #endregion IsNullOrWhiteSpace Tests

    }

}
