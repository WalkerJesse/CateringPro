using CateringPro.Application.Infrastructure;
using CateringPro.Application.Services;
using FluentValidation;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CateringPro.Application.Tests.Unit.Infrastructure
{

    public class UseCaseInvokerTests
    {

        #region - - - - - - InvokeUseCase Tests - - - - - -

        [Fact]
        public async Task InvokeUseCaseAsync_ValidUseCase_SuccessfullyInvokesUseCase()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _MockUseCaseInteractor = new Mock<IUseCaseInteractor<TestUseCaseRequest, object>>();
            var _MockServiceProvider = new Mock<IServiceProvider>();
            _MockServiceProvider
                .Setup(mock => mock.GetService(typeof(IUseCaseInteractor<TestUseCaseRequest, object>)))
                .Returns(_MockUseCaseInteractor.Object);

            var _MockPresenter = new Mock<IPresenter<object>>();
            var _Request = new TestUseCaseRequest();

            var _UseCaseInvoker = new UseCaseInvoker(_MockServiceProvider.Object);

            // Act
            await _UseCaseInvoker.InvokeUseCaseAsync(_Request, _MockPresenter.Object, _CancellationToken);

            // Assert
            _MockServiceProvider.Verify(mock => mock.GetService(typeof(IUseCaseInteractor<TestUseCaseRequest, object>)), Times.Once);
            _MockUseCaseInteractor.Verify(mock => mock.HandleAsync(_Request, _MockPresenter.Object, _CancellationToken), Times.Once);
            _MockServiceProvider.VerifyNoOtherCalls();
            _MockUseCaseInteractor.VerifyNoOtherCalls();
        }

        #endregion InvokeUseCase Tests

        #region - - - - - - ValidateUseCase Tests - - - - - -

        [Fact]
        public async Task ValidateUseCaseAsync_NoValidator_DoesNotInvokeUseCase()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _MockUseCaseValidator = new Mock<IUseCaseValidator<TestUseCaseRequest, object>>();
            var _MockServiceProvider = new Mock<IServiceProvider>();
            var _MockPresenter = new Mock<IPresenter<object>>();
            var _Request = new TestUseCaseRequest();

            var _UseCaseInvoker = new UseCaseInvoker(_MockServiceProvider.Object);

            // Act
            await _UseCaseInvoker.ValidateUseCaseAsync(_Request, _MockPresenter.Object, _CancellationToken);

            // Assert
            _MockServiceProvider.Verify(mock => mock.GetService(typeof(IValidator<TestUseCaseRequest>)), Times.Once);
            _MockServiceProvider.VerifyNoOtherCalls();
            _MockUseCaseValidator.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ValidateUseCaseAsync_ValidUseCase_SuccessfullyInvokesUseCase()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _MockUseCaseValidator = new Mock<IUseCaseValidator<TestUseCaseRequest, object>>();
            var _MockValidator = new Mock<IValidator<TestUseCaseRequest>>();
            var _MockServiceProvider = new Mock<IServiceProvider>();
            _MockServiceProvider
                .Setup(mock => mock.GetService(typeof(IValidator<TestUseCaseRequest>)))
                .Returns(_MockValidator.Object);
            _MockServiceProvider
                .Setup(mock => mock.GetService(typeof(IUseCaseValidator<TestUseCaseRequest, object>)))
                .Returns(_MockUseCaseValidator.Object);

            var _MockPresenter = new Mock<IPresenter<object>>();
            var _Request = new TestUseCaseRequest();

            var _UseCaseInvoker = new UseCaseInvoker(_MockServiceProvider.Object);

            // Act
            await _UseCaseInvoker.ValidateUseCaseAsync(_Request, _MockPresenter.Object, _CancellationToken);

            // Assert
            _MockServiceProvider.Verify(mock => mock.GetService(typeof(IUseCaseValidator<TestUseCaseRequest, object>)), Times.Once);
            _MockServiceProvider.Verify(mock => mock.GetService(typeof(IValidator<TestUseCaseRequest>)), Times.Once);
            _MockUseCaseValidator.Verify(mock => mock.HandleAsync(_Request, _MockPresenter.Object, _CancellationToken), Times.Once);
            _MockServiceProvider.VerifyNoOtherCalls();
            _MockUseCaseValidator.VerifyNoOtherCalls();
        }

        #endregion ValidateUseCase Tests

        #region - - - - - - Support Classes - - - - - -

        public class TestUseCaseRequest : IUseCaseRequest<object>
        {
        }

        #endregion Support Classes

    }

}
