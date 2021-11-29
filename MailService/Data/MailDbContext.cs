using MailService.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailService.Data
{
    public class MailDbContext:DbContext
    {
        public MailDbContext(DbContextOptions<MailDbContext> option):base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdempotentConsumer>()
                 .ToTable("IdempotentConsumers")
                 .HasKey(x => new { x.MessageId, x.Consumer });

            base.OnModelCreating(modelBuilder); base.OnModelCreating(modelBuilder);
        }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<IdempotentConsumer> IdempotentConsumers { get; set; }

        public async Task<bool> HasBeenProcessed(int messageId, string consumer)
        {
            return await IdempotentConsumers.AnyAsync(x => x.MessageId == messageId && x.Consumer == consumer);
        }

        public async Task IdempotentConsumer(int messageId, string consumer)
        {
            await IdempotentConsumers.AddAsync(new IdempotentConsumer
            {
                MessageId = messageId,
                Consumer = consumer
            });
            await SaveChangesAsync();
        }
    }
}
