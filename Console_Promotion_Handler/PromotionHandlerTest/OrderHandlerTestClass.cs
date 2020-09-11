using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionHandler;
using PromotionHandler.Handlers;
using PromotionHandler.Model;

namespace PromotionHandlerTest
{
    [TestClass]
    public class OrderHandlerTestClass
    {
        private  IOrdersHandler ordersHandler;
        List<Order> orders = new List<Order>();
        [TestInitialize]
        public void MockOrderHandler()
        {
            this.ordersHandler = new MockScenario1OrdersHandler();
        }

        [TestMethod]
        public void CanGetOrder()
        {
           var order = ordersHandler.GetOrder();
            Assert.IsNotNull(order);
        }

        [TestMethod]
        public void CanGetOrders()
        {
            var orders = ordersHandler.GetOrders();
            Assert.IsTrue(orders.Count >= 1);

        }
    }
}
