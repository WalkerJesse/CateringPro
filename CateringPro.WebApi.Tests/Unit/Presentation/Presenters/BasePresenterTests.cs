using AutoMapper;
using CateringPro.Application.Infrastructure.Authorisation;
using CateringPro.Application.Infrastructure.Validation;
using CateringPro.WebApi.Presentation.Presenters;
using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CateringPro.WebApi.Tests.Unit.Presentation.Presenters
{

    public class BasePresenterTests
    {

        #region - - - - - - Fields - - - - - -

        private readonly Mock<IMapper> m_MockMapper = new();

        private readonly CleanValidationResult m_CleanValidationResult = new(new List<ValidationFailure>());
        private readonly AuthorisationResult m_AuthorisationResult = new();
        private readonly TestPresenter m_Presenter;
        private readonly ProblemDetails m_ProblemDetails = new();
        private readonly ValidationProblemDetails m_ValidationProblemDetails = new();

        #endregion Fields

        #region - - - - - - Constructors - - - - - -

        public BasePresenterTests()
        {
            this.m_Presenter = new(this.m_MockMapper.Object);

            this.m_MockMapper
                .Setup(mock => mock.Map<ValidationProblemDetails>(It.IsAny<CleanValidationResult>()))
                .Returns(this.m_ValidationProblemDetails);

            this.m_MockMapper
                .Setup(mock => mock.Map<ProblemDetails>(It.IsAny<AuthorisationResult>()))
                .Returns(this.m_ProblemDetails);
        }

        #endregion Constructors

        #region - - - - - - PresentBusinessRuleValidationFailureAsync Tests - - - - - -

        [Fact]
        public async void PresentBusinessRuleValidationFailureAsync_ValidationFailure_PresentsBadRequestObjectResult()
        {
            // Arrange
            var _Expected = new BadRequestObjectResult(this.m_ValidationProblemDetails);

            // Act
            await this.m_Presenter.PresentBusinessRuleValidationFailureAsync(this.m_CleanValidationResult, default);

            // Assert
            this.m_Presenter.Result.Should().BeEquivalentTo(_Expected);

            this.m_MockMapper.Verify(mock => mock.Map<ValidationProblemDetails>(this.m_CleanValidationResult));
        }

        #endregion PresentBusinessRuleValidationFailureAsync Tests

        #region - - - - - - PresentUnauthenticatedAsync Tests - - - - - -

        [Fact]
        public async void PresentUnauthenticatedAsync_Invoked_PresentsUnauthorizedResult()
        {
            // Arrange
            var _Expected = new UnauthorizedResult();

            // Act
            await this.m_Presenter.PresentUnauthenticatedAsync(default);

            // Assert
            this.m_Presenter.Result.Should().BeEquivalentTo(_Expected);
        }

        #endregion PresentUnauthenticatedAsync Tests

        #region - - - - - - PresentUnauthorisedAsync Tests - - - - - -

        [Fact]
        public async void PresentUnauthorisedAsync_Invoked_PresentsUnauthorizedObjectResult()
        {
            // Arrange
            var _Expected = new UnauthorizedObjectResult(this.m_ProblemDetails);

            // Act
            await this.m_Presenter.PresentUnauthorisedAsync(this.m_AuthorisationResult, default);

            // Assert
            this.m_Presenter.Result.Should().BeEquivalentTo(_Expected);
        }

        #endregion PresentUnauthorisedAsync Tests

        #region - - - - - - PresentValidationFailureAsync Tests - - - - - -

        [Fact]
        public async void PresentValidationFailureAsync_ValidationFailure_PresentsBadRequestObjectResult()
        {
            // Arrange
            var _Expected = new BadRequestObjectResult(this.m_ValidationProblemDetails);

            // Act
            await this.m_Presenter.PresentValidationFailureAsync(this.m_CleanValidationResult, default);

            // Assert
            this.m_Presenter.Result.Should().BeEquivalentTo(_Expected);

            this.m_MockMapper.Verify(mock => mock.Map<ValidationProblemDetails>(this.m_CleanValidationResult));
        }

        #endregion PresentValidationFailureAsync Tests

        #region - - - - - - Nested Classes - - - - - -

        private class TestPresenter : BasePresenter
        {

            #region - - - - - - Constructors - - - - - -

            public TestPresenter(IMapper mapper) : base(mapper) { }

            #endregion Constructors

        }

        #endregion Nested Classes

    }

}
