using PromotionHandler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionHandler.Handlers
{
    class OrdersHandler
    {
        public static IDictionary<char, int> GetOrders()
        {
            Dictionary<char, int> orders = new Dictionary<char, int>();
            bool wantSomethingElse = true;

            Order order = GetOrder();
            orders.Add(order.SKUID, order.quantity);

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
                    if (orders.ContainsKey(newOrder.SKUID))
                    {
                        orders[newOrder.SKUID] += newOrder.quantity;
                    }
                    else
                    {
                        orders.Add(newOrder.SKUID, newOrder.quantity);

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
        public static Order GetOrder()
        {
            Order order = new Order();
            string skuid = null;
            char[] SKUIDs = Enumerable.Range('A', 'Z' - 'A' + 1).Select(i => ((char)i)).ToArray();
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


            return order;
        }
    }
}

