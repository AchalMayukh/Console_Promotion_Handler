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
            //Create Unit Prices
            UnitPriceHandler.CreateUnitPrice('A', 50);
            UnitPriceHandler.CreateUnitPrice('B', 30);
            UnitPriceHandler.CreateUnitPrice('C', 20);
            UnitPriceHandler.CreateUnitPrice('D', 15);

            //Create Promotions
            Dictionary<char, int> sku1 = new Dictionary<char, int>();
            sku1.Add('A', 3);
            
            PromotionOfferHandler.CreatePromotion(sku1, 130);
            Dictionary<char, int> sku2 = new Dictionary<char, int>();
            sku2.Add('B', 2);
            PromotionOfferHandler.CreatePromotion(sku2, 45);
            Dictionary<char, int> sku3 = new Dictionary<char, int>();
            sku3.Add('C', 1);
            sku3.Add('D', 1);
            PromotionOfferHandler.CreatePromotion(sku3, 30);

            //Display Unit Prices
            var unitPrices = UnitPriceHandler.GetUnitPrices();
            Console.WriteLine("Unit Price for SKU IDs\n");
            foreach (var unitPrice in unitPrices)
            {
                Console.WriteLine(unitPrice.skuid + "\t" + unitPrice.price);
            }

            //Display Promotions
            List<Promotion> promotions = PromotionOfferHandler.DisplayPromptions();

            //Get orders
            var orders = OrdersHandler.GetOrders();


            //Calculate And Display Price
            PriceHandler.CalculateOrderPrice(orders, promotions) ;




        }

    }

}
