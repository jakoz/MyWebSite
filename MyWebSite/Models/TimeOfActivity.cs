using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebSite.Models
{
    public class TimeOfActivity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Time of starting activity")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{hh.mm tt}")]
        public TimeSpan Start { get; set; }

        [Required]
        [DisplayName("Duration of the activity")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{hh.mm tt}")]
        public TimeSpan Duration { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{hh.mm tt}")]
        public TimeSpan End { get; set; }
    }
}