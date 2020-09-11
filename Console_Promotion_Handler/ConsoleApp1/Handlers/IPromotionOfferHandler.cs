using PromotionHandler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionHandler.Handlers
{
    public interface IPromotionOfferHandler
    {
        List<Promotion> GetPromotionsOffer();
        void CreatePromotion(Dictionary<char, int> sku, int price);
        List<Promotion> DisplayPromptions();
    }
}
