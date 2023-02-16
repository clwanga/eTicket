using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTicket.Models
{
    public class Actors
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile picture cant be empty!")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Fullname cant be empty!")]
        public string FullName { get; set; }

        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Bio cant be empty!")]
        [StringLength(100, MinimumLength = 3 ,ErrorMessage ="Cannot be more than 100 characters")]
        public string Bio { get; set; }

        //defining relationships
        public List<Actor_Movies> Actor_Movie { get; set; }
    }
}
