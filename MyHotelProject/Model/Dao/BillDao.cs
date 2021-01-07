using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.Dao
{
    public class BillDao
    {
        MyHotelDbContext db;

        public BillDao()
        {
            db = new MyHotelDbContext();
        }

        public Bill ViewDetail(long id)
        {
            return db.Bills.Find(id);
        }
        public IEnumerable<Bill> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Bill> model = db.Bills;
            return model.OrderByDescending(x => x.BillCode).ToPagedList(page, pageSize);
        }
        public bool Delete(int id)
        {
            try
            {
                var b = db.Bills.Find(id);
                db.Bills.Remove(b);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public long Insert(Bill entity)
        {
            db.Bills.Add(entity);
            db.SaveChanges();
            return entity.BillCode;
        }
        public bool Update(Bill entity)
        {
            try
            {
                var bil = db.Bills.Find(entity.BillCode);
                bil.BillCode = entity.BillCode;
                bil.CreatedDate = DateTime.Now;
                bil.GuestID = entity.GuestID;
                bil.Total = entity.Total;

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
