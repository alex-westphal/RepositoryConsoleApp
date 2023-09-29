using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoldBadgeChallenge.Data.Entities.Enums;
namespace GoldBadgeChallenge.Data.Entities
{
    public class Delivery
    {
        public Delivery()
        {

        }
        public Delivery(DateTime orderDate, DateTime deliveryDate, int itemNumber, int itemQuantity, int customerId, OrderStatus orderStatus)
        {
            OrderDate = orderDate;
            DeliveryDate = deliveryDate;
            ItemNumber = itemNumber;
            ItemQuantity = itemQuantity;
            CustomerId = customerId;
            OrderStatus = orderStatus;
        }
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int ItemNumber { get; set; }
        public int ItemQuantity { get; set; }
        public int CustomerId { get; set; }

        public OrderStatus OrderStatus { get; set; }
    }
}