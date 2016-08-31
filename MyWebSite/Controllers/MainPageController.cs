using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using MyWebSite.Models;
using MyWebSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebSite.Controllers
{
    public class MainPageController : Controller
    {
        protected UserManager<ApplicationUser> UserManager { get; set; }
        public ApplicationDbContext _context;

        public MainPageController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Main()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Schedule()
        {
            return RedirectToAction("EditSchedule", "Schedule");
        }
    }
}