using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class BookingDao
    {
        MyHotelDbContext db = null;
        public BookingDao()
        {
            db = new MyHotelDbContext();
        }
         public long Insert(Booking booking)
        {
            db.Bookings.Add(booking);
            db.SaveChanges();
            return booking.ID;
        }
    }
}
