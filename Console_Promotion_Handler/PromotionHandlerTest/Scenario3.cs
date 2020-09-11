using System;
using System.Collections.Generic;
using NUnit.Framework;
using PromotionHandler.Handlers;
using PromotionHandler.Model;

namespace PromotionHandlerTest
{
    [TestFixture]
    public class Scenario3
    {
        private IUnitPriceHandler unitPriceHandler;
        private IPromotionOfferHandler promotionOfferHandler;
        private IOrdersHandler ordersHandler;
        private PriceHandler priceHandler;
        [SetUp]
        public void ReplicateConstructor()
        {
            this.unitPriceHandler = new UnitPriceHandler();
            this.promotionOfferHandler = new PromotionOfferHandler();
            this.ordersHandler = new MockScenario3OrdersHandler();
            this.priceHandler = new PriceHandler();
        }
        [TestCase]
        public void TotalShouldBe280()
        {

            unitPriceHandler.CreateUnitPrice('A', 50);
            unitPriceHandler.CreateUnitPrice('B', 30);
            unitPriceHandler.CreateUnitPrice('C', 20);
            unitPriceHandler.CreateUnitPrice('D', 15);

            var unitPrices = unitPriceHandler.GetUnitPrices();

            var orders = ordersHandler.GetOrders();
            List<Promotion> promotions = promotionOfferHandler.DisplayPromptions();
            var totalPrice = priceHandler.CalculateOrderPrice(orders, promotions, unitPrices);
            Assert.AreEqual(280, totalPrice);
        }
    }
}
