using PromotionHandler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionHandler.Handlers
{
    class UnitPriceHandler
    {
        static List<UnitPrice> unitPrices = new List<UnitPrice>();
        public static void CreateUnitPrice(char sku, int price)
        {
            UnitPrice unitPrice = new UnitPrice();
            unitPrice.skuid = sku;
            unitPrice.price = price;
            unitPrices.Add(unitPrice);
        }
        public static List<UnitPrice> GetUnitPrices()
        {
            return unitPrices;
        }
    }
}
