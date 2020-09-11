using PromotionHandler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionHandler.Handlers
{
    public class OrdersHandler : IOrdersHandler
    {

        List<Order> orders = new List<Order>();
        public  List<Order> GetOrders()
        {
            bool wantSomethingElse = true;

            Order order = GetOrder();
            orders.Add(order);

            do
            {
                bool valid = false;
                string input = null;
                while (!valid)
                {
                    Console.WriteLine("Do you need anything else?(Y/N)");
                    input = Console.ReadLine();
                    if (input != "Y" && input != "N")
                    {
                        valid = false;
                        Console.WriteLine("Invalid Input! Do you need anything else? (Y/N)");
                        continue;
                    }
                    else
                    {
                        valid = true;
                        break;
                    }

                }
                if (input == "Y")
                {
                    Order newOrder = GetOrder();
                    if (orders.Where(o=>o.SKUID==newOrder.SKUID).Count()>0)
                    {
                       var ord = orders.Where(o => o.SKUID == newOrder.SKUID).FirstOrDefault();
                        if (ord != null)
                            ord = newOrder;
                    }
                    else
                    {
                        orders.Add(newOrder);

                    }
                    wantSomethingElse = true;
                    continue;

                }
                else
                {
                    wantSomethingElse = false;
                    break;
                }

            } while (wantSomethingElse);
            return orders;
        }
        public  Order GetOrder()
        {
            Order order = new Order();
            string skuid = null;
            char[] SKUIDs = SKU.IDs;
            Console.Write("Please enter SKU ids out of given list to order: " + string.Join(",", SKUIDs) + "\n");

            bool validInput = false;
            while (!validInput)
            {
                skuid = Console.ReadLine();
                if (!SKUIDs.Contains(skuid.ToCharArray()[0]))
                {
                    validInput = false;
                    Console.WriteLine("Please select correct skuid");
                    continue;
                }
                else
                    break;
            }
            order.SKUID = skuid.ToCharArray()[0];
            Console.Write("Enter Quantity: ");
            order.quantity = Convert.ToInt32(Console.ReadLine());
            order.price = 0;
            order.processed = false;


            return order;
        }
       
    }
}

