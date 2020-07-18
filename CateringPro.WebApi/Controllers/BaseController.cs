using CateringPro.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CateringPro.WebApi.Controllers
{

    [Produces(MediaTypeNames.Application.Json)]
    [Route("api/[Cntroller]")]
    [TypeFilter(typeof(CustomExceptionFilterAttribute))]
    public class BaseController : ControllerBase
    {

    }

}
