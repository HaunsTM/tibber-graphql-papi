using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FakeHub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HubController : ControllerBase
    {

        [HttpGet]
        public string TakeAction(string device, string actionToPerform)
        {
            var message = $"{DateTime.Now} *FAKE HUB: * An action call [{actionToPerform}] were sent to device [{device}].";
            Console.WriteLine(message);
            return message;
        }
    }
}
