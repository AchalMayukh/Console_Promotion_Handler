using PromotionHandler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionHandler.Handlers
{
    class PriceHandler
    {
        public static int CalculateOrderPrice(Dictionary<char,int> orders)
        {
            int totalPrice = 0;
            foreach (var order in orders)
            {
                totalPrice += UnitPrice.GetPrices()[order.Key] * order.Value;
            }
            return totalPrice;
        }
    }
}
