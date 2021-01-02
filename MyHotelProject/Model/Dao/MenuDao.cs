using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class MenuDao
    {
        MyHotelDbContext db = null;
        public MenuDao()
        {
            db = new MyHotelDbContext();
        }

        public List<Menu> ListByGroupId(int groupid)
        {
            return db.Menus.Where(x => x.TypeID == groupid).ToList();
        }
    }
}

