using System;
using Microsoft.AspNetCore.Mvc;

namespace Pdbc.Sample.Api.One.Controllers
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