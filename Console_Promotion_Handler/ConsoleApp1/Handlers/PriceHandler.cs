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
                totalPrice += UnitPriceHandler.GetUnitPrices().Where(t=>t.skuid==order.Key).Select(t=>t.price).FirstOrDefault()*order.Value;
            }
            return totalPrice;
        }
    }
}
