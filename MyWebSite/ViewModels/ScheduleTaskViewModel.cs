using MyWebSite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebSite.ViewModels
{
    public class ScheduleTaskViewModel
    {
        public IEnumerable<Schedule> Schedules{ get; set; }

        public IEnumerable<ScheduleTask> ScheduleTasks { get; set; }

        [MaxLength(4000, ErrorMessage = "Name cannot be longer than 4000 characters.")]
        public string NoteA { get; set; }
        public string NoteB { get; set; }
        public string NoteC { get; set; }
        public Schedule CurrentSchedule { get; set; }
        public ScheduleTask CurrentScheduleTask { get; set; }
        public DateTime CurrentScheduleDate { get; set; }
    }
}