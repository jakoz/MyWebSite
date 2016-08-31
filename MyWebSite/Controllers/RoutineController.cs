using Microsoft.AspNet.Identity;
using MyWebSite.Models;
using MyWebSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebSite.Controllers
{
    public class RoutineController : Controller
    {
        protected UserManager<ApplicationUser> UserManager { get; set; }
        public ApplicationDbContext _context;

        public RoutineController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Routine
        [Authorize]
        [HttpGet]
        public ActionResult EditRoutine()
        {
            string userId = User.Identity.GetUserId();
            var viewModel = new RoutineViewModel
            {
                Activities = _context.TypeOfActivity.ToList(),
                MondayList = _context.Routine.Where(r => r.Day == "Monday" && r.UserId == userId).ToList(),
                TuesdayList = _context.Routine.Where(r => r.Day == "Tuesday" && r.UserId == userId).ToList(),
                WednesdayList = _context.Routine.Where(r => r.Day == "Wednesday" && r.UserId == userId).ToList(),
                ThursdayList = _context.Routine.Where(r => r.Day == "Thursday" && r.UserId == userId).ToList(),
                FridayList = _context.Routine.Where(r => r.Day == "Friday" && r.UserId == userId).ToList(),
                SaturdayList = _context.Routine.Where(r => r.Day == "Saturday" && r.UserId == userId).ToList(),
                SundayList = _context.Routine.Where(r => r.Day == "Sunday" && r.UserId == userId).ToList(),
            };
            return View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateRoutine()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult UpdateRoutine(RoutineViewModel routine)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("EditRoutine");
            }
            var day = routine.Days[0];
            Routine NewRoutine = new Routine
            {
                UserId = User.Identity.GetUserId(),
                Activity = _context.TypeOfActivity.Single(r=>r.Id == routine.ActivityId),
                Day = routine.Days[0],
                DurationOfTheActivity = TimeSpan.Parse(routine.HourOfTheDurationActivity + ":" + routine.MinutesOfTheDurationActivity + ":" + 0),
                TimeOfStartingActivity = TimeSpan.Parse(routine.HourOfTheStartedActivity + ":" + routine.MinutesOfTheStartedActivity + ":" + 0)
            };

            _context.Routine.Add(NewRoutine);
            _context.SaveChanges();
            return RedirectToAction("EditRoutine");
        }
    }
}