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

    public class PublishController : Controller
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ILogger<PublishController> logger;

        public PublishController(IPublishEndpoint publishEndpoint, ILogger<PublishController> logger)
        {
            this.publishEndpoint = publishEndpoint;
            this.logger = logger;
        }

        [HttpPost]
        [Route("publish")]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            await publishEndpoint.Publish<Order>(order);
            logger.LogInformation("order sent!");
            return Ok();
        }
    }
}
