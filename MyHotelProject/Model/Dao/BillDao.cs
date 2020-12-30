using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
namespace Model.Dao
{
    public class BillDao
    {
        MyHotelDbContext db = null;
        public BillDao()
        {
            db = new MyHotelDbContext();
        }
        public long Insert(Bill entity)
        {
            db.Bills.Add(entity);
            db.SaveChanges();
            return entity.BillCode;
        }
        public IEnumerable<Bill> ListAllPaging(int page = 1, int pageSize = 10)
        {
            return db.Bills.OrderByDescending(x => x.BillCode).ToPagedList(page, pageSize);
        }

        public bool Update(Bill entity)
        {
            try
            {
                var bill = db.Bills.Find(entity.BillCode);
                bill.GuestID = entity.GuestID;
                bill.Total = entity.Total;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public Bill ViewDetail(int id)
        {
            return db.Bills.Find(id);
        }

        public Bill GetById(long billcode)
        {
            return db.Bills.SingleOrDefault(x => x.BillCode == billcode);
        }

        public bool Delete(int id)
        {
            try
            {
                var bill = db.Bills.Find(id);
                db.Bills.Remove(bill);
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
