using CateringPro.Domain.Enumerations;
using CateringPro.Domain.Exceptions;
using FluentAssertions;
using Xunit;

namespace CateringPro.Domain.Tests.Unit.Enumerations
{

    public class EnumerationTests
    {

        #region - - - - - - CompareTo Tests - - - - - -

        [Fact]
        public void CompareTo_LessThanOtherEnum_ReturnsLessThanZero()
        {
            // Arrange
            var _Enum = TestEnumeration.Enum1;
            var _OtherEnum = TestEnumeration.Enum2;

            // Act
            var _Output = _Enum.CompareTo(_OtherEnum);

            // Assert
            _Output.Should().BeLessThan(0);
        }

        [Fact]
        public void CompareTo_GreaterThanOtherEnum_ReturnsLGreaterThanZero()
        {
            // Arrange
            var _Enum = TestEnumeration.Enum3;
            var _OtherEnum = TestEnumeration.Enum2;

            // Act
            var _Output = _Enum.CompareTo(_OtherEnum);

            // Assert
            _Output.Should().BeGreaterThan(0);
        }

        [Fact]
        public void CompareTo_EqualToOtherEnum_ReturnsZero()
        {
            // Arrange
            var _Enum = TestEnumeration.Enum2;
            var _OtherEnum = TestEnumeration.Enum2;

            // Act
            var _Output = _Enum.CompareTo(_OtherEnum);

            // Assert
            _Output.Should().Be(0);
        }

        #endregion CompareTo Tests

        #region - - - - - - Equals Tests - - - - - -

        [Fact]
        public void Equals_OtherEnumIsNull_ReturnsFalse()
        {
            // Arrange
            var _Enum = TestEnumeration.Enum1;

            // Act
            var _Output = _Enum.Equals(null);

            // Assert
            _Output.Should().Be(false);
        }

        [Fact]
        public void Equals_TypeMatchesButValueDoesnt_ReturnsFalse()
        {
            // Arrange
            var _Enum = TestEnumeration.Enum1;
            var _OtherEnum = TestEnumeration.Enum2;

            // Act
            var _Output = _Enum.Equals(_OtherEnum);

            // Assert
            _Output.Should().Be(false);
        }

        [Fact]
        public void Equals_TypeDoesntMatchButValueDoes_ReturnsFalse()
        {
            // Arrange
            var _Enum = TestEnumeration.Enum1;
            var _OtherEnum = TestEnumeration2.Enum1;

            // Act
            var _Output = _Enum.Equals(_OtherEnum);

            // Assert
            _Output.Should().Be(false);
        }

        [Fact]
        public void Equals_EqualToOTherEnum_ReturnsTrue()
        {
            // Arrange
            var _Enum = new TestEnumeration("TestEnum", 5);
            var _OtherEnum = new TestEnumeration("TestEnum", 5);

            // Act
            var _Output = _Enum.Equals(_OtherEnum);

            // Assert
            _Output.Should().Be(true);
        }

        #endregion Equals Tests

        #region - - - - - - FromName Tests - - - - - -

        [Fact]
        public void FromName_NameIsNull_ReturnsNull()
        {
            // Arrange

            // Act
            var _Output = Enumeration.FromName<TestEnumeration>(null);

            // Assert
            _Output.Should().Be(null);
        }

        [Fact]
        public void FromName_NameIsInEnum_ReturnsEnum()
        {
            // Arrange
            var _Input = TestEnumeration.Enum1;

            // Act
            var _Output = Enumeration.FromName<TestEnumeration>(_Input.Name);

            // Assert
            _Output.Should().Be(_Input);
        }

        [Fact]
        public void FromName_NameIsNotInEnum_ThrowsInvalidEnumException()
        {
            // Arrange
            var _Input = "Enum5";

            // Act
            var _Output = Record.Exception(() => Enumeration.FromName<TestEnumeration>(_Input));

            // Assert
            _Output.Should().BeOfType<InvalidEnumException>();
        }

        #endregion FromName Tests

        #region - - - - - - FromValue Tests - - - - - -

        [Fact]
        public void FromValue_ValueIsInEnum_ReturnsEnum()
        {
            // Arrange
            var _Input = TestEnumeration.Enum1;

            // Act
            var _Output = Enumeration.FromValue<TestEnumeration>(_Input.Value);

            // Assert
            _Output.Should().Be(_Input);
        }

        [Fact]
        public void FromValue_ValueIsNotInEnum_ThrowsInvalidEnumException()
        {
            // Arrange
            var _Input = 5;

            // Act
            var _Output = Record.Exception(() => Enumeration.FromValue<TestEnumeration>(_Input));

            // Assert
            _Output.Should().BeOfType<InvalidEnumException>();
        }

        #endregion FromValue Tests

        #region - - - - - - GetAll Tests - - - - - -

        [Fact]
        public void GetAll_ListOfEnumerations_ReturnsAllEnumerations()
        {
            // Arrange
            var _Expected = new[] { TestEnumeration.Enum1, TestEnumeration.Enum2, TestEnumeration.Enum3 };

            // Act
            var _Output = Enumeration.GetAll<TestEnumeration>();

            // Assert
            _Output.Should().BeEquivalentTo(_Expected);
        }

        #endregion GetAll Tests

        #region - - - - - - GetHashCode Tests - - - - - -

        [Fact]
        public void GetHashCode_ValidEnum_ReturnsHashCode()
        {
            // Arrange
            var _Input = TestEnumeration.Enum2;

            // Act
            var _Output = _Input.GetHashCode();

            // Assert
            _Output.Should().Be((int)_Input.Value);
        }

        #endregion GetHashCode Tests

        #region - - - - - - ToString Tests - - - - - -

        [Fact]
        public void ToString_ValidEnum_ReturnsName()
        {
            // Arrange
            var _Input = TestEnumeration.Enum2;

            // Act
            var _Output = _Input.ToString();

            // Assert
            _Output.Should().Be(_Input.Name);
        }

        #endregion ToString Tests

    }

    public class TestEnumeration : Enumeration
    {

        #region - - - - - - Fields - - - - - -

        public static readonly TestEnumeration Enum1 = new TestEnumeration("Enum1", 1);

        public static readonly TestEnumeration Enum2 = new TestEnumeration("Enum2", 2);

        public static readonly TestEnumeration Enum3 = new TestEnumeration("Enum3", 3);

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public TestEnumeration() { }

        public TestEnumeration(string name, int value) : base(name, value) { }

        #endregion Constructors

    }

    public class TestEnumeration2 : Enumeration
    {

        #region - - - - - - Fields - - - - - -

        public static readonly TestEnumeration2 Enum1 = new TestEnumeration2("Enum1", 1);

        public static readonly TestEnumeration2 Enum2 = new TestEnumeration2("Enum2", 2);

        public static readonly TestEnumeration2 Enum3 = new TestEnumeration2("Enum3", 3);

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public TestEnumeration2() { }

        public TestEnumeration2(string name, int value) : base(name, value) { }

        #endregion Constructors

    }
}
