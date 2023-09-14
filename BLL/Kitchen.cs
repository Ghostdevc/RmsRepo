using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Kitchen
    {
        private static rmsDbEntities1 db = new rmsDbEntities1();

        public static void UpdateOrderStatus(tbl_order order)
        {
            if (order.Equals(null))
                return;
            if (order.order_status == "Ready" || order.order_status == "Cancelled")
            {
                int orderIDtoUpdate = order.order_id;
                var orderToUpdate = db.tbl_order.Find(orderIDtoUpdate);
                if (orderToUpdate.order_status == "Active")
                {
                    try
                    {
                        orderToUpdate.order_status = order.order_status;
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            else return;
        }


        /*
        public static List<tbl_order_has_meal> ListActiveOrders()
        {
            var orders = from order in db.tbl_order_has_meal
                               select new
                               {
                                   order.tbl_order.order_id,
                                   order.tbl_order.order_date,
                                   order.tbl_order.order_status,
                                   order.tbl_meals.meal_name,
                                   order.order_has_meal_amount
                               };
            
            List<tbl_order_has_meal> list =new List<tbl_order_has_meal>();
            foreach (tbl_order_has_meal order in orders)
            {
                if(order.tbl_order.order_status == "Active")
                {
                    list.Add(order);
                }
            }
            return list;
        }*/

    }
}
