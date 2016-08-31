using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyWebSite.Models
{
    public class ScheduleTask
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string ScheduleId { get; set; }

        public DateTime DateOfSchedule { get; set; }

        [MaxLength(4000, ErrorMessage = "Name cannot be longer than 4000 characters.")]
        public string NoteA { get; set; }

        [MaxLength(4000, ErrorMessage = "Name cannot be longer than 4000 characters.")]
        public string NoteB { get; set; }

        [MaxLength(4000, ErrorMessage = "Name cannot be longer than 4000 characters.")]
        public string NoteC { get; set; }
    }
}