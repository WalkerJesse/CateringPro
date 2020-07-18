using AutoMapper;
using CateringPro.Application.Exceptions;
using CateringPro.Domain.Exceptions;
using CateringPro.WebApi.Services;
using FluentAssertions;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace CateringPro.WebApi.Tests.Unit.Services
{

    public class CustomExceptionFilterAttributeTests
    {

        #region - - - - - - OnException Tests - - - - - -

        [Fact]
        public void OnException_AggregateExceptionOfException_HandlesAsUncaughtException()
        {
            // Arrange
            var _MockMapper = new Mock<IMapper>();
            var _Filter = new CustomExceptionFilterAttribute(_MockMapper.Object);
            var _Exception = new AggregateException(new Exception("Message"));
            var _ExceptionContext = GetExceptionContext(_Exception);
            var _Expected = new JsonResult(new
            {
                Error = new[] { "One or more errors occurred. (Message)" },
                StackTrace = default(string)
            });

            // Act
            _Filter.OnException(_ExceptionContext);

            // Assert
            _MockMapper.VerifyNoOtherCalls();
            _ExceptionContext.HttpContext.Response.ContentType.Should().Be("application/json");
            _ExceptionContext.HttpContext.Response.StatusCode.Should().Be(500);
            _ExceptionContext.Result.Should().BeEquivalentTo(_Expected);
        }

        [Fact]
        public void OnException_AggregateExceptionOfBusinessRuleViolationException_HandlesAsBusinessRuleViolationException()
        {
            // Arrange
            var _Exception = new AggregateException(new BusinessRuleViolationException("Message"));
            var _ExceptionContext = GetExceptionContext(_Exception);
            var _ProblemDetails = new ValidationProblemDetails() { Detail = "Detail" };
            var _Expected = new JsonResult(_ProblemDetails);

            var _MockMapper = new Mock<IMapper>();
            _MockMapper.Setup(mock => mock.Map<ValidationProblemDetails>(_Exception.InnerException)).Returns(_ProblemDetails);

            var _Filter = new CustomExceptionFilterAttribute(_MockMapper.Object);

            // Act
            _Filter.OnException(_ExceptionContext);

            // Assert
            _MockMapper.Verify(mock => mock.Map<ValidationProblemDetails>(_Exception.InnerException));
            _ExceptionContext.HttpContext.Response.ContentType.Should().Be("application/json");
            _ExceptionContext.HttpContext.Response.StatusCode.Should().Be(400);
            _ExceptionContext.Result.Should().BeEquivalentTo(_Expected);
        }

        [Fact]
        public void OnException_HandleAutoMapperMappingExceptionWrappingInvalidEnumException_HandlesInvalidEnumException()
        {
            // Arrange
            var _Exception = new AutoMapperMappingException("Message", new InvalidEnumException("Message"));
            var _ExceptionContext = GetExceptionContext(_Exception);
            var _ProblemDetails = new ValidationProblemDetails() { Detail = "Detail" };
            var _Expected = new JsonResult(_ProblemDetails);

            var _MockMapper = new Mock<IMapper>();
            _MockMapper.Setup(mock => mock.Map<ValidationProblemDetails>(_Exception.InnerException)).Returns(_ProblemDetails);

            var _Filter = new CustomExceptionFilterAttribute(_MockMapper.Object);

            // Act
            _Filter.OnException(_ExceptionContext);

            // Assert
            _MockMapper.Verify(mock => mock.Map<ValidationProblemDetails>(_Exception.InnerException));
            _ExceptionContext.HttpContext.Response.ContentType.Should().Be("application/json");
            _ExceptionContext.HttpContext.Response.StatusCode.Should().Be(400);
            _ExceptionContext.Result.Should().BeEquivalentTo(_Expected);
        }

        [Fact]
        public void OnException_BusinessRuleViolationException_HandlesAsBusinessRuleViolationException()
        {
            // Arrange
            var _Exception = new BusinessRuleViolationException("Message");
            var _ExceptionContext = GetExceptionContext(_Exception);
            var _ProblemDetails = new ValidationProblemDetails() { Detail = "Detail" };
            var _Expected = new JsonResult(_ProblemDetails);

            var _MockMapper = new Mock<IMapper>();
            _MockMapper.Setup(mock => mock.Map<ValidationProblemDetails>(_Exception)).Returns(_ProblemDetails);

            var _Filter = new CustomExceptionFilterAttribute(_MockMapper.Object);

            // Act
            _Filter.OnException(_ExceptionContext);

            // Assert
            _MockMapper.Verify(mock => mock.Map<ValidationProblemDetails>(_Exception));
            _ExceptionContext.HttpContext.Response.ContentType.Should().Be("application/json");
            _ExceptionContext.HttpContext.Response.StatusCode.Should().Be(400);
            _ExceptionContext.Result.Should().BeEquivalentTo(_Expected);
        }

        [Fact]
        public void OnException_InvalidEnumException_HandlesAsInvalidEnumException()
        {
            // Arrange
            var _Exception = new InvalidEnumException("Message");
            var _ExceptionContext = GetExceptionContext(_Exception);
            var _ProblemDetails = new ValidationProblemDetails() { Detail = "Detail" };
            var _Expected = new JsonResult(_ProblemDetails);

            var _MockMapper = new Mock<IMapper>();
            _MockMapper.Setup(mock => mock.Map<ValidationProblemDetails>(_Exception)).Returns(_ProblemDetails);

            var _Filter = new CustomExceptionFilterAttribute(_MockMapper.Object);

            // Act
            _Filter.OnException(_ExceptionContext);

            // Assert
            _MockMapper.Verify(mock => mock.Map<ValidationProblemDetails>(_Exception));
            _ExceptionContext.HttpContext.Response.ContentType.Should().Be("application/json");
            _ExceptionContext.HttpContext.Response.StatusCode.Should().Be(400);
            _ExceptionContext.Result.Should().BeEquivalentTo(_Expected);
        }

        [Fact]
        public void OnException_NotFoundException_HandlesAsNotFoundException()
        {
            // Arrange
            var _Exception = new NotFoundException("resourceName", "key");
            var _ExceptionContext = GetExceptionContext(_Exception);
            var _ProblemDetails = new ProblemDetails() { Detail = "Detail" };
            var _Expected = new JsonResult(_ProblemDetails);

            var _MockMapper = new Mock<IMapper>();
            _MockMapper.Setup(mock => mock.Map<ProblemDetails>(_Exception)).Returns(_ProblemDetails);

            var _Filter = new CustomExceptionFilterAttribute(_MockMapper.Object);

            // Act
            _Filter.OnException(_ExceptionContext);

            // Assert
            _MockMapper.Verify(mock => mock.Map<ProblemDetails>(_Exception));
            _ExceptionContext.HttpContext.Response.ContentType.Should().Be("application/json");
            _ExceptionContext.HttpContext.Response.StatusCode.Should().Be(404);
            _ExceptionContext.Result.Should().BeEquivalentTo(_Expected);
        }

        [Fact]
        public void OnException_Exception_HandlesAsUncaughtException()
        {
            // Arrange
            var _MockMapper = new Mock<IMapper>();
            var _Filter = new CustomExceptionFilterAttribute(_MockMapper.Object);
            var _Exception = new Exception("Message");
            var _ExceptionContext = GetExceptionContext(_Exception);
            var _Expected = new JsonResult(new
            {
                Error = new[] { "Message" },
                StackTrace = default(string)
            });

            // Act
            _Filter.OnException(_ExceptionContext);

            // Assert
            _MockMapper.VerifyNoOtherCalls();
            _ExceptionContext.HttpContext.Response.ContentType.Should().Be("application/json");
            _ExceptionContext.HttpContext.Response.StatusCode.Should().Be(500);
            _ExceptionContext.Result.Should().BeEquivalentTo(_Expected);
        }

        [Fact]
        public void OnException_ValidationException_HandlesAsValidationException()
        {
            // Arrange
            var _Exception = new ValidationException("message");
            var _ExceptionContext = GetExceptionContext(_Exception);
            var _ProblemDetails = new ValidationProblemDetails() { Detail = "Detail" };
            var _Expected = new JsonResult(_ProblemDetails);

            var _MockMapper = new Mock<IMapper>();
            _MockMapper.Setup(mock => mock.Map<ValidationProblemDetails>(_Exception)).Returns(_ProblemDetails);

            var _Filter = new CustomExceptionFilterAttribute(_MockMapper.Object);

            // Act
            _Filter.OnException(_ExceptionContext);

            // Assert
            _MockMapper.Verify(mock => mock.Map<ValidationProblemDetails>(_Exception));
            _ExceptionContext.HttpContext.Response.ContentType.Should().Be("application/json");
            _ExceptionContext.HttpContext.Response.StatusCode.Should().Be(400);
            _ExceptionContext.Result.Should().BeEquivalentTo(_Expected);
        }


        private static ExceptionContext GetExceptionContext(Exception exception)
        {
            var _MockHttpResponse = new Mock<HttpResponse>();
            _MockHttpResponse.SetupProperty(mock => mock.ContentType);
            _MockHttpResponse.SetupProperty(mock => mock.StatusCode);

            var _MockHttpContext = new Mock<HttpContext>();
            _MockHttpContext.Setup(mock => mock.Response).Returns(_MockHttpResponse.Object);

            var _MockActionContext = new Mock<ActionContext>();
            _MockActionContext.Object.HttpContext = _MockHttpContext.Object;
            _MockActionContext.Object.RouteData = new RouteData();
            _MockActionContext.Object.ActionDescriptor = new ActionDescriptor();

            return new ExceptionContext(_MockActionContext.Object, new List<IFilterMetadata>())
            {
                Exception = exception,
                HttpContext = _MockHttpContext.Object
            };
        }

        #endregion OnException Tests

    }

}
