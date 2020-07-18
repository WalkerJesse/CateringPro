using CateringPro.Common.Extensions;
using FluentAssertions;
using Xunit;

namespace CateringPro.Common.Tests.Unit.Extensions
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

        #region - - - - - - ToDelimitedPascalCase Tests - - - - - -

        [Theory]
        [InlineData("ThisIsATest", "This Is A Test")]
        [InlineData("ThisIsATest     ", "This Is A Test")]
        [InlineData("This      IsA    Test", "This Is A Test")]
        [InlineData("thisIsATest", "thisIsATest")]
        [InlineData(null, null)]
        public void ToDelimitedPascalCase_VariousStrings_ReturnsExpectedResult(string input, string expected)
        {
            // Arrange

            // Act
            var _Output = input.ToDelimitedPascalCase(" ");

            // Assert
            _Output.Should().Be(expected);
        }

        #endregion ToDelimitedPascalCase Tests

        #region - - - - - - ToSeparatorDelimited Tests - - - - - -

        [Theory]
        [InlineData("This is a string", "This is a string")]
        [InlineData("string1, string2, string3", "string1", "string2", "string3")]
        [InlineData("", null)]
        [InlineData("", "")]
        public void ToSeperatorDelimited_VariousStrings_ReturnsExpectedResult(string expected, params string[] input)
        {
            // Arrange
            var _Separator = ", ";

            // Act
            var _Output = input.ToSeperatorDelimited(_Separator);

            // Assert
            _Output.Should().Be(expected);
        }

        #endregion ToSeparatorDelimited Tests

    }

}
