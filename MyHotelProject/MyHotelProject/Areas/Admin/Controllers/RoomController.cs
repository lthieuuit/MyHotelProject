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
    public class RoomController : Controller
    {
        // GET: Admin/Room
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
        public ActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                var dao = new RoomDao();

                long id = dao.Insert(room);

                if (id > 0)
                {
                    return RedirectToAction("Index", "Room");
                    ModelState.AddModelError("", "Thêm phòng thành công");
                }
                else ModelState.AddModelError("", "Thêm phòng không thành công");
            }
            return View("Index");
        }
        public ActionResult Edit(int id)
        {
            var room = new RoomDao().ViewDetail(id);
            return View(room);
        }
        [HttpPost]
        public ActionResult Edit(Room room)
        {
            if (ModelState.IsValid)
            {
                var dao = new RoomDao();
                var result = dao.Update(room);

                if (result)
                {
                    return RedirectToAction("Index", "Room");
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