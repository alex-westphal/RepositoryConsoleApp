using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoldBadgeChallenge.Data.Entities;
using GoldBadgeChallenge.Data.Entities.Enums;
namespace GoldBadgeChallenge.Repository
{
    public class DeliveryRepository
    {


        protected readonly List<Delivery> _contentDb = new List<Delivery>();
        private int _count;
        public DeliveryRepository()
        {
            Seed();
        }
        private void Seed()
        {
            Delivery delivery1 = new Delivery(new DateTime(2023, 09, 25), new DateTime(2023, 09, 27), 1, 10, 1000, OrderStatus.Complete);
            Delivery delivery2 = new Delivery(new DateTime(2023, 09, 25), new DateTime(2023, 09, 27), 1, 03, 1002, OrderStatus.Enroute);
            Delivery delivery3 = new Delivery(new DateTime(2023, 09, 20), new DateTime(2023, 09, 27), 1, 03, 1002, OrderStatus.Enroute);
            Delivery delivery4 = new Delivery(new DateTime(2023, 09, 18), new DateTime(2023, 09, 27), 1, 03, 1001, OrderStatus.Enroute);
            Delivery delivery5 = new Delivery(new DateTime(2023, 09, 18), new DateTime(2023, 09, 18), 1, 03, 1001, OrderStatus.Cancelled);
            AddDelivery(delivery1);
            AddDelivery(delivery2);
            AddDelivery(delivery3);
            AddDelivery(delivery4);
            AddDelivery(delivery5);
        }
        //Create
        public bool AddDelivery(Delivery delivery)
        {
            if (delivery is null)
            {
                return false;
            }
            else
            {
                _count++;
                delivery.Id = _count;
                _contentDb.Add(delivery);
                return true;
            }
        }
        public Delivery GetDeliveryById(int id)
        {
            foreach (Delivery delivery in _contentDb)
            {
                if (delivery.Id == id)
                {
                    return delivery;
                }
            }
            return null;
        }
        public bool UpdateRouteStatus(int id, OrderStatus orderStatus)
        {
            Delivery deliveryInDb = GetDeliveryById(id);
            if (deliveryInDb != null)
            {
                deliveryInDb.OrderStatus = orderStatus;
                return true;
            }
            return false;
        }

        public bool RemoveDeliveryFromList(Delivery delivery)
        {
            return _contentDb.Remove(delivery);
        }

        public List<Delivery> GetDeliveriesByOrderStatus(OrderStatus orderStatus)
        {
            //*OrderStatus Order = GetDeliveryById(deliveryId);
            List<Delivery> deliveriesByOrderStatus = new List<Delivery>();

            foreach (Delivery delivery in _contentDb)
            {
                if (delivery.OrderStatus == orderStatus)
                {
                    deliveriesByOrderStatus.Add(delivery);
                }
            }

            return deliveriesByOrderStatus;
        }

        public List<Delivery> GetDeliveries()
        {
            return _contentDb;
        }
    }
}

