using PromotionHandler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionHandler.Handlers
{
    public class MockScenario2OrdersHandler:IOrdersHandler
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
            order1.quantity = 5;
            order2.SKUID = 'B';
            order2.quantity = 5;
            order3.SKUID = 'C';
            order3.quantity = 1;
            orders.Add(order1);
            orders.Add(order2);
            orders.Add(order3);
            return orders;
        }



    
}
}
