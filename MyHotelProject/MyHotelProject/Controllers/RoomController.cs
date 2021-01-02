using Model.Dao;
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
            ViewBag.RoomTypes = roomTypeDao.ListAllRoomType();   
            return View();
        }
    }
}