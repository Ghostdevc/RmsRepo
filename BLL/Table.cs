using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Table
    {
        public static readonly rmsDbEntities1 db = new rmsDbEntities1();
        public static bool isBusy(tbl_tables table)
        {
            if (table.table_status == "Busy")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool isTableHasUnpaidCheck(tbl_tables table)
        {
            var check = db.tbl_check.Where(x => x.fk_table_id == table.table_id).ToList();

            foreach (tbl_check item in check)
            {
                if (item.isPaid == "false")
                {
                    return true;
                }
            }
            return false ;
        }

        public static int getTablesHasUnpaidCheck(tbl_tables table)
        {
            var check = db.tbl_check.Where(x => x.fk_table_id == table.table_id).ToList();

            foreach (tbl_check item in check)
            {
                if (item.isPaid == "false")
                {
                    return item.check_id;
                }
            }
            
            return 0;
        }





    }
}
