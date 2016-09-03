using Microsoft.AspNet.Identity;
using MyWebSite.Helpers;
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
        public RoutinesHelper _routinesHelper;

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
                MondayList = _context.Routine.Where(r => r.Day == "Monday" && r.UserId == userId).OrderBy(r => r.Time.End).ToList(),
                TuesdayList = _context.Routine.Where(r => r.Day == "Tuesday" && r.UserId == userId).OrderBy(r => r.Time.End).ToList(),
                WednesdayList = _context.Routine.Where(r => r.Day == "Wednesday" && r.UserId == userId).OrderBy(r => r.Time.End).ToList(),
                ThursdayList = _context.Routine.Where(r => r.Day == "Thursday" && r.UserId == userId).OrderBy(r => r.Time.End).ToList(),
                FridayList = _context.Routine.Where(r => r.Day == "Friday" && r.UserId == userId).OrderBy(r => r.Time.End).ToList(),
                SaturdayList = _context.Routine.Where(r => r.Day == "Saturday" && r.UserId == userId).OrderBy(r => r.Time.End).ToList(),
                SundayList = _context.Routine.Where(r => r.Day == "Sunday" && r.UserId == userId).OrderBy(r => r.Time.End).ToList(),
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
            string userId = User.Identity.GetUserId();
            if (!ModelState.IsValid)
            {
                return RedirectToAction("EditRoutine");
            }

            var day = routine.Days[0];
            //timesForRoutine = RoutinesHelper.PrepareTimeValuesToSave(routine);

            //Routine routinePrevious = _context.Routine
            //    .OrderBy(r => r.EndOfActivity)
            //    .ToList()
            //    .LastOrDefault(r => r.EndOfActivity.TotalMinutes <= routine.StartOfActivity.TotalMinutes && r.UserId == userId && r.Day == day);


            Routine routineCovered = _context.Routine
                .OrderBy(r => r.Time.End)
                .ToList()
                .FirstOrDefault(r => 
                (r.Time.End.TotalMinutes > routine.Time.End.TotalMinutes &&
                r.Time.Start.TotalMinutes < routine.Time.Start.TotalMinutes) ||
                (r.Time.Start.TotalMinutes > routine.Time.Start.TotalMinutes  &&
                r.Time.Start.TotalMinutes < routine.Time.End.TotalMinutes) ||
                (r.Time.End.TotalMinutes > routine.Time.Start.TotalMinutes &&
                r.Time.End.TotalMinutes < routine.Time.End.TotalMinutes) ||
                (r.Time.Start.TotalMinutes > routine.Time.Start.TotalMinutes &&
                r.Time.End.TotalMinutes < routine.Time.End.TotalMinutes) &&
                r.UserId == userId &&
                r.Day == day);


            if (routineCovered != null)
            {
                return RedirectToAction("EditRoutine");
            }

            Routine NewRoutine = new Routine
            {
                UserId = User.Identity.GetUserId(),
                Activity = _context.TypeOfActivity.Single(r=>r.Id == routine.ActivityId),
                Day = routine.Days[0],
                Time = routine.Time,
            };
            

            _context.Routine.Add(NewRoutine);
            _context.SaveChanges();
            return RedirectToAction("EditRoutine");
        }
    }
}