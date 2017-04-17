using Microsoft.AspNet.Identity;
using MyWebSite.Migrations;
using MyWebSite.Models;
using MyWebSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebSite.Controllers
{
    public class ScheduleController : Controller
    {
        protected UserManager<ApplicationUser> UserManager { get; set; }
        public ApplicationDbContext _context;

        public ScheduleController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Schedule
        [Authorize]
        public ActionResult EditSchedule(string id)
        {
            string userId = User.Identity.GetUserId();
            var schedules = _context.Schedule.Where(s => s.ScheduleId == userId).ToList();
            if (schedules.Any())
            {
                Schedule editedSchedule = null;
                ScheduleTask editedScheduleTask = null;
                var idOfSchedule = 0;
                if (id == null)
                {
                    editedSchedule = schedules[0];
                    editedScheduleTask = _context.ScheduleTask.SingleOrDefault(s => s.DateOfSchedule == editedSchedule.DateOfSchedule
                                       && s.ScheduleId == editedSchedule.ScheduleId);
                    idOfSchedule = schedules[0].Id;
                }
                else
                {
                    var date = DateTime.Parse(id);
                    //var editedSchedule = schedules.Single(s => s.DateOfSchedule == DateTime.Parse(id));
                    editedSchedule = schedules.Where(s => s.DateOfSchedule == date
                                        && s.ScheduleId == userId).Single();
                    editedScheduleTask = _context.ScheduleTask.SingleOrDefault(s => s.DateOfSchedule == date
                                       && s.ScheduleId == userId);

                    idOfSchedule = schedules.Find(s=>s.DateOfSchedule == editedSchedule.DateOfSchedule).Id;
                }
                var ScheduleTaskViewModel = new ScheduleTaskViewModel
                {                   
                    CurrentSchedule = editedSchedule,
                    CurrentScheduleTask = editedScheduleTask,
                    CurrentScheduleDate = editedSchedule.DateOfSchedule,
                    Schedules = schedules,
                    ScheduleTasks = _context.ScheduleTask.Where(s=>s.DateOfSchedule == editedSchedule.DateOfSchedule).ToList()

                };
                return View(ScheduleTaskViewModel);
            }
            else
                return RedirectToAction("CreateSchedule");
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateSchedule()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult CreateSchedule(Schedule schedule)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("CreateSchedule");
            }

            schedule.ScheduleId = User.Identity.GetUserId();

            try
            {
                _context.Schedule.Add(schedule);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            return RedirectToAction("EditSchedule");
        }

        [Authorize]
        [HttpGet]
        public ActionResult AddScheduleTask()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddScheduleTask(ScheduleTaskViewModel task)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("EditSchedule");
            }
            
            ScheduleTask Task = new ScheduleTask
            {
                ScheduleId = User.Identity.GetUserId(),
                NoteA = task.NoteA,
                NoteB = task.NoteB,
                NoteC = task.NoteC,
                DateOfSchedule = task.CurrentScheduleDate
            };

            _context.ScheduleTask.Add(Task);
            _context.SaveChanges();
            return RedirectToAction("EditSchedule");
        }

        [HttpPost]
        [Authorize]
        public ActionResult DeleteRoutine(string id)
        {
            var idInt = Int32.Parse(id);
            var schedule = _context.Schedule.Single(s => s.Id == idInt);
            _context.Schedule.Remove(schedule);
            _context.SaveChanges();
            return RedirectToAction("EditSchedule");
        }
    }
}