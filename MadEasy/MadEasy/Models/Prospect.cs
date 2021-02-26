using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MadEasy.Models
{
    public class Prospect
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "First Name should be minimum of 3 characters")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Last Name should be minimum of 3 characters")]
        public string LastName { get; set; }

        public string FullName
        {
            get
            {      // CONCAT FIRST & LAST NAME
                return $"{FirstName}  {LastName}";
            }
        }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required.")]
        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [Display(Name = "Type Of Listing")]
        public string Type { get; set; }
    }
}
