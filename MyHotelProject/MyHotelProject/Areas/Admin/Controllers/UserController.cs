﻿using Model.Dao;
using Model.EF;
using MyHotelProject.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHotelProject.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var encrypted = Encryptor.MD5Hash(user.Password);
                user.Password = encrypted;
                long id = dao.Insert(user);
               
                if (id > 0)
                {
                    return RedirectToAction("Index", "User");
                }
                else ModelState.AddModelError("", "Thêm user thành công");
            }
            return View("Index");
        }
    }
}