using MassTransit;
using Microsoft.Extensions.Logging;
using Model;
using System;
using System.Threading.Tasks;

namespace InventoryService
{
    internal class InvoiceConsumer : IConsumer<Invoice>
    {
        private readonly ILogger<InvoiceConsumer> logger;

        public InvoiceConsumer(ILogger<InvoiceConsumer> logger)
        {
            this.logger = logger;
        }


        public async Task Consume(ConsumeContext<Invoice> context)
        {
            await Console.Out.WriteLineAsync(context.Message.Name);
            logger.LogInformation($">>>>>>>>>>>>Invoice: {context.Message.Name}");
        }

    }
}