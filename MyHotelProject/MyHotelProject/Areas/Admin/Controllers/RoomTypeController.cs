using Model.Dao;
using Model.EF;
using MyHotelProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHotelProject.Areas.Admin.Controllers
{
    public class RoomTypeController : Controller
    {
        // GET: Admin/RoomType
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new RoomDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RoomType roomtype)
        {
            if (ModelState.IsValid)
            {
                var dao = new RoomDao();

                long id = dao.Insert(roomtype);

                if (id > 0)
                {
                    return RedirectToAction("Index", "RoomType");
                }
                else ModelState.AddModelError("", "Thêm loại phòng thành công");
            }
            return View("Index");
        }
        public ActionResult Edit(int id)
        {
            var roomtype = new RoomDao().ViewDetail(id);
            return View(roomtype);
        }
        [HttpPost]
        public ActionResult Edit(RoomType roomtype)
        {
            if (ModelState.IsValid)
            {
                var dao = new RoomDao();
                var result = dao.Update(roomtype);

                if (result)
                {
                    return RedirectToAction("Index", "RoomType");
                }
                else ModelState.AddModelError("", "Cập nhật không thành công");
            }
            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            new RoomDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}