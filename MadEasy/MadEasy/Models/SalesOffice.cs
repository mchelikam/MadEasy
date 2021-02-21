using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MadEasy.Models
{
    public class SalesOffice
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Agent> Agents { get; set; }
        public City City { get; set; }

        [Display(Name = "City Id")]
        public int CityId { get; set; }
        public List<Dwelling> Dwellings { get; set; }
        public string Address { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required.")]
        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
    }
}
