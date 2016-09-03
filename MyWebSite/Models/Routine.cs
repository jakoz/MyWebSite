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
        public TimeOfActivity Time { get; set; }

        [Required]
        [DisplayName("Type of the activity")]
        public TypeOfActivity Activity { get; set; }
    }
}