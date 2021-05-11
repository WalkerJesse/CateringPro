using CateringPro.Application.Infrastructure;
using CateringPro.Application.Services;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CateringPro.Application.Tests.Unit.Infrastructure
{

    public class UseCaseInvokerTests
    {

        #region - - - - - - InvokeUseCaseAsync Tests - - - - - -

        [Fact]
        public async Task InvokeUseCaseAsync_FailsValidation_PresentsValidationFailure()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _Request = new TestUseCaseRequest();
            var _ValidationResult = new ValidationResult(new[] { new ValidationFailure("propertyName", "errorMessage") });

            var _MockInteractor = new Mock<IUseCaseInteractor<TestUseCaseRequest, object>>();
            var _MockPresenter = new Mock<IPresenter<object>>();
            var _MockValidator = new Mock<IValidator<TestUseCaseRequest>>();
            _MockValidator
                .Setup(mock => mock.ValidateAsync(_Request, _CancellationToken))
                .Returns(Task.FromResult(_ValidationResult));

            var _MockServiceProvider = new Mock<IServiceProvider>();
            _MockServiceProvider
                .Setup(mock => mock.GetService(typeof(IUseCaseInteractor<TestUseCaseRequest, object>)))
                .Returns(_MockInteractor.Object);
            _MockServiceProvider
                .Setup(mock => mock.GetService(typeof(IValidator<TestUseCaseRequest>)))
               .Returns(_MockValidator.Object);

            var _UseCaseInvoker = new UseCaseInvoker(_MockServiceProvider.Object);

            // Act
            await _UseCaseInvoker.InvokeUseCaseAsync(_Request, _MockPresenter.Object, _CancellationToken);

            // Assert
            _MockInteractor.Verify(mock => mock.HandleAsync(_Request, _MockPresenter.Object, _CancellationToken), Times.Never);
            _MockPresenter.Verify(mock => mock.PresentValidationFailureAsync(_ValidationResult, _CancellationToken));
            _MockValidator.Verify(mock => mock.ValidateAsync(_Request, _CancellationToken));
        }

        [Fact]
        public async Task InvokeUseCaseAsync_PassesValidation_InvokesInteractor()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _Request = new TestUseCaseRequest();

            var _MockInteractor = new Mock<IUseCaseInteractor<TestUseCaseRequest, object>>();
            var _MockPresenter = new Mock<IPresenter<object>>();
            var _MockValidator = new Mock<IValidator<TestUseCaseRequest>>();
            _MockValidator
                .Setup(mock => mock.ValidateAsync(_Request, _CancellationToken))
                .Returns(Task.FromResult(new ValidationResult()));

            var _MockServiceProvider = new Mock<IServiceProvider>();
            _MockServiceProvider
                .Setup(mock => mock.GetService(typeof(IUseCaseInteractor<TestUseCaseRequest, object>)))
                .Returns(_MockInteractor.Object);
            _MockServiceProvider
                .Setup(mock => mock.GetService(typeof(IValidator<TestUseCaseRequest>)))
                .Returns(_MockValidator.Object);

            var _UseCaseInvoker = new UseCaseInvoker(_MockServiceProvider.Object);

            // Act
            await _UseCaseInvoker.InvokeUseCaseAsync(_Request, _MockPresenter.Object, _CancellationToken);

            // Assert
            _MockInteractor.Verify(mock => mock.HandleAsync(_Request, _MockPresenter.Object, _CancellationToken));
            _MockValidator.Verify(mock => mock.ValidateAsync(_Request, _CancellationToken));
        }

        [Fact]
        public async Task InvokeUseCaseAsync_FailsBusinessRuleValidation_PresentsValidationFailure()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _Request = new TestUseCaseRequest();
            var _ValidationResult = new ValidationResult(new[] { new ValidationFailure("propertyName", "errorMessage") });

            var _MockBusinessRuleValidator = new Mock<IBusinessRuleValidator<TestUseCaseRequest>>();
            _MockBusinessRuleValidator
                .Setup(mock => mock.ValidateAsync(_Request, _CancellationToken))
                .Returns(Task.FromResult(_ValidationResult));

            var _MockInteractor = new Mock<IUseCaseInteractor<TestUseCaseRequest, object>>();
            var _MockPresenter = new Mock<IPresenter<object>>();

            var _MockServiceProvider = new Mock<IServiceProvider>();
            _MockServiceProvider
                .Setup(mock => mock.GetService(typeof(IUseCaseInteractor<TestUseCaseRequest, object>)))
                .Returns(_MockInteractor.Object);
            _MockServiceProvider
                .Setup(mock => mock.GetService(typeof(IBusinessRuleValidator<TestUseCaseRequest>)))
                .Returns(_MockBusinessRuleValidator.Object);

            var _UseCaseInvoker = new UseCaseInvoker(_MockServiceProvider.Object);

            // Act
            await _UseCaseInvoker.InvokeUseCaseAsync(_Request, _MockPresenter.Object, _CancellationToken);

            // Assert
            _MockBusinessRuleValidator.Verify(mock => mock.ValidateAsync(_Request, _CancellationToken));
            _MockInteractor.Verify(mock => mock.HandleAsync(_Request, _MockPresenter.Object, _CancellationToken), Times.Never);
            _MockPresenter.Verify(mock => mock.PresentValidationFailureAsync(_ValidationResult, _CancellationToken));
        }

        [Fact]
        public async Task InvokeUseCaseAsync_PassesBusinessRuleValidation_InvokesInteractor()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _Request = new TestUseCaseRequest();

            var _MockBusinessRuleValidator = new Mock<IBusinessRuleValidator<TestUseCaseRequest>>();
            _MockBusinessRuleValidator
                .Setup(mock => mock.ValidateAsync(_Request, _CancellationToken))
                .Returns(Task.FromResult(new ValidationResult()));

            var _MockInteractor = new Mock<IUseCaseInteractor<TestUseCaseRequest, object>>();
            var _MockPresenter = new Mock<IPresenter<object>>();

            var _MockServiceProvider = new Mock<IServiceProvider>();
            _MockServiceProvider
                .Setup(mock => mock.GetService(typeof(IUseCaseInteractor<TestUseCaseRequest, object>)))
                .Returns(_MockInteractor.Object);
            _MockServiceProvider
                .Setup(mock => mock.GetService(typeof(IBusinessRuleValidator<TestUseCaseRequest>)))
                .Returns(_MockBusinessRuleValidator.Object);

            var _UseCaseInvoker = new UseCaseInvoker(_MockServiceProvider.Object);

            // Act
            await _UseCaseInvoker.InvokeUseCaseAsync(_Request, _MockPresenter.Object, _CancellationToken);

            // Assert
            _MockBusinessRuleValidator.Verify(mock => mock.ValidateAsync(_Request, _CancellationToken));
            _MockInteractor.Verify(mock => mock.HandleAsync(_Request, _MockPresenter.Object, _CancellationToken));
        }

        [Fact]
        public async Task InvokeUseCaseAsync_NoValidator_InvokesInteractor()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _Request = new TestUseCaseRequest();

            var _MockInteractor = new Mock<IUseCaseInteractor<TestUseCaseRequest, object>>();
            var _MockPresenter = new Mock<IPresenter<object>>();

            var _MockServiceProvider = new Mock<IServiceProvider>();
            _MockServiceProvider
                .Setup(mock => mock.GetService(typeof(IUseCaseInteractor<TestUseCaseRequest, object>)))
                .Returns(_MockInteractor.Object);

            var _UseCaseInvoker = new UseCaseInvoker(_MockServiceProvider.Object);

            // Act
            await _UseCaseInvoker.InvokeUseCaseAsync(_Request, _MockPresenter.Object, _CancellationToken);

            // Assert
            _MockInteractor.Verify(mock => mock.HandleAsync(_Request, _MockPresenter.Object, _CancellationToken));
        }

        #endregion InvokeUseCaseAsync Tests

        #region - - - - - - Support Classes - - - - - -

        public class TestUseCaseRequest : IUseCaseRequest<object>
        {
        }

        #endregion Support Classes

    }

}
