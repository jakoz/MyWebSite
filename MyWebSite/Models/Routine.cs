using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebSite.Models
{
    public class Routine
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Day { get; set; }

        [Required]
        [DisplayName("Time of starting activity")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{hh.mm tt}")]
        public TimeSpan TimeOfStartingActivity { get; set; }

        [Required]
        [DisplayName("Duration of the activity")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{hh.mm tt}")]
        public TimeSpan DurationOfTheActivity { get; set; }

        [Required]
        [DisplayName("Type of the activity")]
        public TypeOfActivity Activity { get; set; }
    }
}