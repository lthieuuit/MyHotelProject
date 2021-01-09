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
    public class BookingDetailsController : Controller
    {
        public ActionResult Index(int id)
        {
            var bk = new BookingDetailDao().ViewDetail(id);
            return View(bk);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BookingDetail bk)
        {
            if (ModelState.IsValid)
            {
                var dao = new BookingDetailDao();

                long id = dao.Insert(bk);

                if (id > 0)
                {
                    return RedirectToAction("Index", "Booking");
                    ModelState.AddModelError("", "Thêm thành công");
                }
                else ModelState.AddModelError("", "Thêm không thành công");
            }
            return RedirectToAction("Index", "Booking");
        }
        public ActionResult Edit(int id)
        {
            var bkd = new BookingDetailDao().ViewDetail(id);
            return View(bkd);
        }
        [HttpPost]
        public ActionResult Edit(BookingDetail bkd)
        {
            if (ModelState.IsValid)
            {
                var dao = new BookingDetailDao();
                var result = dao.Update(bkd);

                if (result)
                {
                    return RedirectToAction("Index", "Booking");
                }
                else ModelState.AddModelError("", "Cập nhật không thành công");
            }
            return RedirectToAction("Index", "Booking");
        }

        public ActionResult Delete(int id)
        {
            new BookingDetailDao().Delete(id);
            return RedirectToAction("Index", "Booking");
        }
    }
}