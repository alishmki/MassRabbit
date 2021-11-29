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
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IPublishEndpoint publishEndpoint;
        private readonly ILogger<OrderController> logger;

        public OrderController(IPublishEndpoint publishEndpoint, ILogger<OrderController> logger)
        {
            this.publishEndpoint = publishEndpoint;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            await publishEndpoint.Publish<Order>(order);
            logger.LogInformation("order sent!");
            return Ok();
        }
    }
}
