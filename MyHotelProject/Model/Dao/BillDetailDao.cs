using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.Dao
{
    public class BillDetailDao
    {
        MyHotelDbContext db;

        public BillDetailDao()
        {
            db = new MyHotelDbContext();
        }

        public List<BillDetail> ViewDetail(long id)
        {
            var query = db.BillDetails;
            //IQueryable<OrderDetail>  = this.db.OrderDetails;
            //string qr = "SELECT *FROM OrderDetail WHeRE OrderID ="+id;
            return query.Where(x => x.BillCode == id).OrderBy(x => x.Quantity).ToList();
        }
        public IEnumerable<BillDetail> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<BillDetail> model = db.BillDetails;
            return model.OrderByDescending(x => x.Quantity).ToPagedList(page, pageSize);
        }
        public BillDetail ViewDetails(int id)
        {
            return db.BillDetails.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var b = db.BillDetails.Find(id);
                db.BillDetails.Remove(b);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public long Insert(BillDetail entity)
        {
            db.BillDetails.Add(entity);
            db.SaveChanges();
            return entity.RoomID;
        }
        public bool Update(BillDetail entity)
        {
            try
            {
                var bil = db.BillDetails.Find(entity.RoomID);
                bil.TotalPayment = entity.TotalPayment;
                bil.Quantity = entity.Quantity;


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
