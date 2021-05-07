
using AutoMapper;
using CateringPro.Application.Services;
using CateringPro.WebApi.Services;
using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace CateringPro.WebApi.Tests.Unit.Services
{

    public class PresenterTests
    {

        #region - - - - - - PresentNotFoundAsync Tests - - - - - -

        [Fact]
        public async Task PresentNotFoundAsync_AnyNotFoundRequest_PresentsSuccessfully()
        {
            // Arrange
            var _EntityRequest = new EntityRequest();
            var _ValidationProblemDetails = new ValidationProblemDetails();

            var _MockMapper = new Mock<IMapper>();
            _MockMapper
                .Setup(mock => mock.Map<ValidationProblemDetails>(_EntityRequest))
                .Returns(_ValidationProblemDetails);

            var _Presenter = new Presenter(_MockMapper.Object);

            var _Expected = new Presenter(_MockMapper.Object)
            {
                PresentedSuccessfully = false,
                Result = new NotFoundObjectResult(_ValidationProblemDetails),
                ValidationError = true
            };

            // Act
            await _Presenter.PresentNotFoundAsync(_EntityRequest, CancellationToken.None);

            // Assert
            _Presenter.Should().BeEquivalentTo(_Expected);
            _MockMapper.Verify(mock => mock.Map<ValidationProblemDetails>(_EntityRequest), Times.Once);
            _MockMapper.VerifyNoOtherCalls();
        }

        #endregion PresentNotFoundAsync Tests

        #region - - - - - - PresentValidationFailureAsync Tests - - - - - -

        [Fact]
        public async Task PresentValidationFailureAsync_AnyValidationFailure_PresentsSuccessfully()
        {
            // Arrange
            var _ValidationFailure = new ValidationResult();
            var _ValidationProblemDetails = new ValidationProblemDetails();

            var _MockMapper = new Mock<IMapper>();
            _MockMapper
                .Setup(mock => mock.Map<ValidationProblemDetails>(_ValidationFailure))
                .Returns(_ValidationProblemDetails);

            var _Presenter = new Presenter(_MockMapper.Object);

            var _Expected = new Presenter(_MockMapper.Object)
            {
                PresentedSuccessfully = false,
                Result = new NotFoundObjectResult(_ValidationProblemDetails),
                ValidationError = true
            };

            // Act
            await _Presenter.PresentValidationFailureAsync(_ValidationFailure, CancellationToken.None);

            // Assert
            _Presenter.Should().BeEquivalentTo(_Expected);
            _MockMapper.Verify(mock => mock.Map<ValidationProblemDetails>(_ValidationFailure), Times.Once);
            _MockMapper.VerifyNoOtherCalls();
        }

        #endregion PresentValidationFailureAsync Tests

        #region - - - - - - Support Classes - - - - - -

        public class Presenter : Presenter<object>
        {

            public Presenter(IMapper mapper) : base(mapper)
            {
            }

            public override Task PresentAsync(object response, CancellationToken cancellationToken)
                => throw new System.NotImplementedException();

        }

        #endregion Support Classes

    }

    public class CreateCommandPresenterTests
    {

        #region - - - - - - PresentAsync Tests - - - - - -

        [Fact]
        public async Task PresentAsync_AnyRequest_PresentsSuccessfully()
        {
            // Arrange
            var _Response = "Response";
            var _ViewModel = "ViewModel";

            var _MockMapper = new Mock<IMapper>();

            var _Presenter = new CreateCommandPresenter<string, string>(_MockMapper.Object);

            var _Expected = new CreateCommandPresenter<string, string>(_MockMapper.Object)
            {
                PresentedSuccessfully = true,
                Result = new CreatedResult(string.Empty, _ViewModel)
            };

            // Act
            await _Presenter.PresentAsync(_Response, CancellationToken.None);

            // Assert
            _Presenter.Should().BeEquivalentTo(_Expected);
            _MockMapper.VerifyNoOtherCalls();
        }

        #endregion PresentAsync Tests

    }

    public class ReadQueryPresenterTests
    {

        #region - - - - - - PresentAsync Tests - - - - - -

        [Fact]
        public async Task PresentAsync_AnyRequest_PresentsSuccessfully()
        {
            // Arrange
            var _Response = "Response";
            var _ViewModel = "ViewModel";

            var _MockMapper = new Mock<IMapper>();
            _MockMapper
                .Setup(mock => mock.Map<string>(_Response))
                .Returns(_ViewModel);

            var _Presenter = new ReadQueryPresenter<string, string>(_MockMapper.Object);

            var _Expected = new ReadQueryPresenter<string, string>(_MockMapper.Object)
            {
                PresentedSuccessfully = true,
                Result = new OkObjectResult(_ViewModel)
            };

            // Act
            await _Presenter.PresentAsync(_Response, CancellationToken.None);

            // Assert
            _Presenter.Should().BeEquivalentTo(_Expected);
            _MockMapper.Verify(mock => mock.Map<string>(_Response), Times.Once);
            _MockMapper.VerifyNoOtherCalls();
        }

        #endregion PresentAsync Tests

    }

    public class UpdateCommandPresenterTests
    {

        #region - - - - - - PresentAsync Tests - - - - - -

        [Fact]
        public async Task PresentAsync_AnyRequest_PresentsSuccessfully()
        {
            // Arrange
            var _MockMapper = new Mock<IMapper>();

            var _Presenter = new UpdateCommandPresenter<string>(_MockMapper.Object);

            var _Expected = new UpdateCommandPresenter<string>(_MockMapper.Object)
            {
                PresentedSuccessfully = true,
                Result = new NoContentResult()
            };

            // Act
            await _Presenter.PresentAsync("Response", CancellationToken.None);

            // Assert
            _Presenter.Should().BeEquivalentTo(_Expected);
            _MockMapper.VerifyNoOtherCalls();
        }

        #endregion PresentAsync Tests

    }

}
