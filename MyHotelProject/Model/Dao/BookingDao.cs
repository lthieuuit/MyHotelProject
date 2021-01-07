
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
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
        public IEnumerable<Booking> ListAllPaging(int page = 1, int pageSize = 10)
        {
            return db.Bookings.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }

        public bool Update(Booking entity)
        {
            try
            {
                var bk = db.Bookings.Find(entity.ID);
                bk.BookAddress = entity.BookAddress;
                bk.BookEmail = entity.BookEmail;
                bk.BookName = entity.BookName;
                bk.BookPhone = entity.BookPhone;
                bk.Status = entity.Status;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public Booking ViewDetail(int id)
        {
            return db.Bookings.Find(id);
        }

        public Booking GetById(long roomnumber)
        {
            return db.Bookings.SingleOrDefault(x => x.ID == roomnumber);
        }

        public bool Delete(int id)
        {
            try
            {
                var bk = db.Bookings.Find(id);
                db.Bookings.Remove(bk);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
