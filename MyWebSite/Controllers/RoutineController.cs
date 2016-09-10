﻿using Microsoft.AspNet.Identity;
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
                NameOfNewActivity = "",
                Times = _context.TimeOfActivity.Where(model=>model.UserId == userId).ToList(),
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
            
            if (routine.Times != null)
            {
                TimeOfActivity routineCovered = routine.Times
                .OrderBy(r => r.End)
                .ToList()
                .FirstOrDefault(r =>
                (r.End.TotalMinutes > routine.Time.End.TotalMinutes &&
                r.Start.TotalMinutes < routine.Time.Start.TotalMinutes) ||
                (r.Start.TotalMinutes > routine.Time.Start.TotalMinutes &&
                r.Start.TotalMinutes < routine.Time.End.TotalMinutes) ||
                (r.End.TotalMinutes > routine.Time.Start.TotalMinutes &&
                r.End.TotalMinutes < routine.Time.End.TotalMinutes) ||
                (r.Start.TotalMinutes >= routine.Time.Start.TotalMinutes &&
                r.End.TotalMinutes <= routine.Time.End.TotalMinutes) &&
                r.Day == day);

                if (routineCovered != null)
                {
                    return RedirectToAction("EditRoutine");
                }
            }
            TypeOfActivity newActivity;
            if (routine.NameOfNewActivity != null)
            {
                newActivity = _context.TypeOfActivity.Add(new TypeOfActivity(routine.NameOfNewActivity));
            }
            else
            {
                newActivity = _context.TypeOfActivity.Single(r => r.Id == routine.ActivityId);
            }

            Routine NewRoutine = new Routine
            {
                UserId = User.Identity.GetUserId(),
                Activity = newActivity,
                Day = day,
                Time = routine.Time,               
            };
            NewRoutine.Time.UserId = userId;
            NewRoutine.Time.Day = day;

            _context.Routine.Add(NewRoutine);
            _context.SaveChanges();
            return RedirectToAction("EditRoutine");
        }
    }
}