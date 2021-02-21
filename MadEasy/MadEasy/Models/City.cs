using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MadEasy.Models
{
    public class City
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name should be a minimum of 3 characters")]
        public string Name { get; set; }
        public List<Dwelling> Dwellings { get; set; }
        public List<SalesOffice> SalesOffices { get; set; }
    }
}
