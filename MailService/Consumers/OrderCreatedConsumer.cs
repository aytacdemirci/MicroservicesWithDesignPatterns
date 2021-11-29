using MailService.Data;
using MailService.Model;
using MassTransit;
using Shared.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailService.Consumers
{
    public class OrderCreatedConsumer : IConsumer<OrderCreated>
    {
        private readonly MailDbContext _dbContext;
        
        public OrderCreatedConsumer(MailDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Consume(ConsumeContext<OrderCreated> context)
        {
            OrderCreated orderCreated = context.Message;
            if (await _dbContext.HasBeenProcessed(orderCreated.OrderId, nameof(OrderCreatedConsumer)))
            {
                return;
            }

            using (var trx = await _dbContext.Database.BeginTransactionAsync())
            {
                await _dbContext.Mails.AddAsync(new Mail
                {
                    OrderId = orderCreated.OrderId,
                    OrderDate = DateTime.UtcNow
                });
                await _dbContext.SaveChangesAsync();

                await _dbContext.IdempotentConsumer(orderCreated.OrderId, nameof(OrderCreatedConsumer));

                await trx.CommitAsync();
            }
        }

    }
}
