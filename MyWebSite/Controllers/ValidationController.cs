using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Web.Mvc;
using System.Web.UI;
using MyWebSite.Models;
using Microsoft.AspNet.Identity;

namespace MyWebSite.Controllers
{
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true)]
    public class ValidationController : Controller
    {
        public ApplicationDbContext _context;
        
        public ValidationController()
        {
            _context = new ApplicationDbContext();
        }

        public JsonResult IsDateTimeUnique(DateTime DateOfSchedule)
        {
            string userId = User.Identity.GetUserId();
            List<Schedule> schedules = _context.Schedule.Where(s => s.ScheduleId == userId).ToList();
            return Json(!schedules.Any(s => s.DateOfSchedule == DateOfSchedule), JsonRequestBehavior.AllowGet);
        }
    }
}