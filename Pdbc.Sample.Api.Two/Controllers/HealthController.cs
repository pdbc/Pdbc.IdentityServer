using System;
using Microsoft.AspNetCore.Mvc;

namespace Pdbc.Sample.Api.Two.Controllers
{
    [Route("health")]
    public class HealthController : ControllerBase
    {
        public String Get()
        {
            return "All running";
        }
    }
}