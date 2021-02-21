using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MadEasy.Models
{
    public class Agent
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

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required.")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
        public List<Dwelling> Dwellings { get; set; }
        [Display(Name = "Sales Office")]
        public SalesOffice SalesOffice { get; set; }
        [Display(Name = "Sales Office Id")]
        public int SalesOfficeId { get; set; }
    }
}
