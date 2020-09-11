using PromotionHandler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionHandler.Handlers
{
    public class MockScenario1OrdersHandler : IOrdersHandler
    {
        
        public Order GetOrder()
        {
            Order order = new Order();
            order.SKUID = 'A';
            order.quantity = 5;
            return order;
        }

        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();
            Order order1 = new Order();
            Order order2 = new Order();
            Order order3 = new Order();

            order1.SKUID = 'A';
            order1.quantity = 1;
            order1.price = 0;
            order1.processed = false;
            order2.SKUID = 'B';
            order2.quantity = 1;
            order2.price = 0;
            order2.processed = false;
            order3.SKUID = 'C';
            order3.quantity = 1;
            order3.price = 0;
            order3.processed = false;
            orders.Add(order1);
            orders.Add(order2);
            orders.Add(order3);
            return orders;
        }



    }
}
