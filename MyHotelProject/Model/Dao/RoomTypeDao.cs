using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;

namespace Model.Dao
{
    public class RoomTypeDao
    {
        MyHotelDbContext db = null;
        public RoomTypeDao()
        {
            db = new MyHotelDbContext();
        }
        public long Insert(RoomType entity)
        {
            db.RoomTypes.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public IEnumerable<RoomType> ListAllPaging(int page = 1, int pageSize = 10)
        {
            return db.RoomTypes.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }

        public bool Update(RoomType entity)
        {
            try
            {
                var roomtype = db.RoomTypes.Find(entity.ID);
                roomtype.RoomTypeName = entity.RoomTypeName;
                
                roomtype.Price = entity.Price;
                roomtype.Description = entity.Description;
                roomtype.Image1 = entity.Image1;
                roomtype.Image2 = entity.Image2;
                roomtype.Image3 = entity.Image3;

                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public RoomType ViewDetail(int id)
        {
            return db.RoomTypes.Find(id);
        }

        public RoomType GetById(long id)
        {
            return db.RoomTypes.SingleOrDefault(x => x.ID == id);
        }

        public bool Delete(int id)
        {
            try
            {
                var roomtype = db.RoomTypes.Find(id);
                db.RoomTypes.Remove(roomtype);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public List<RoomType> ListAll()
        {
            return db.RoomTypes.ToList();
        }
    }
}