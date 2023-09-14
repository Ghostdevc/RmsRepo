using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BluserLogic
    {
        public readonly static rmsDbEntities1 db = new rmsDbEntities1();

        public static int UserLoginBL(tbl_users user)
        {
            if (user.userName.Length <= 20 && user.userPassword.Length == 10)
            {
                foreach (tbl_users users in db.tbl_users)
                {
                    if (users.userName == user.userName && users.userPassword == user.userPassword)
                    {
                        return users.userID;
                    }
                }
            }
            return -1;
        }
    }
}
