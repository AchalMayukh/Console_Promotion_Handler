using PromotionHandler.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionHandler.Handlers
{
    class PriceHandler
    {
        public static void CalculateOrderPrice(List<Order> orders,List<Promotion> promotions)
        {
            List<UnitPrice> unitPrices = UnitPriceHandler.GetUnitPrices();
            int totalPrice = 0;
            foreach (var order in orders)
            {
                int price = 0;
                List<Promotion> applicablePromotions = new List<Promotion>();
                //check for order.sku if promotions has multiple enteries
                foreach (var promotion in promotions)
                {
                    if(promotion.sku.ContainsKey(order.SKUID))
                    {
                        if(promotion.sku.Count()>1)
                        {
                            int i = 0;
                            foreach (var skuitem in promotion.sku)
                            {
                                if(orders.Where(o => o.SKUID == skuitem.Key).FirstOrDefault()!=null)
                                {

                                    if (orders.Where(o => o.SKUID == skuitem.Key).FirstOrDefault().quantity >= 1)
                                    {
                                        i++;
                                    }
                                }
                                
                            }
                            if(i== promotion.sku.Count())
                            {

                                applicablePromotions.Add(promotion);
                            }
                            
                        }
                        else
                        {
                            if (order.quantity >= promotion.sku[order.SKUID])
                            {
                                applicablePromotions.Add(promotion);
                            }
                        }
                            
                    }
                }

                //Calculate Price after applying promotions
                if(applicablePromotions.Count>0)
                {
                    foreach(var applicablePromotion in applicablePromotions)
                    {
                        if (applicablePromotion.sku.Keys.Count() > 1)
                        {
                            List<Order> selectedOrders = new List<Order>();
                            foreach (var item in applicablePromotion.sku)
                            {
                                selectedOrders.Add(orders.Where(o => o.SKUID == item.Key &&!o.processed).FirstOrDefault());
                                
                            }
                           for(int j = 0; j<selectedOrders.Count()-1;j++)
                            {
                                if(selectedOrders[j]!=null &&selectedOrders[j+1]!=null)
                                {
                                    if (selectedOrders[j].quantity <= selectedOrders[j + 1].quantity)
                                    {
                                        selectedOrders[j].price += applicablePromotion.price * selectedOrders[j].quantity;
                                        selectedOrders[j + 1].price += unitPrices.Where(o => o.skuid == selectedOrders[j + 1].SKUID).FirstOrDefault().price *
                                            (selectedOrders[j].quantity - selectedOrders[j + 1].quantity);
                                        selectedOrders[j].processed = true;
                                        selectedOrders[j + 1].processed = true;
                                    }
                                    else
                                    {
                                        selectedOrders[j + 1].price += applicablePromotion.price * selectedOrders[j + 1].quantity;
                                        selectedOrders[j].price += unitPrices.Where(o => o.skuid == selectedOrders[j].SKUID).FirstOrDefault().price *
                                            (selectedOrders[j + 1].quantity - selectedOrders[j].quantity);
                                        selectedOrders[j].processed = true;
                                        selectedOrders[j + 1].processed = true;
                                    }
                                }
                               
                            }
                        }
                        else
                        {
                            if ((order.quantity % applicablePromotion.sku[order.SKUID]) != 0)
                            {
                                for (int j = 0; j <= order.quantity ; j++) //Fix % applicablePromotion.sku[order.SKUID]

                               {
                                    if(j>1&&j % applicablePromotion.sku[order.SKUID]==0)
                                    order.price += applicablePromotion.price;
                                }
                                order.price += unitPrices.Where(unitPrice => unitPrice.skuid == order.SKUID).FirstOrDefault().price * (order.quantity % applicablePromotion.sku[order.SKUID]);
                               
                            }
                            else
                            {
                                for (int j = 0; j < order.quantity / applicablePromotion.sku[order.SKUID]; j++)
                                {
                                    order.price += applicablePromotion.price;
                                }
                            }

                            order.processed = true;

                        }

                    }
                    
                }
                else
                {
                    order.price = unitPrices.Where(unitPrice=>unitPrice.skuid==order.SKUID).FirstOrDefault().price * order.quantity;
                    order.processed = true;
                }

                
            }
            totalPrice = orders.Select(t => t.price).Sum();
            Console.WriteLine("Total \t"+totalPrice.ToString());
            Console.ReadLine();
        }
    }
}
