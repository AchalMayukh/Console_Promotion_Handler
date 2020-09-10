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
            int i = 1;
            UnitPriceHandler.CreateUnitPrice('A', 50);
            Dictionary<char, int> sku = new Dictionary<char, int>();
            sku.Add('A', 3);

            PromotionOfferHandler.CreatePromotion(sku, 130);
            Dictionary<char, int> sku2 = new Dictionary<char, int>();
            sku2.Add('C', 1);
            sku2.Add('D', 1);
            PromotionOfferHandler.CreatePromotion(sku2, 30);

            var unitPrices = UnitPriceHandler.GetUnitPrices();
            Console.WriteLine("Unit Price for SKU IDs\n");
            foreach (var unitPrice in unitPrices)
            {
                Console.WriteLine(unitPrice.skuid + "\t" + unitPrice.price);
            }
            var promotions = PromotionOfferHandler.GetPromotionsOffer();
            Console.WriteLine("Active Promotions");
            foreach (Promotion promotion in promotions)
            {
                Console.WriteLine(i.ToString() + ": " + promotion.deal);
                i++;
            }
            Console.WriteLine("Choose only one offer by id (1,2...)");
            var promotionId = Console.ReadLine();
            var orders = OrdersHandler.GetOrders();
            var totalPrice = PriceHandler.CalculateOrderPrice(orders);




        }

    }

}
