using CateringPro.Application.Infrastructure.Pipeline;
using CateringPro.Application.Services.Pipeline;
using FluentAssertions;
using MediatR;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CateringPro.Application.Tests.Unit.Infrastructure.MediatR
{

    public class BusinessRuleValidationBehaviourTests
    {

        #region - - - - - - Handle Tests - - - - - -

        [Fact]
        public async Task Handle_NoUserValidatorsExist_Successful()
        {
            //Arrange
            var _MockRequest = new Mock<IRequest<object>>();
            var _Validators = new List<IBusinessRuleValidator<object>>();
            var _BusinessRuleValidationBehaviour = new BusinessRuleValidationBehaviour<object, object>(_Validators);
            var _Delegate = CreateTestRequestHandlerDelegate();

            //Act
            var _Exception = await Record.ExceptionAsync(async () => await _BusinessRuleValidationBehaviour.Handle(_MockRequest.Object, CancellationToken.None, _Delegate));

            //Assert
            _Exception.Should().BeNull();
        }

        [Fact]
        public async Task Evaluate_RequestHasMultipleValidatorsDefined_AllRegisteredValidatorsAreEvaluated()
        {
            //Arrange
            var _MockRequest = new Mock<IRequest<object>>();
            var _MockValidator1 = new Mock<IBusinessRuleValidator<object>>();
            var _MockValidator2 = new Mock<IBusinessRuleValidator<object>>();
            var _ResourceAuthorisationPolicies = new List<IBusinessRuleValidator<object>> { _MockValidator1.Object, _MockValidator2.Object };

            var _BusinessRuleValidationBehaviour = new BusinessRuleValidationBehaviour<object, object>(_ResourceAuthorisationPolicies);
            var _Delegate = CreateTestRequestHandlerDelegate();

            //Act
            await _BusinessRuleValidationBehaviour.Handle(_MockRequest.Object, CancellationToken.None, _Delegate);

            //Assert
            _MockValidator1.Verify(mock => mock.Evaluate(_MockRequest.Object), Times.Once);
            _MockValidator2.Verify(mock => mock.Evaluate(_MockRequest.Object), Times.Once);
        }


        // Supporting Functionality ------------------------------------------------------

        private static RequestHandlerDelegate<object> CreateTestRequestHandlerDelegate() =>
            new RequestHandlerDelegate<object>(() => Task.FromResult(new object()));

        #endregion Handle Tests

    }

}