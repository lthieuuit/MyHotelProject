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
        public List<RoomType> ListAll()
        {
            return db.RoomTypes.Where(x => x.ID != 0).ToList();
        }
    }

}
