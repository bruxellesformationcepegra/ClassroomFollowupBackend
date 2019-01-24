using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClassroomFollowup.Models
{
    public class Followup
    {
        public int ID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Training { get; set; }
        [Required]
        public string Trainer { get; set; }
        [Required]
        public string Description { get; set; }
    }
}