using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace DAL
{
    public partial class tbl_meals
    {
        public override string ToString()
        {
            return String.Format("{0} - {1} - {2:C2}",meal_id,meal_name,meal_price);

        }
    }

    public partial class tbl_packaged
    {
        public override string ToString()
        {
            return String.Format("{0} - {1} - {2:C2}", pckgd_id,pckgd_name,pckgd_price);
        }
        
    }


}
