using PromotionHandler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionHandler.Handlers
{
    class PromotionOfferHandler
    {
        static List<Promotion> promotions = new List<Promotion>();
        public static List<Promotion> GetPromotionsOffer()
        {
            return promotions;
        }
        public static void CreatePromotion(Dictionary<char,int> sku,int price)
        {
            string dealDisplay;
            Promotion promotion = new Promotion();
            promotion.sku = sku;
            promotion.price = price;
            if (sku.Count() > 1)
            {
                dealDisplay = string.Join("&", sku.Keys) + " for " + price.ToString();
            }
            else
                dealDisplay = sku.Values.FirstOrDefault().ToString() + " of " + sku.Keys.FirstOrDefault().ToString() + "'s for " + price.ToString();

            promotion.deal = dealDisplay;
            promotions.Add(promotion);

        }
        public static List<Promotion> DisplayPromptions()
        {
            int i = 1;
            var promotions = PromotionOfferHandler.GetPromotionsOffer();
            Console.WriteLine("Active Promotions");
            foreach (Promotion promotion in promotions)
            {
                Console.WriteLine(i.ToString() + ": " + promotion.deal);
                i++;
            }

            //bool validPromotion = false;
            //Promotion selectedPromotion = null;
            //do
            //{
            //    Console.WriteLine("Choose only one offer by valid id (1,2...)");
            //    var promotionId = Console.ReadLine();
            //    if (Convert.ToInt32(promotionId) < i && Convert.ToInt32(promotionId) > 0)
            //    {
            //        selectedPromotion = promotions[Convert.ToInt32(promotionId) - 1];
            //        validPromotion = true;
            //        break;
            //    }
            //    else
            //    {
            //        validPromotion = false;
            //        continue;
            //    }
            //} while (!validPromotion);

            return promotions;
        }
    }
}
