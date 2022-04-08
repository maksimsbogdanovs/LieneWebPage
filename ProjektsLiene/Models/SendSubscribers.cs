using System.ComponentModel.DataAnnotations;

namespace ProjektsLiene.Models
{
    public class SendSubscribers
    {

        [Required]
        public string Email { get; set; }

        public string Subject { get; set; }
    }
}
