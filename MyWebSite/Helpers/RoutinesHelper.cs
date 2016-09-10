using Microsoft.AspNet.Identity;
using MyWebSite.Controllers;
using MyWebSite.Models;
using MyWebSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebSite.Helpers
{
    public class RoutinesHelper
    {
        protected UserManager<ApplicationUser> UserManager { get; set; }
        public ApplicationDbContext _context;

        public RoutinesHelper()
        {
            _context = new ApplicationDbContext();
        }

        private bool IsEndTimeAfterStartTime(RoutineViewModel routine)
        {
            if (routine.Time.End > routine.Time.Start)
            {
                return true;
            }
            else
                return false;
        }
        private bool IsTimeNotCoverAnother(RoutineViewModel routine)
        {
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

                if (routineCovered == null) return true;
                else return false;
            }
            return true;
        }

        public bool ValidateTimeOfRoutine(RoutineViewModel routine)
        {
            if (IsEndTimeAfterStartTime(routine) && IsTimeNotCoverAnother(routine))
            {
                return true;
            }
            else
                return false;
        }
    }
}