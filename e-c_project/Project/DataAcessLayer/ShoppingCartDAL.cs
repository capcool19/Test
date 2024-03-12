using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcessLayer.Models;

namespace DataAcessLayer
{
    public class ShoppingCartDAL
    {
        ProjectEntities db = new ProjectEntities();
        public bool CheckOut(Order order,List<Cart> lstCart)
        {
            bool check = false;
            var userOrder = new Order()
            {
                CustomerName = order.CustomerName,
                CustomerPhone = order.CustomerPhone,
                CustomerEmail = order.CustomerEmail,
                CustomerAddress = order.CustomerAddress,
                OrderDate = DateTime.Now,
                PaymentType ="Cash",
                Status="Processing"
            };
            try
            {
                db.Orders.Add(userOrder);
                db.SaveChanges();
                check = true;
            }
            catch
            {
                check=false;
            }
            foreach(Cart cart in lstCart)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    OrderId = userOrder.OrderId,
                    ProductId = cart.Product.ProductId,
                    Quantity = cart.Quantity,
                    Price = cart.Product.Price
                };
                try
                {
                    db.OrderDetails.Add(orderDetail);
                    db.SaveChanges();
                    check = true;
                }
                catch(Exception)
                {
                    check = false;
                }
            }
            return check;
        }
    }
}
