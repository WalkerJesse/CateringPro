using CateringPro.Common.Extensions;
using FluentAssertions;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace CateringPro.Common.Tests.Unit.Extensions
{

    public class TypeExtensionsTests
    {

        #region - - - - - - GetImplementedInterfacesByInterfaceType Tests - - - - - -

        [Fact]
        public void GetImplementedInterfacesByInterfaceType_TypeIsNull_ThrowsArgumentNullException()
        {
            //Arrange
            var _Type = (Type)null;
            var _InterfaceType = typeof(IEnumerable<>);

            //Act
            var _Exception = Record.Exception(() => _Type.GetImplementedInterfacesByInterfaceType(_InterfaceType));

            //Assert
            _Exception.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public void GetImplementedInterfacesByInterfaceType_InterfaceTypeIsNull_ThrowsArgumentNullException()
        {
            //Arrange
            var _Type = typeof(Type);
            var _InterfaceType = (Type)null;

            //Act
            var _Exception = Record.Exception(() => _Type.GetImplementedInterfacesByInterfaceType(_InterfaceType));

            //Assert
            _Exception.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public void GetImplementedInterfacesByInterfaceType_InterfaceTypeIsNotAnInterface_ThrowsArgumentException()
        {
            //Arrange
            var _Type = typeof(object);
            var _InterfaceType = typeof(object);

            //Act
            var _Exception = Record.Exception(() => _Type.GetImplementedInterfacesByInterfaceType(_InterfaceType));

            //Assert
            _Exception.Should().BeOfType<ArgumentException>();
        }

        [Theory]
        [MemberData(nameof(GetImplementedInterfacesByInterfaceType_ValidTypeAndInterfaceType_ExpectedResults_GetTestData))]
        public void GetImplementedInterfacesByInterfaceType_ValidTypeAndInterfaceType_ExpectedResults(Type type, Type interfaceType, IEnumerable<Type> expected)
        {
            //Arrange

            //Act
            var _Actual = type.GetImplementedInterfacesByInterfaceType(interfaceType);

            //Assert
            _Actual.Should().BeEquivalentTo(expected);
        }


        //Supporting Functionality -------------------------------------------------------

        public static IEnumerable<object[]> GetImplementedInterfacesByInterfaceType_ValidTypeAndInterfaceType_ExpectedResults_GetTestData()
        {

            //Testing an open generic interface on a class with no matching implemented interfaces.
            yield return new object[]
            {
                typeof(ClassImplementingInterfaces),
                typeof(IEnumerable<>),
                new List<Type>()
            };

            //Testing an open generic interface on a class with multiple matching implemented interfaces.
            yield return new object[]
            {
                typeof(ClassImplementingInterfaces),
                typeof(IEquatable<>),
                new List<Type>()
                {
                    typeof(IEquatable<string>),
                    typeof(IEquatable<int>)
                }
            };

            //Testing a closed generic interface on a class with no matching implemented interfaces.
            yield return new object[]
            {
                typeof(ClassImplementingInterfaces),
                typeof(IEquatable<DateTime>),
                new List<Type>()
            };

            //Testing a closed generic interface on a class with a matching implemented interface.
            yield return new object[]
            {
                typeof(ClassImplementingInterfaces),
                typeof(IEquatable<int>),
                new List<Type>()
                {
                    typeof(IEquatable<int>)
                }
            };

            //Testing a non-generic interface on a class with no matching implemented interfaces.
            yield return new object[]
            {
                typeof(ClassImplementingInterfaces),
                typeof(IDisposable),
                new List<Type>()
            };

            //Testing a non-generic interface on a class with a matching implemented interface.
            yield return new object[]
            {
                typeof(ClassImplementingInterfaces),
                typeof(IEnumerable),
                new List<Type>()
                {
                    typeof(IEnumerable)
                }
            };

        }

        #endregion GetImplementedInterfacesByInterfaceType Tests

        #region - - - - - - IsInstantiable Tests - - - - - -

        [Fact]
        public void IsInstantiable_TypeIsNull_ThrowsArgumentNullException()
        {
            //Arrange
            var _Type = (Type)null;

            //Act
            var _Exception = Record.Exception(() => _Type.IsInstantiable());

            //Assert
            _Exception.Should().BeOfType<ArgumentNullException>();
        }

        [Theory]
        [MemberData(nameof(IsInstantiable_ValidType_ExpectedResults_GetTestData))]
        public void IsInstantiable_ValidType_ExpectedResults(Type type, bool expected)
        {
            //Arrange

            //Act
            var _Actual = type.IsInstantiable();

            //Assert
            _Actual.Should().Be(expected);
        }


        //Supporting Functionality -------------------------------------------------------

        public static IEnumerable<object[]> IsInstantiable_ValidType_ExpectedResults_GetTestData()
        {

            //Testing an interface type.
            yield return new object[]
            {
                typeof(IEnumerable),
                false
            };

            //Testing an abstract class type.
            yield return new object[]
            {
                typeof(BaseClass),
                false
            };

            //Testing a non-abstract class type.
            yield return new object[]
            {
                typeof(ClassImplementingInterfaces),
                true
            };

        }

        #endregion IsInstantiable Tests

        #region - - - - - - IsInterfaceImplemented Tests - - - - - -

        [Fact]
        public void IsInterfaceImplemented_TypeIsNull_ThrowsArgumentNullException()
        {
            //Arrange
            var _Type = (Type)null;
            var _InterfaceType = typeof(IEnumerable<>);

            //Act
            var _Exception = Record.Exception(() => _Type.IsInterfaceImplemented(_InterfaceType));

            //Assert
            _Exception.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public void IsInterfaceImplemented_InterfaceTypeIsNull_ThrowsArgumentNullException()
        {
            //Arrange
            var _Type = typeof(Type);
            var _InterfaceType = (Type)null;

            //Act
            var _Exception = Record.Exception(() => _Type.IsInterfaceImplemented(_InterfaceType));

            //Assert
            _Exception.Should().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public void IsInterfaceImplemented_InterfaceTypeIsNotAnInterface_ThrowsArgumentException()
        {
            //Arrange
            var _Type = typeof(object);
            var _InterfaceType = typeof(object);

            //Act
            var _Exception = Record.Exception(() => _Type.IsInterfaceImplemented(_InterfaceType));

            //Assert
            _Exception.Should().BeOfType<ArgumentException>();
        }

        [Theory]
        [MemberData(nameof(IsInterfaceImplemented_ValidTypeAndInterfaceType_ExpectedResults_GetTestData))]
        public void IsInterfaceImplemented_ValidTypeAndInterfaceType_ExpectedResults(Type type, Type interfaceType, bool expected)
        {
            //Arrange

            //Act
            var _Actual = type.IsInterfaceImplemented(interfaceType);

            //Assert
            _Actual.Should().Be(expected);
        }


        //Supporting Functionality -------------------------------------------------------

        public static IEnumerable<object[]> IsInterfaceImplemented_ValidTypeAndInterfaceType_ExpectedResults_GetTestData()
        {

            //Testing an open generic interface on a class with no matching implemented interfaces.
            yield return new object[]
            {
                typeof(ClassImplementingInterfaces),
                typeof(IEnumerable<>),
                false
            };

            //Testing an open generic interface on a class with multiple matching implemented interfaces.
            yield return new object[]
            {
                typeof(ClassImplementingInterfaces),
                typeof(IEquatable<>),
                true
            };

            //Testing a closed generic interface on a class with no matching implemented interfaces.
            yield return new object[]
            {
                typeof(ClassImplementingInterfaces),
                typeof(IEquatable<DateTime>),
                false
            };

            //Testing a closed generic interface on a class with a matching implemented interface.
            yield return new object[]
            {
                typeof(ClassImplementingInterfaces),
                typeof(IEquatable<int>),
                true
            };

            //Testing a non-generic interface on a class with no matching implemented interfaces.
            yield return new object[]
            {
                typeof(ClassImplementingInterfaces),
                typeof(IDisposable),
                false
            };

            //Testing a non-generic interface on a class with a matching implemented interface.
            yield return new object[]
            {
                typeof(ClassImplementingInterfaces),
                typeof(IEnumerable),
                true
            };

        }

        #endregion IsInterfaceImplemented Tests

        #region - - - - - - Supporting Functionality - - - - - -

        public abstract class BaseClass { }

        public class ClassImplementingInterfaces : IEquatable<string>, IEquatable<int>, IEnumerable
        {
            public bool Equals(string other) => throw new NotImplementedException();
            public bool Equals(int other) => throw new NotImplementedException();
            public IEnumerator GetEnumerator() => throw new NotImplementedException();
        }

        #endregion Supporting Functionality

    }

}
