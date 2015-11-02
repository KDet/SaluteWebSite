using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaluteWebSite.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Created { get; set; }

        [Required(ErrorMessage = "Supply a title")]
        [Display(Name = "New Title")]
        public string MessageTitle { get; set; }

        [Required(ErrorMessage = "Supply a content")]
        [Display(Name = "Content")]
        public string MessageContent { get; set; }
    }
}
