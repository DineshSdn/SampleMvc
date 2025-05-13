using MVC_CRUD.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserCrudService _userCrudService;
        public HomeController(UserCrudService userCrudService)
        {
            _userCrudService = userCrudService;
        }
        public ActionResult Index()
        {
            var listofData = _userCrudService.GetAll();
            return View(listofData);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (_userCrudService.CreateUser(user))
            {
                ViewBag.Message = "Data Insert Successful";
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _userCrudService.GetById(id);
            //var data1=_context.Users.FirstOrDefault(u => u.Id == id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {

            if (_userCrudService.EditUser(user))
            {
                return RedirectToAction("index");
            }
            ViewBag.Message = "Data Updation Unsuccessful";
            return View(user);
        }

        public ActionResult Details(int id)
        {
            var data =_userCrudService.GetById(id);
            return View(data);
        }

        public ActionResult Delete(int id)
        {

            if (_userCrudService.DeleteUser(id))
            {
                ViewBag.Message = "Record Deleted Successfully";
            }
            else
            {
                ViewBag.Message = "Record Could not be deleted Deleted";
            }
            return RedirectToAction("index");
        }

    }
}