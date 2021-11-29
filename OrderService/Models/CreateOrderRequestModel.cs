using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Models
{
    public class CreateOrderRequestModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
