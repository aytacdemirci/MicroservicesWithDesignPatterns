using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailService.Model
{
    public class IdempotentConsumer
    {
        public int Id { get; set; }
        public int MessageId { get; set; }
        public string Consumer { get; set; }
    }
}
