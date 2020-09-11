using PromotionHandler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionHandler.Handlers
{
    public interface IUnitPriceHandler
    {
         void CreateUnitPrice(char sku, int price);
         List<UnitPrice> GetUnitPrices();
    }
}
