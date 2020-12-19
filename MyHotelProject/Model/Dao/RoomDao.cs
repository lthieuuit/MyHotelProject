using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.Dao
{
    public class RoomDao
    {
        MyHotelDbContext db = null;
        public RoomDao()
        {
            db = new MyHotelDbContext();
        }
        public long Insert(Room entity)
        {
            db.Rooms.Add(entity);
            db.SaveChanges();
            return entity.RoomNumber;
        }
        public IEnumerable<Room> ListAllPaging(int page = 1, int pageSize = 10)
        {
            return db.Rooms.OrderByDescending(x => x.RoomNumber).ToPagedList(page, pageSize);
        }

        public bool Update(Room entity)
        {
            try
            {
                var room = db.Rooms.Find(entity.RoomNumber);
                room.RoomNumber = entity.RoomNumber;
                room.Price = entity.Price;
                room.RoomTypeID = entity.RoomTypeID;
                room.RoomCapacity = entity.RoomCapacity;
                room.Status = entity.Status;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public Room ViewDetail(int id)
        {
            return db.Rooms.Find(id);
        }

        public Room GetById(long roomnumber)
        {
            return db.Rooms.SingleOrDefault(x => x.RoomNumber == roomnumber);
        }

        public bool Delete(int id)
        {
            try
            {
                var room = db.Rooms.Find(id);
                db.Rooms.Remove(room);
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
