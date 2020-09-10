using PromotionHandler.Handlers;
using PromotionHandler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            var promotions = GetActivePromotions();
            var orders = OrdersHandler.GetOrders();
            

        }

        

}
