using DAL;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Check
    {
        public readonly static rmsDbEntities1 db = new rmsDbEntities1();
        public static void createCheck(ArrayList meal , ArrayList packaged , tbl_order order, tbl_check check , tbl_tables table)
        {
            db.tbl_tables.AddOrUpdate(table);
            //db.SaveChanges();

            db.tbl_check.Add(check);
            //db.SaveChanges();
            //int lastInsertedCheck = 0
            //check.check_id = db.tbl_check.LastOrDefault().check_id;
            order.fk_check_id = check.check_id;
            db.tbl_order.Add(order);
            //db.SaveChanges();
            foreach (tbl_order_has_meal item in meal)
            {
                item.fk_order_id = order.order_id;
                db.tbl_order_has_meal.Add(item);
                //db.SaveChanges() ;
            }
            foreach (tbl_order_has_pckgd item in packaged)
            {
                item.fk_order_id = order.order_id;
                db.tbl_order_has_pckgd.Add(item);
                //db.SaveChanges() ;
            }
            db.SaveChanges();
            
        }

        public static void updateCheck(ArrayList meal, ArrayList packaged, tbl_order order, int check_id, tbl_tables table)
        {
            try
            {
                tbl_check updatedCheck = new tbl_check();
                updatedCheck.check_id = check_id;
                double oldCheckPrice = double.Parse(db.tbl_check.Find(check_id).check_totalPrice.ToString());
                DateTime checkCreatedAt = db.tbl_check.Find(check_id).check_date.Value;
                updatedCheck.check_totalPrice = double.Parse(order.order_totalPrice.ToString()) + oldCheckPrice;
                updatedCheck.isPaid = "false";
                updatedCheck.fk_table_id = table.table_id;
                updatedCheck.check_date = checkCreatedAt;
                db.tbl_check.AddOrUpdate(updatedCheck);
                //db.SaveChanges();
                order.fk_check_id = check_id;
                db.tbl_order.Add(order);
                //db.SaveChanges();
                foreach (tbl_order_has_meal item in meal)
                {
                    item.fk_order_id = order.order_id;
                    db.tbl_order_has_meal.Add(item);
                    //db.SaveChanges();
                }
                foreach (tbl_order_has_pckgd item in packaged)
                {
                    item.fk_order_id = order.order_id;
                    db.tbl_order_has_pckgd.Add(item);
                    //db.SaveChanges();
                }

                db.tbl_tables.AddOrUpdate(table);
                db.SaveChanges();

            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
              
            }
        }

    }
}
