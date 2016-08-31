using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWebSite.Models
{
    public class Schedule
    {
        [Key,Column(Order =0)]
        public int Id { get; set; }
        public string ScheduleId { get; set; }

        [Remote("IsDateTimeUnique", "Validation",ErrorMessage ="Date already exist")]
        [DisplayName("Date of the schedule")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateOfSchedule { get; set; }
    }
}
