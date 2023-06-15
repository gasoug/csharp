﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers
{
    [Produces("application/json")]
    [ApiVersion("2.0")]
    [Route("api/v{apiVersion}/teste")]
    [ApiController]
    public class TesteV2Controller : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Content("<html><body><h2>TesteV2Controller - GET V 2.0</h2></body></html>", "text/html");
        }
    }
}
