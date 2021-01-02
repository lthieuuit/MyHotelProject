using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class GuestDAO
    {
        public static long InsertGuest(Guest g) {

            using (MyHotelDbContext context = new MyHotelDbContext())
            {
                context.Guests.Add(g);
                context.SaveChanges();
                return g.ID;
            }
        }
    }
}
