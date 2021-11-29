using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderService.Controllers
{   
    public class SendController : Controller
    {
        private readonly ISendEndpointProvider sendEndpointProvider;
        private readonly ILogger<SendController> logger;

        public SendController(ISendEndpointProvider sendEndpointProvider, ILogger<SendController> logger)
        {
            this.sendEndpointProvider = sendEndpointProvider;
            this.logger = logger;
        }

        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            var _serviceAddress = new Uri("rabbitmq://localhost/test1");
            var endpoint = await sendEndpointProvider.GetSendEndpoint(_serviceAddress);
            await endpoint.Send(order);
            logger.LogInformation("order sent!");
            return Ok();
        }
    }
}
