using Model.Dao;
using Model.EF;
using MyHotelProject.Common;
using MyHotelProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Script.Serialization;

namespace MyHotelProject.Controllers
{
    public class BookingController : Controller
    {
        private const string BookingSession = "BookingSession";
        // GET: Booking
        public ActionResult Index()
        {

            var session = Session[BookingSession];
            var list = new List<BookingRoom>();
            if (session != null)
            {
                list = (List<BookingRoom>)session;
            }
            var roomTypeDao = new RoomTypeDao();
            ViewBag.RoomTypes = roomTypeDao.ListAllRoomType();
            ViewBag.RoomBooks = roomTypeDao.ListAllRoom();
            return View(list);
        }
        [ChildActionOnly]
        public ActionResult RoomSelect()
        {
            var model = new RoomTypeDao().ListByRoomtypeId(2);
            return PartialView(model);
        }


        //public JsonResult UpdateQuantity(string bookingModel)
        //{
        //    var jsonBooking = new JavaScriptSerializer().Deserialize<List<BookingRoom>>(bookingModel);
        //    var sessioBooking = (List<BookingRoom>)Session[BookingSession];
        //    foreach (var item in sessioBooking)
        //    {
        //        var jsonItem = jsonBooking.SingleOrDefault(x => x.Room.RoomNumber == item.Room.RoomNumber);
        //        if (jsonItem != null)
        //        {
        //            item.Quantity = jsonItem.Quantity;
        //        }
        //        Session[BookingSession] = sessioBooking;
        //    }
        //    return Json(new
        //    {
        //        status = true
        //    });
        //}
        //public JsonResult UpdateAdult(string bookingModel)
        //{
        //    var jsonBooking = new JavaScriptSerializer().Deserialize<List<BookingRoom>>(bookingModel);
        //    var sessioBooking = (List<BookingRoom>)Session[BookingSession];
        //    foreach (var item in sessioBooking)
        //    {
        //        var jsonItem = jsonBooking.SingleOrDefault(x => x.Room.RoomNumber == item.Room.RoomNumber);
        //        if (jsonItem != null)
        //        {
        //            item.Adult = jsonItem.Adult;
        //        }
        //        Session[BookingSession] = sessioBooking;
        //    }
        //    return Json(new
        //    {
        //        status = true
        //    });
        //}
        //public JsonResult UpdateChildren(string bookingModel)
        //{
        //    var jsonBooking = new JavaScriptSerializer().Deserialize<List<BookingRoom>>(bookingModel);
        //    var sessioBooking = (List<BookingRoom>)Session[BookingSession];
        //    foreach (var item in sessioBooking)
        //    {
        //        var jsonItem = jsonBooking.SingleOrDefault(x => x.Room.RoomNumber == item.Room.RoomNumber);
        //        if (jsonItem != null)
        //        {
        //            item.Children = jsonItem.Children;
        //            //item.Roomtype.RoomTypeName = jsonItem.Roomtype.RoomTypeName;
        //        }
        //        Session[BookingSession] = sessioBooking;
        //    }
        //    return Json(new
        //    {
        //        status = true
        //    });
        //}

        [HttpPost]
        public ActionResult Reservation(int roomtypebookID, DateTime checkin, DateTime checkout, int adult, int children, int quantity)
        {

            var roomtypebook = new RoomTypeDao().ViewDetailRoomTypeBook(roomtypebookID);
            var session = Session[BookingSession];

            var booking = new BookingRoom();

            booking.RoomTypeBook = roomtypebook;
            booking.CheckinDate = checkin;
            booking.CheckoutDate = checkout;
            booking.Adult = adult;
            booking.Children = children;
            booking.Quantity = quantity;
            var list = new List<BookingRoom>();
            list.Add(booking);
            Session[BookingSession] = list;
            return  RedirectToAction("/Confirm");
        }
        [HttpGet]
        public ActionResult Confirm()
        {
            var booking = Session[BookingSession];
            var list = new List<BookingRoom>();
            if (booking != null)
            {
                list = (List<BookingRoom>)booking;
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult Confirm(string bookname, string email, long idnumber, string address, string phone, string message)
        {
            var arrival = new Booking();
            arrival.CreatedDate = DateTime.Now;
            arrival.BookName = bookname;
            arrival.BookEmail = email;
            arrival.IdCardNumber = idnumber;
            arrival.BookAddress = address;
            arrival.BookPhone = phone;
            arrival.Message = message;
            try
            {
                var id = new BookingDao().Insert(arrival);
                var booking = (List<BookingRoom>)Session[BookingSession];
                var detailDao = new Model.Dao.BookingDetailDao();

                foreach (var item in booking)
                {
                    var bookingDetail = new BookingDetail();
                    bookingDetail.RoomTypeName = item.RoomTypeBook.RoomTypeNameBook;
                    //bookingDetail.RoomNumber = item.Room.RoomNumber;
                    bookingDetail.BookingID = id;
                    bookingDetail.Quantity = item.Quantity;
                    bookingDetail.FromDate = item.CheckinDate;
                    bookingDetail.ToDate = item.CheckoutDate;
                    bookingDetail.Adult = item.Adult;
                    bookingDetail.Children = item.Children;
                    bookingDetail.Price = item.RoomTypeBook.Price;                 
                    detailDao.Insert(bookingDetail);
                }
            }
            catch (Exception)
            {

                return Redirect("/home");
            }
            return Redirect("/hoan-thanh-don-dat-phong");
        }
        public ActionResult Success()
        {
            return View();
        }      
    }
}