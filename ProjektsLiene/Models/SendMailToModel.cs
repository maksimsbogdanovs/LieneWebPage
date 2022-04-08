using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektsLiene.Models
{
    public class SendMailToModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Message { get; set; }

        public string Email { get; set; }
    }

}
