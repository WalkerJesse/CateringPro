using CateringPro.WebApi.Services.Attributes;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CateringPro.WebApi.Controllers
{

    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[Controller]")]
    [TypeFilter(typeof(CustomExceptionFilterAttribute))]
    public class BaseController : ControllerBase
    {

    }

}
