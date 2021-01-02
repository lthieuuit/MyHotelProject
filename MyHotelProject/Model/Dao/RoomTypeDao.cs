using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class RoomTypeDao
    {
        MyHotelDbContext db = null;
        public RoomTypeDao()
        { 
            db = new MyHotelDbContext();
        }
        public List<RoomType> ListAllRoomType()
        {
            return db.RoomTypes.Where(x => x.ID != 0).ToList();
        }
        public List<RoomTypeBook> ListAllRoom()
        {
            return db.RoomTypeBooks.Where(x => x.ID != 0).ToList();
        }

        public List<Room> ListByRoomtypeId(long roomtypeID)
        {
            return db.Rooms.Where(x => x.RoomTypeID == roomtypeID).ToList();
        }
        public RoomTypeBook ViewDetailRoomTypeBook(long roomtypebookID)
        {
            return db.RoomTypeBooks.Find(roomtypebookID);
        }
        public RoomType ViewDetailRoomType(long roomID)
        {
            return db.RoomTypes.Find(roomID);
        }
        public Room ViewDetailRoom(int roomNumber)
        {
            return db.Rooms.Find(roomNumber);
        }
        public bool Update(RoomType entity)
        {
            try
            {
                var room = db.RoomTypes.Find(entity.ID);

                room.RoomTypeName = entity.RoomTypeName;
                room.PriceShow = entity.PriceShow;
                room.Description = entity.Description;
                room.Image1 = entity.Image1;
                room.Image2 = entity.Image2;
                room.Image3 = entity.Image3;
                room.Quantity = entity.Quantity;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }

}
