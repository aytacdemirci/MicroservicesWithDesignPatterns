using MassTransit;
using Shared.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailService.Consumers
{
    public class OrderCancelledConsumer : IConsumer<OrderCancelled>
    {
        public OrderCancelledConsumer()
        {
           
        }

        public async Task Consume(ConsumeContext<OrderCancelled> context)
        {
        }
    }
}
