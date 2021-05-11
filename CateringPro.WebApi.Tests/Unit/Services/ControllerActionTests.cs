using AutoMapper;
using CateringPro.Application.Services;
using CateringPro.Application.Services.Persistence;
using CateringPro.WebApi.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CateringPro.WebApi.Tests.Unit.Services
{

    public class ControllerActionTests
    {

        #region - - - - - - CreateAsync Tests - - - - - -

        [Fact]
        public async Task CreateAsync_PresenterPresentedSuccessfully_SavesChanges()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _Command = "Command";
            var _Request = new GetUseCaseRequest();
            var _Result = new OkObjectResult("Ok");

            var _MockMapper = new Mock<IMapper>();
            _MockMapper
                .Setup(mock => mock.Map<object>(_Command))
                .Returns(_Request);

            var _MockPersistenceContext = new Mock<IPersistenceContext>();

            var _MockUseCaseInvoker = new Mock<IUseCaseInvoker>();
            _MockUseCaseInvoker
                .Setup(mock => mock.InvokeUseCaseAsync(It.IsAny<GetUseCaseRequest>(), It.IsAny<IPresenter<GetUseCaseResponse>>(), It.IsAny<CancellationToken>()))
                .Returns((GetUseCaseRequest request, Presenter<GetUseCaseResponse> presenter, CancellationToken cancellationToken) =>
                {
                    presenter.PresentedSuccessfully = true;
                    presenter.Result = _Result;
                    return Task.CompletedTask;
                });

            var _ControllerAction = new ControllerAction(_MockMapper.Object, _MockPersistenceContext.Object, _MockUseCaseInvoker.Object);

            var _Expected = new OkObjectResult("Ok");

            // Act
            var _Actual = await _ControllerAction.CreateAsync<string, GetUseCaseRequest, GetUseCaseResponse>(_Command, _CancellationToken);

            // Assert
            _Actual.Should().BeEquivalentTo(_Expected);
            _MockMapper.Verify(mock => mock.Map<GetUseCaseRequest>(_Command), Times.Once);
            _MockPersistenceContext.Verify(mock => mock.SaveChangesAsync(_CancellationToken), Times.Once);
            _MockUseCaseInvoker.Verify(mock => mock.InvokeUseCaseAsync(_Request, It.IsAny<IPresenter<GetUseCaseResponse>>(), _CancellationToken), Times.Once);
            _MockMapper.VerifyNoOtherCalls();
            _MockPersistenceContext.VerifyNoOtherCalls();
            _MockUseCaseInvoker.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task CreateAsync_PresenterDidNotPresentSuccessfully_DoesNotSaveChanges()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _Command = "Command";
            var _Request = new GetUseCaseRequest();
            var _Result = new BadRequestObjectResult("Bad");

            var _MockMapper = new Mock<IMapper>();
            _MockMapper
                .Setup(mock => mock.Map<object>(_Command))
                .Returns(_Request);

            var _MockPersistenceContext = new Mock<IPersistenceContext>();

            var _MockUseCaseInvoker = new Mock<IUseCaseInvoker>();
            _MockUseCaseInvoker
                .Setup(mock => mock.InvokeUseCaseAsync(It.IsAny<GetUseCaseRequest>(), It.IsAny<IPresenter<GetUseCaseResponse>>(), It.IsAny<CancellationToken>()))
                .Returns((GetUseCaseRequest request, Presenter<GetUseCaseResponse> presenter, CancellationToken cancellationToken) =>
                {
                    presenter.PresentedSuccessfully = false;
                    presenter.Result = _Result;
                    return Task.CompletedTask;
                });

            var _ControllerAction = new ControllerAction(_MockMapper.Object, _MockPersistenceContext.Object, _MockUseCaseInvoker.Object);

            var _Expected = new BadRequestObjectResult("Bad");

            // Act
            var _Actual = await _ControllerAction.CreateAsync<string, GetUseCaseRequest, GetUseCaseResponse>(_Command, _CancellationToken);

            // Assert
            _Actual.Should().BeEquivalentTo(_Expected);
            _MockMapper.Verify(mock => mock.Map<GetUseCaseRequest>(_Command), Times.Once);
            _MockUseCaseInvoker.Verify(mock => mock.InvokeUseCaseAsync(_Request, It.IsAny<IPresenter<GetUseCaseResponse>>(), _CancellationToken), Times.Once);
            _MockMapper.VerifyNoOtherCalls();
            _MockPersistenceContext.VerifyNoOtherCalls();
            _MockUseCaseInvoker.VerifyNoOtherCalls();
        }

        #endregion CreateAsync Tests

        #region - - - - - - ReadAsync Tests - - - - - -

        [Fact]
        public async Task ReadAsync_AnyQuery_ReturnsPresentedResult()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _Query = "Query";
            var _Request = new GetUseCaseRequest();
            var _Result = new OkObjectResult("Ok");

            var _MockMapper = new Mock<IMapper>();
            _MockMapper
                .Setup(mock => mock.Map<object>(_Query))
                .Returns(_Request);

            var _MockPersistenceContext = new Mock<IPersistenceContext>();

            var _MockUseCaseInvoker = new Mock<IUseCaseInvoker>();
            _MockUseCaseInvoker
                .Setup(mock => mock.InvokeUseCaseAsync(It.IsAny<GetUseCaseRequest>(), It.IsAny<IPresenter<GetUseCaseResponse>>(), It.IsAny<CancellationToken>()))
                .Returns((GetUseCaseRequest request, Presenter<GetUseCaseResponse> presenter, CancellationToken cancellationToken) =>
                {
                    presenter.PresentedSuccessfully = true;
                    presenter.Result = _Result;
                    return Task.CompletedTask;
                });

            var _ControllerAction = new ControllerAction(_MockMapper.Object, _MockPersistenceContext.Object, _MockUseCaseInvoker.Object);

            var _Expected = new OkObjectResult("Ok");

            // Act
            var _Actual = await _ControllerAction.ReadAsync<string, GetUseCaseRequest, GetUseCaseResponse>(_Query, _CancellationToken);

            // Assert
            _Actual.Should().BeEquivalentTo(_Expected);
            _MockMapper.Verify(mock => mock.Map<GetUseCaseRequest>(_Query), Times.Once);
            _MockUseCaseInvoker.Verify(mock => mock.InvokeUseCaseAsync(_Request, It.IsAny<IPresenter<GetUseCaseResponse>>(), _CancellationToken), Times.Once);
            _MockMapper.VerifyNoOtherCalls();
            _MockPersistenceContext.VerifyNoOtherCalls();
            _MockUseCaseInvoker.VerifyNoOtherCalls();
        }

        #endregion ReadAsync Tests

        #region - - - - - - UpdateAsync Tests - - - - - -

        [Fact]
        public async Task UpdateAsync_PresenterPresentedSuccessfully_SavesChanges()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _Command = "Command";
            var _Request = new GetUseCaseRequest();
            var _Result = new CreatedResult("", "Ok");

            var _MockMapper = new Mock<IMapper>();
            _MockMapper
                .Setup(mock => mock.Map<object>(_Command))
                .Returns(_Request);

            var _MockPersistenceContext = new Mock<IPersistenceContext>();

            var _MockUseCaseInvoker = new Mock<IUseCaseInvoker>();
            _MockUseCaseInvoker
                .Setup(mock => mock.InvokeUseCaseAsync(It.IsAny<GetUseCaseRequest>(), It.IsAny<IPresenter<GetUseCaseResponse>>(), It.IsAny<CancellationToken>()))
                .Returns((GetUseCaseRequest request, Presenter<GetUseCaseResponse> presenter, CancellationToken cancellationToken) =>
                {
                    presenter.PresentedSuccessfully = true;
                    presenter.Result = _Result;
                    return Task.CompletedTask;
                });
            var _ControllerAction = new ControllerAction(_MockMapper.Object, _MockPersistenceContext.Object, _MockUseCaseInvoker.Object);

            var _Expected = new CreatedResult("", "Ok");

            // Act
            var _Actual = await _ControllerAction.UpdateAsync<GetUseCaseRequest, GetUseCaseResponse>(_Command, _CancellationToken);

            // Assert
            _Actual.Should().BeEquivalentTo(_Expected);
            _MockMapper.Verify(mock => mock.Map<GetUseCaseRequest>(_Command), Times.Once);
            _MockPersistenceContext.Verify(mock => mock.SaveChangesAsync(_CancellationToken), Times.Once);
            _MockUseCaseInvoker.Verify(mock => mock.InvokeUseCaseAsync(_Request, It.IsAny<IPresenter<GetUseCaseResponse>>(), _CancellationToken), Times.Once);
            _MockMapper.VerifyNoOtherCalls();
            _MockPersistenceContext.VerifyNoOtherCalls();
            _MockUseCaseInvoker.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task UpdateAsync_PresenterDidNotPresentSuccessfully_DoesNotSaveChanges()
        {
            // Arrange
            var _CancellationToken = new CancellationToken();
            var _Command = "Command";
            var _Request = new GetUseCaseRequest();
            var _Result = new BadRequestObjectResult("Bad");

            var _MockMapper = new Mock<IMapper>();
            _MockMapper
                .Setup(mock => mock.Map<object>(_Command))
                .Returns(_Request);

            var _MockPersistenceContext = new Mock<IPersistenceContext>();

            var _MockUseCaseInvoker = new Mock<IUseCaseInvoker>();
            _MockUseCaseInvoker
                .Setup(mock => mock.InvokeUseCaseAsync(It.IsAny<GetUseCaseRequest>(), It.IsAny<IPresenter<GetUseCaseResponse>>(), It.IsAny<CancellationToken>()))
                .Returns((GetUseCaseRequest request, Presenter<GetUseCaseResponse> presenter, CancellationToken cancellationToken) =>
                {
                    presenter.PresentedSuccessfully = false;
                    presenter.Result = _Result;
                    return Task.CompletedTask;
                });

            var _ControllerAction = new ControllerAction(_MockMapper.Object, _MockPersistenceContext.Object, _MockUseCaseInvoker.Object);

            var _Expected = new BadRequestObjectResult("Bad");

            // Act
            var _Actual = await _ControllerAction.UpdateAsync<GetUseCaseRequest, GetUseCaseResponse>(_Command, _CancellationToken);

            // Assert
            _Actual.Should().BeEquivalentTo(_Expected);
            _MockMapper.Verify(mock => mock.Map<GetUseCaseRequest>(_Command), Times.Once);
            _MockUseCaseInvoker.Verify(mock => mock.InvokeUseCaseAsync(_Request, It.IsAny<IPresenter<GetUseCaseResponse>>(), _CancellationToken), Times.Once);
            _MockMapper.VerifyNoOtherCalls();
            _MockPersistenceContext.VerifyNoOtherCalls();
            _MockUseCaseInvoker.VerifyNoOtherCalls();
        }

        #endregion UpdateAsync Tests

        #region - - - - - - Support Classes - - - - - -

        private class GetUseCaseRequest : IUseCaseRequest<GetUseCaseResponse> { }

        private class GetUseCaseResponse { }

        #endregion Support Classes

    }

}
