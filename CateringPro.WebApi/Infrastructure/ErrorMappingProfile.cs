using AutoMapper;
using CateringPro.Domain.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Text.Json;

namespace CateringPro.WebApi.Infrastructure
{

    public class ErrorMappingProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public ErrorMappingProfile()
        {
            this.AddAutoMapperMappingExceptionMapping();
            this.AddInvalidEnumExceptionMapping();
            this.AddValidationExceptionMapping();
        }

        #endregion Constructors

        #region - - - - - - Methods - - - - - -

        private void AddAutoMapperMappingExceptionMapping()
        {
            this.CreateMap<AutoMapperMappingException, ValidationProblemDetails>()
                .ConvertUsing((amme, vpd) =>
                {
                    var _Details = new ValidationProblemDetails
                    {
                        Status = (int)HttpStatusCode.BadRequest,
                        Title = "One or more validation errors occurred.",
                        Type = "https://httpstatuses.com/400"
                    };

                    if (amme.InnerException is JsonException jsonException)
                        _Details.Errors.Add($"{amme.MemberMap.DestinationName}{jsonException.Path.TrimStart('$')}", new string[] { amme.InnerException.Message });

                    else
                        _Details.Errors.Add(amme.MemberMap.DestinationName, new string[] { amme.InnerException.Message });

                    return _Details;
                });
        }

        private void AddInvalidEnumExceptionMapping()
        {
            this.CreateMap<InvalidEnumException, ValidationProblemDetails>()
                .ConvertUsing((iee, vpd) =>
                {
                    var _Details = new ValidationProblemDetails
                    {
                        Detail = iee.Message,
                        Status = (int)HttpStatusCode.BadRequest,
                        Title = iee.Message,
                        Type = "https://httpstatuses.com/400"
                    };
                    _Details.Errors.Add(string.Empty, new string[] { iee.Message });
                    return _Details;
                });
        }

        private void AddValidationExceptionMapping()
        {
            this.CreateMap<ValidationException, ValidationProblemDetails>()
                .ConvertUsing((ve, vpd) =>
                {
                    var _Details = new ValidationProblemDetails
                    {
                        Detail = ve.Message,
                        Status = (int)HttpStatusCode.BadRequest,
                        Title = ve.Message,
                        Type = "https://httpstatuses.com/400"
                    };

                    foreach (var _ErrorsByProperty in ve.Errors.GroupBy(e => e.PropertyName))
                        _Details.Errors.Add(_ErrorsByProperty.Key, _ErrorsByProperty.Select(e => e.ErrorMessage).ToArray());

                    return _Details;
                });
        }

        #endregion Methods

    }

}