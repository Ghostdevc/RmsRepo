using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Order
    {
        public readonly static rmsDbEntities1 db = new rmsDbEntities1();

        public static List<tbl_meals> getProducts()
        {
            return db.tbl_meals.ToList();
        }

        public static tbl_meals getProduct(int meal_id)
        {
            var product = db.tbl_meals.Find(meal_id);
            return product;
        }

        public static tbl_packaged getPckProduct(int pck_id)
        {
            var product = db.tbl_packaged.Find(pck_id);
            return product;
        }
        public static List<tbl_packaged> getPckProducts()
        {
            return db.tbl_packaged.ToList();
        }

        /*public static List<tbl_order> getAllOrders()
        {
            var order = from Order in db.tbl_order
                        select new
                        {
                            Order.order_id,
                            Order.order_status,
                            Order.order_date,
                            Order.order_totalPrice,
                            Order.tbl_check.fk_table_id
                        };
            return order.ToList();
        }*/

        public static tbl_order getOrder(int order_id)
        {
            var order = db.tbl_order.Find(order_id);
            return order;
        }
        
        public static void createOrder(tbl_order order)
      {
            try
            {
              
                db.tbl_order.Add(order);
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }


        public static void editOrder(tbl_order order)
        {
            db.tbl_order.AddOrUpdate(order);
            db.SaveChanges();
        }

        public static void deleteProduct(tbl_meals meal)
        {
            db.tbl_meals.Remove(meal);
            db.SaveChanges();
        }

        public static void deletePckProduct(tbl_packaged pckgd)
        {
            db.tbl_packaged.Remove(pckgd);
            db.SaveChanges();
        }

        public static void createProduct(tbl_meals meal)
        {
            try
            {
                db.tbl_meals.Add(meal);
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
        
            }
        }

        public static void createPckProduct(tbl_packaged pckgd)
        {
            try
            {
                db.tbl_packaged.Add(pckgd);
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
      
            }
        }

        public static void updateProduct(tbl_meals meal)
        {
            db.tbl_meals.AddOrUpdate(meal);
            db.SaveChanges();
        }

        public static void updatePckProduct(tbl_packaged pckgd)
        {
            db.tbl_packaged.AddOrUpdate(pckgd);
            db.SaveChanges();
        }

        public static List<tbl_order> getOrders()
        {
            return db.tbl_order.ToList();
        }
       
    }
}
