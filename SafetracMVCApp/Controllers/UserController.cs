using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SafetracMVCApp.Models;
namespace SafetracMVCApp.Controllers
{
    public class UserController : Controller
    {
        DBHandle db = new DBHandle();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAllUserData()
        {
            List<UserModel> userList = db.GetUser().ToList();
            return Json(new { data = userList }, JsonRequestBehavior.AllowGet);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserModel smodel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (db.AddUser(smodel))
                    {
                        ViewBag.Message = "User Details Added Successfully";
                        ModelState.Clear();
                    }
                }
                return View();
            }
            catch(Exception ex)
            {
                return View();
            }
        }

    }
}
