using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;
namespace Model.Dao
{
    public class BookingDetailDao
    {
        MyHotelDbContext db = null;
        public BookingDetailDao()
        {
            db = new MyHotelDbContext();
        }
        public long Insert(BookingDetail detail)
        {
            db.BookingDetails.Add(detail);
            db.SaveChanges();
            return detail.BookingID;
        }

        public bool Update(BookingDetail entity)
        {

            try
            {
                var bk = db.BookingDetails.Find(entity.BookingID);

                bk.Adult = entity.Adult;
                bk.Children = entity.Children;
                bk.FromDate = entity.FromDate;
                bk.ToDate = entity.ToDate;
                bk.Quantity = entity.Quantity;
                bk.RoomTypeID = entity.RoomTypeID;
                bk.Quantity = entity.Quantity;
                bk.RoomTypeName = entity.RoomTypeName;
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        
        public BookingDetail ViewDetail(int id)
        {
            return db.BookingDetails.Find(id);
        }

        public BookingDetail GetById(long roomnumber)
        {
            return db.BookingDetails.SingleOrDefault(x => x.BookingID == roomnumber);
        }

        public bool Delete(int id)
        {
            try
            {
                var bk = db.BookingDetails.Find(id);
                db.BookingDetails.Remove(bk);
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
