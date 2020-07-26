using AutoMapper;
using CateringPro.Application.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;

namespace CateringPro.WebApi.Infrastructure
{

    public class PresenterMappingProfile : Profile
    {

        #region - - - - - - Constructors - - - - - -

        public PresenterMappingProfile()
        {
            this.CreateMap<EntityRequest, ValidationProblemDetails>()
                 .ConvertUsing((er, vpd) =>
                 {
                     var _Details = new ValidationProblemDetails
                     {
                         Detail = string.Join(", ", er.Keys.Select(keys => $"{keys.PropertyName} ({keys.Value}) was not found)")),
                         Status = (int)HttpStatusCode.NotFound,
                         Title = "Entity not found",
                         Type = "https://httpstatuses.com/404"
                     };
                     er.Keys.ForEach(keys => _Details.Errors.Add(keys.PropertyName, new string[] { $"{keys.Value} was not found" }));

                     return _Details;
                 });

            this.CreateMap<ValidationResult, ValidationProblemDetails>()
                .ConvertUsing((vr, vpd) =>
                {
                    var _Details = new ValidationProblemDetails
                    {
                        Status = (int)HttpStatusCode.BadRequest,
                        Title = "Bad Request",
                        Type = "https://httpstatuses.com/400"
                    };
                    vr.Errors.ToList().ForEach(vf => _Details.Errors.Add(vf.PropertyName, new string[] { vf.ErrorMessage }));

                    return _Details;
                });
        }

        #endregion Constructors

    }

}
