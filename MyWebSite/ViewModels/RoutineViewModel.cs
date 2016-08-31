using MyWebSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebSite.ViewModels
{
    public class RoutineViewModel
    {
        public List<Routine> MondayList { get; set; }
        public List<Routine> TuesdayList { get; set; }
        public List<Routine> WednesdayList { get; set; }
        public List<Routine> ThursdayList { get; set; }
        public List<Routine> FridayList { get; set; }
        public List<Routine> SaturdayList { get; set; }
        public List<Routine> SundayList { get; set; }
        public List<string> Days { get; set; }
        public string Day { get; set; }

        [Display(Name = "Hours")]
        [Range(0, 24)]
        public int HourOfTheStartedActivity { get; set; }

        [Display(Name = "Hours")]
        [Range(0, 24)]
        public int HourOfTheDurationActivity { get; set; }

        [Display(Name = "Minutes")]
        [Range(0, 59)]
        public int MinutesOfTheStartedActivity { get; set; }

        [Display(Name = "Minutes")]
        [Range(0, 59)]
        public int MinutesOfTheDurationActivity { get; set; }
        public IEnumerable<TypeOfActivity> Activities { get; set; }
        public int ActivityId { get; set; }
        public RoutineViewModel()
        {
            Days = new List<string>();
            Days.Add("Monday");
            Days.Add("Tuesday");
            Days.Add("Wednesday");
            Days.Add("Thursday");            
            Days.Add("Friday");
            Days.Add("Saturday");
            Days.Add("Sunday");
        }

    }
}