using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using MyHotelProject.Common;
using PagedList;

namespace MyHotelProject.Areas.Admin.Controllers
{
    public class BillController : Controller
    {
        // GET: Admin/Bill
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new BillDao();
            var model = dao.ListAllPaging( page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Delete(int id)
        {
            new BillDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(Bill bill1, BillDetail temp)
        {
            if (ModelState.IsValid)
            {
                var dao = new BillDao();
                long id = dao.Insert(bill1);

                

                if (id > 0)
                {
                    
                    var daodetail = new BillDetailDao();
                    temp.BillCode = bill1.BillCode;
                    temp.Quantity = 0;
                    temp.RoomID = 0;
                    temp.TotalPayment = 0;
                    long iddt = daodetail.Insert(temp);
                    return RedirectToAction("Index", "Bill");
                }
                else
                {
                    ModelState.AddModelError("", "Thêm hóa đơn thành công");
                }

            }
            return RedirectToAction("Index", "Bill");

        }

        public ActionResult Edit(int id)
        {
            var bill = new BillDao().ViewDetail(id);
            return View(bill);
        }
        [HttpPost]
        public ActionResult Edit(Bill bill)
        {
            if (ModelState.IsValid)
            {
                var dao = new BillDao();
                var result = dao.Update(bill);

                if (result)
                {
                    return RedirectToAction("Index", "Bill");
                }
                else ModelState.AddModelError("", "Cập nhật không thành công");
                //return RedirectToAction("Index", "Bill");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Detail(long id)
        {
            var bill = new BillDetailDao().ViewDetail(id);
            //ViewBag.Category = new ProductCategoryDao().ViewDetail(product.CategoryID.Value);
            return View(bill);
        }

        [HttpGet]
        public ActionResult CreateDetail()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult CreateDetail(BillDetail temp)
        {
            if (ModelState.IsValid)
            {
                var dao = new BillDetailDao();
                long id = dao.Insert(temp);

                if (id > 0)
                {
                    return RedirectToAction("/Detail/"+ temp.BillCode);
                }
                else
                {
                    ModelState.AddModelError("", "Thêm không thành công");
                }

            }
            return RedirectToAction("/Detail/" + temp.BillCode);
        }
        public ActionResult DeleteDetail(int id)
        {
            new BillDetailDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}