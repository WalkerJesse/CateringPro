using CateringPro.Application.Infrastructure;
using CateringPro.Application.Services;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CateringPro.Application.Tests.Unit.Infrastructure
{

    public class UseCaseValidatorTests
    {

        #region - - - - - - HandleAsync Tests - - - - - -

        [Fact]
        public async Task HandleAsync_InvalidUseCase_PresentsValidationErrors()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _Request = new TestUseCaseRequest();
            var _ValidationResult = new ValidationResult(new List<ValidationFailure>
            {
                new ValidationFailure("", "")
            });

            var _MockValidator = new Mock<IValidator<TestUseCaseRequest>>();
            _MockValidator
                .Setup(mock => mock.ValidateAsync(_Request, _CancellationToken))
                .Returns(Task.FromResult(_ValidationResult));

            var _MockPresenter = new Mock<IPresenter<TestUseCaseResponse>>();

            var _UseCaseValidator = new UseCaseValidator<TestUseCaseRequest, TestUseCaseResponse>(_MockValidator.Object);

            // Act
            await _UseCaseValidator.HandleAsync(_Request, _MockPresenter.Object, _CancellationToken);

            // Assert
            _MockValidator.Verify(mock => mock.ValidateAsync(_Request, _CancellationToken), Times.Once);
            _MockPresenter.Verify(mock => mock.PresentValidationFailureAsync(_ValidationResult, _CancellationToken), Times.Once);
            _MockValidator.VerifyNoOtherCalls();
            _MockPresenter.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task HandleAsync_InvalidUseCase_SuccessfullyValidatesUseCase()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _Request = new TestUseCaseRequest();
            var _ValidationResult = new ValidationResult();

            var _MockValidator = new Mock<IValidator<TestUseCaseRequest>>();
            _MockValidator
                .Setup(mock => mock.ValidateAsync(_Request, _CancellationToken))
                .Returns(Task.FromResult(_ValidationResult));

            var _MockPresenter = new Mock<IPresenter<TestUseCaseRequest>>();

            var _UseCaseValidator = new UseCaseValidator<TestUseCaseRequest, TestUseCaseRequest>(_MockValidator.Object);

            // Act
            await _UseCaseValidator.HandleAsync(_Request, _MockPresenter.Object, _CancellationToken);

            // Assert
            _MockValidator.Verify(mock => mock.ValidateAsync(_Request, _CancellationToken), Times.Once);
            _MockValidator.VerifyNoOtherCalls();
            _MockPresenter.VerifyNoOtherCalls();
        }

        #endregion HandleAsync Tests

        #region - - - - - - Support Classes - - - - - -

        public class TestUseCaseRequest : IUseCaseRequest<object>
        {
        }

        public class TestUseCaseResponse
        {
        }

        #endregion Support Classes

    }

}
