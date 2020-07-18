using CateringPro.Common.CodeContracts;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace CateringPro.Common.Tests.Unit.CodeContracts
{

    public class CodeContractTests
    {

        #region - - - - - - ArgumentNullException Tests - - - - - -

        [Theory]
        [MemberData(nameof(ArgumentNullException_ValidData_ReturnsArgumentNullException_GetTestData))]
        public void ArgumentNullException_ValidData_ReturnsArgumentNullException(string argumentName)
        {
            //Arrange

            //Act
            var _Exception = CodeContract.ArgumentNullException(argumentName);

            //Assert
            _Exception.Should().BeOfType<ArgumentNullException>();
        }


        //Supporting Functionality -------------------------------------------------------

        public static IEnumerable<object[]> ArgumentNullException_ValidData_ReturnsArgumentNullException_GetTestData()
        {

            //Testing normal argument name.
            yield return new object[]
            {
                "normalArgumentName"
            };

            //Testing empty string.
            yield return new object[]
            {
                string.Empty
            };

            //Testing a null string.
            yield return new object[]
            {
                (string)null
            };

        }

        #endregion ArgumentNullException Tests

        #region - - - - - - IsInstantiable Tests - - - - - -

        [Fact]
        public void IsInstantiable_ItemExpressionIsNull_ThrowsItemExpressionIsNullException()
        {
            //Arrange

            //Act
            var _Exception = Record.Exception(() => CodeContract.IsInstantiable(null));

            //Assert
            _Exception.Should().BeOfType<ItemExpressionIsNullException>();
        }

        [Fact]
        public void IsInstantiable_ItemIsNull_ThrowsArgumentNullException()
        {
            //Arrange
            var _Item = (Type)null;

            //Act
            var _Exception = Record.Exception(() => CodeContract.IsInstantiable(() => _Item));

            //Assert
            _Exception.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public void IsInstantiable_ItemIsNotInstantiatable_ThrowsArgumentException()
        {
            //Arrange
            var _Item = typeof(BaseClass);

            //Act
            var _Exception = Record.Exception(() => CodeContract.IsInstantiable(() => _Item));

            //Assert
            _Exception.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public void IsInstantiable_InvalidExpressionFormat_ArgumentException()
        {
            //Arrange
            var _Item = new TestClass();

            //Act
            var _Exception = Record.Exception(() => CodeContract.IsInstantiable(() => _Item.TypeValue));

            //Assert
            _Exception.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public void IsInstantiable_ValidData_Successful()
        {
            //Arrange
            var _Item = typeof(TestClass);

            //Act
            var _Exception = Record.Exception(() => CodeContract.IsInstantiable(() => _Item));

            //Assert
            _Exception.Should().BeNull();
        }

        #endregion IsInstantiable Tests

        #region - - - - - - IsInterface Tests - - - - - -

        [Fact]
        public void IsInterface_ItemExpressionIsNull_ThrowsItemExpressionIsNullException()
        {
            //Arrange

            //Act
            var _Exception = Record.Exception(() => CodeContract.IsInterface(null));

            //Assert
            _Exception.Should().BeOfType<ItemExpressionIsNullException>();
        }

        [Fact]
        public void IsInterface_ItemIsNull_ThrowsArgumentNullException()
        {
            //Arrange
            var _Item = (Type)null;

            //Act
            var _Exception = Record.Exception(() => CodeContract.IsInterface(() => _Item));

            //Assert
            _Exception.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public void IsInterface_ItemIsNotAnInterface_ThrowsArgumentException()
        {
            //Arrange
            var _Item = typeof(BaseClass);

            //Act
            var _Exception = Record.Exception(() => CodeContract.IsInterface(() => _Item));

            //Assert
            _Exception.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public void IsInterface_InvalidExpressionFormat_ArgumentException()
        {
            //Arrange
            var _Item = new TestClass();

            //Act
            var _Exception = Record.Exception(() => CodeContract.IsInterface(() => _Item.TypeValue));

            //Assert
            _Exception.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public void IsInterface_ValidData_Successful()
        {
            //Arrange
            var _Item = typeof(IEnumerable<>);

            //Act
            var _Exception = Record.Exception(() => CodeContract.IsInterface(() => _Item));

            //Assert
            _Exception.Should().BeNull();
        }

        #endregion IsInterface Tests

        #region - - - - - - IsNotNull Tests - - - - - -

        [Fact]
        public void IsNotNull_ItemExpressionIsNull_ThrowsItemExpressionIsNullException()
        {
            //Arrange

            //Act
            var _Exception = Record.Exception(() => CodeContract.IsNotNull<object>(null));

            //Assert
            _Exception.Should().BeOfType<ItemExpressionIsNullException>();
        }

        [Fact]
        public void IsNotNull_ItemIsNull_ThrowsArgumentNullException()
        {
            //Arrange
            var _Item = (object)null;

            //Act
            var _Exception = Record.Exception(() => CodeContract.IsNotNull(() => _Item));

            //Assert
            _Exception.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public void IsNotNull_InvalidExpressionFormat_ArgumentException()
        {
            //Arrange
            var _Item = new TestClass();

            //Act
            var _Exception = Record.Exception(() => CodeContract.IsNotNull(() => _Item.IntValue));

            //Assert
            _Exception.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public void IsNotNull_ValidData_Successful()
        {
            //Arrange
            var _Item = typeof(TestClass);

            //Act
            var _Exception = Record.Exception(() => CodeContract.IsNotNull(() => _Item));

            //Assert
            _Exception.Should().BeNull();
        }

        #endregion IsNotNull Tests

        #region - - - - - - IsNotNullOrEmpty Tests - - - - - -

        [Fact]
        public void IsNotNullOrEmpty_ItemExpressionIsNull_ThrowsItemExpressionIsNullException()
        {
            //Arrange

            //Act
            var _Exception = Record.Exception(() => CodeContract.IsNotNullOrEmpty(null));

            //Assert
            _Exception.Should().BeOfType<ItemExpressionIsNullException>();
        }

        [Fact]
        public void IsNotNullOrEmpty_StringIsNull_ThrowsArgumentNullException()
        {
            //Arrange
            var _Item = (string)null;

            //Act
            var _Exception = Record.Exception(() => CodeContract.IsNotNullOrEmpty(() => _Item));

            //Assert
            _Exception.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public void IsNotNullOrEmpty_StringIsEmpty_ThrowsStringIsEmptyException()
        {
            //Arrange
            var _Item = string.Empty;

            //Act
            var _Exception = Record.Exception(() => CodeContract.IsNotNullOrEmpty(() => _Item));

            //Assert
            _Exception.Should().BeOfType<StringIsEmptyException>();
        }

        [Fact]
        public void IsNotNullOrEmpty_InvalidExpressionFormat_ArgumentException()
        {
            //Arrange
            var _Item = new TestClass();

            //Act
            var _Exception = Record.Exception(() => CodeContract.IsNotNullOrEmpty(() => _Item.StringValue));

            //Assert
            _Exception.Should().BeOfType<ArgumentException>();
        }

        [Fact]
        public void IsNotNullOrEmpty_ValidData_Successful()
        {
            //Arrange
            var _Item = "Test";

            //Act
            var _Exception = Record.Exception(() => CodeContract.IsNotNullOrEmpty(() => _Item));

            //Assert
            _Exception.Should().BeNull();
        }

        #endregion IsNotNull Tests

        #region - - - - - - IsNotNullOrWhiteSpace Tests - - - - - -

        [Fact]
        public void IsNotNullOrWhiteSpace_ValueIsNull_ThrowsCodeContractExceptionReasonNull()
        {
            // Arrange

            // Act
            var _Exception = Record.Exception(() => CodeContract.IsNotNullOrWhiteSpace(null, "x"));

            // Assert
            _Exception.Should().BeOfType<CodeContract.Exception>();
            ((CodeContract.Exception)_Exception).ExceptionReason.Should().Be(CodeContract.ExceptionReasonEnum.Null);
        }

        [Fact]
        public void IsNotNullOrWhiteSpace_ValueIsEmpty_ThrowsCodeContractExceptionReasonEmpty()
        {
            // Arrange

            // Act
            var _Exception = Record.Exception(() => CodeContract.IsNotNullOrWhiteSpace(string.Empty, "x"));

            // Assert
            _Exception.Should().BeOfType<CodeContract.Exception>();
            ((CodeContract.Exception)_Exception).ExceptionReason.Should().Be(CodeContract.ExceptionReasonEnum.Empty);
        }

        [Fact]
        public void IsNotNullOrWhiteSpace_ValueIsWhiteSpace_ThrowsCodeContractExceptionReasonWhiteSpace()
        {
            // Arrange

            // Act
            var _Exception = Record.Exception(() => CodeContract.IsNotNullOrWhiteSpace(" ", "x"));

            // Assert
            _Exception.Should().BeOfType<CodeContract.Exception>();
            ((CodeContract.Exception)_Exception).ExceptionReason.Should().Be(CodeContract.ExceptionReasonEnum.WhiteSpace);
        }

        #endregion IsNotNullOrWhiteSpace Tests

        #region " - - - - - - Supporting Functionality - - - - - - "

        private abstract class BaseClass { }

        private class TestClass
        {
            public Type TypeValue { get; set; }
            public int IntValue { get; set; }
            public string StringValue { get; set; }
        }

        #endregion Supporting Functionality

    }

}
