using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MadEasy.Models
{
    public class Dwelling
    {
        public int Id { get; set; }

        [Display(Name = "Property Name")]
        [Required(ErrorMessage = "Property Name is required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Property Name should be minimum of 3 characters")]
        public string PropertyName { get; set; }


        public string Address { get; set; }
        public Agent Agent { get; set; }

        [Display(Name = "Agent Id")]
        public int AgentId { get; set; }
        public City City { get; set; }

        [Display(Name = "City Id")]
        public int CityId { get; set; }
        [Display(Name = "Sales Office")]
        public SalesOffice SalesOffice { get; set; }

        [Display(Name = "Sales Office Id")]
        public int SalesOfficeId { get; set; }

        [Display(Name = "Type Of Listing")]
        [Required(ErrorMessage = "Type of Listing is required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Type of Listing should be minimum of 3 characters")]
        public string Type { get; set; }


        [Display(Name = "Expected Price")]
        public decimal? ExpectedPrice { get; set; }
            public bool Available { get; set; }

        [Display(Name = "Date of Listing")]
        public DateTime? DateOfListing { get; set; }
            public string Note { get; set; }
    }
}