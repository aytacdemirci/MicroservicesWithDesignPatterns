using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Events
{
    public class RabbitMQSettingsConst
    {
        public const string StockReservedEventQueueName = "stock-reserved-event";

        public const string StockOrderCreatedEventQueueName = "stock-order-created-event";

        public const string StockPaymentFailedEventQueueName = "stock-payment-failed-event";

        public const string OrderPaymentCompletedEventQueueName = "order-payment-completed-event";
        public const string OrderPaymentFailedEventQueueName = "order-payment-failed-queue";
        public const string OrderStockNotReservedEventQueueName = "order-stock-not-reserved-event";
    }
}
