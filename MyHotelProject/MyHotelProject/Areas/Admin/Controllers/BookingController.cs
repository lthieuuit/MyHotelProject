using Model.Dao;
using Model.EF;
using MyHotelProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Drawing;

namespace MyHotelProject.Areas.Admin.Controllers
{
    public class BookingController : Controller
    {
        // GET: Admin/Booking
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new BookingDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Booking bk)
        {
            if (ModelState.IsValid)
            {
                var dao = new BookingDao();

                long id = dao.Insert(bk);

                if (id > 0)
                {
                    ModelState.AddModelError("", "Thêm đơn thành công");
                    return RedirectToAction("Index", "Booking");

                }
                else ModelState.AddModelError("", "Thêm đơn không thành công");
            }
            return View("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var bk = new BookingDao().ViewDetail(id);
            return View(bk);
        }
        [HttpPost]
        public ActionResult Edit(Booking bk)
        {
            if (ModelState.IsValid)
            {
                var dao = new BookingDao();
                var result = dao.Update(bk);

                if (result)
                {
                    return RedirectToAction("Index", "Booking");
                }
                else ModelState.AddModelError("", "Cập nhật không thành công");
            }
            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            new BookingDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}