using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events
{
    public class OrderCreated
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
