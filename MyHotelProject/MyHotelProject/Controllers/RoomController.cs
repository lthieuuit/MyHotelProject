using Model.Dao;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MyHotelProject.Controllers
{
    public class RoomController : Controller
    {
        // GET: Room
        public ActionResult Index()
        {
            var roomTypeDao = new RoomTypeDao();
            ViewBag.RoomTypes = roomTypeDao.ListAll();
            var name = this.Request.Form["adult_qty"];
            System.Console.WriteLine(name);
            ViewBag.RoomTypes = roomTypeDao.ListAllRoomType();   
            return View();
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
                    return RedirectToAction("Index", "Room");
                    ModelState.AddModelError("", "Thêm thành công");
                }
                else ModelState.AddModelError("", "Thêm phòng thành công");
            }
            return View("Index");
        }
    }
}