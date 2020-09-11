using PromotionHandler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionHandler.Handlers
{
    public class PromotionOfferHandler:IPromotionOfferHandler
    {
        static List<Promotion> promotions = new List<Promotion>();
        public  List<Promotion> GetPromotionsOffer()
        {
            return promotions;
        }
        public  void CreatePromotion(Dictionary<char,int> sku,int price)
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
        public  List<Promotion> DisplayPromptions()
        {
            var promotions = GetPromotionsOffer();
            return promotions;
        }
    }
}
