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
            IUnitPriceHandler unitPriceHandler = new UnitPriceHandler();
            IPromotionOfferHandler promotionOfferHandler = new PromotionOfferHandler();
            IOrdersHandler ordersHandler = new OrdersHandler();
            PriceHandler priceHandler = new PriceHandler();
            //Create Unit Prices
            unitPriceHandler.CreateUnitPrice('A', 50);
            unitPriceHandler.CreateUnitPrice('B', 30);
            unitPriceHandler.CreateUnitPrice('C', 20);
            unitPriceHandler.CreateUnitPrice('D', 15);

            //Create Promotions
            Dictionary<char, int> sku1 = new Dictionary<char, int>();
            sku1.Add('A', 3);
            promotionOfferHandler.CreatePromotion(sku1, 130);
            Dictionary<char, int> sku2 = new Dictionary<char, int>();
            sku2.Add('B', 2);
            promotionOfferHandler.CreatePromotion(sku2, 45);
            Dictionary<char, int> sku3 = new Dictionary<char, int>();
            sku3.Add('C', 1);
            sku3.Add('D', 1);
            promotionOfferHandler.CreatePromotion(sku3, 30);

            //Display Unit Prices
            var unitPrices = unitPriceHandler.GetUnitPrices();
            Console.WriteLine("Unit Price for SKU IDs\n");
            foreach (var unitPrice in unitPrices)
            {
                Console.WriteLine(unitPrice.skuid + "\t" + unitPrice.price);
            }

            //Display Promotions
            List<Promotion> promotions = promotionOfferHandler.DisplayPromptions();
            int i = 0;
            Console.WriteLine("Active Promotions");
            foreach (Promotion promotion in promotions)
            {
                Console.WriteLine(i.ToString() + ": " + promotion.deal);
                i++;
            }
            //Get orders
            var orders = ordersHandler.GetOrders();


            //Calculate And Display Price
            int totalPrice =  priceHandler.CalculateOrderPrice(orders, promotions,unitPrices) ;
            Console.WriteLine("Total \t" + totalPrice.ToString());
            Console.ReadLine();




        }

    }

}
