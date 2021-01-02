using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class BookingDetailDao
    {
        MyHotelDbContext db = null;
        public BookingDetailDao()
        {
            db = new MyHotelDbContext();
        }
        public bool Insert(BookingDetail detail)
        {
            try
            {
                db.BookingDetails.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
