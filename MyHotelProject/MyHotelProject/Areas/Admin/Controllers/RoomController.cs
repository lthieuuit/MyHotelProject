using Model.Dao;
using Model.EF;
using MyHotelProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System.Diagnostics;
using System.Drawing;

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

        public void Print(int id)
        {
            var room = new RoomDao().ViewDetail(id);
            PdfDocument document = new PdfDocument();
            //Add a page to the document.
            PdfPage page = document.Pages.Add();
            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;
            //Set the standard font.
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            //Draw the text.
            graphics.DrawString(room.RoomCapacity.ToString(), font, PdfBrushes.Black, new PointF(0, 0));
            //Save the document.    
            document.Save("./Assets/Admin/Bills/Output.pdf");
            //Close the document.
            document.Close(true);

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