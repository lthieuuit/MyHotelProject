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
        public long Insert(Booking entity)
        {
            db.Bookings.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public IEnumerable<Booking> ListAllPaging(int page = 1, int pageSize = 10)
        {
            return db.Bookings.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }

        //public bool Update(Booking entity)
        //{
        //    //

        //}

        public Booking ViewDetail(int id)
        {
            return db.Bookings.Find(id);
        }

        public Booking GetById(long id)
        {
            return db.Bookings.SingleOrDefault(x => x.ID == id);
        }

        //public bool Delete(int id)
        //{
        //    try
        //    {
        //        var room = db.Rooms.Find(id);
        //        db.Rooms.Remove(room);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //}
    }
}
