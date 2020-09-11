using System;
using System.Collections.Generic;
using NUnit.Framework;
using PromotionHandler.Handlers;
using PromotionHandler.Model;

namespace PromotionHandlerTest
{
    [TestFixture]
    public class Scenario1
    {
        private IUnitPriceHandler unitPriceHandler;
        private  IPromotionOfferHandler promotionOfferHandler;
        private  IOrdersHandler ordersHandler;
        private PriceHandler priceHandler;
        [SetUp]
        public void ReplicateConstructor()
        {
            this.unitPriceHandler = new UnitPriceHandler() ;
            this.promotionOfferHandler = new PromotionOfferHandler();
            this.ordersHandler = new MockScenario1OrdersHandler();
            this.priceHandler = new PriceHandler();
        }
        [TestCase]
        public void TotalShouldBe100()
        {
            unitPriceHandler.CreateUnitPrice('A', 50);
            unitPriceHandler.CreateUnitPrice('B', 30);
            unitPriceHandler.CreateUnitPrice('C', 20);
            unitPriceHandler.CreateUnitPrice('D', 15);


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

            var unitPrices = unitPriceHandler.GetUnitPrices();

            var orders = ordersHandler.GetOrders();
            List<Promotion> promotions = promotionOfferHandler.DisplayPromptions();
            var totalPrice = priceHandler.CalculateOrderPrice(orders, promotions, unitPrices);
            Assert.AreEqual(100, totalPrice);
        }
    }
}
