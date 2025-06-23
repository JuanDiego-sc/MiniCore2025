using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
    }
}
