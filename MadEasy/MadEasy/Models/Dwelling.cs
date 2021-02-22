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

        [DataType(DataType.Date)]
        [Display(Name = "Date of Listing")]
        public DateTime DateOfListing { get; set; }
            public string Note { get; set; }

        [Display(Name = "How old is the listing")]
        public string Old
        {
            get
            {
                DateTime today = DateTime.Today;
                int listed_year = DateOfListing.Year;
                int listed_month = DateOfListing.Month;
                int listed_date = DateOfListing.Day;
                int current_year = today.Year;
                int current_month = today.Month;
                int current_date = today.Day;

                int[] month = { 31, 28, 31, 30, 31, 30,
                      31, 31, 30, 31, 30, 31 };
                if (listed_date > current_date)
                {
                    current_month = current_month - 1;

                    current_date = current_date
                              + month[listed_month - 1];
                }
                if (listed_month > current_month)
                {
                    current_year = current_year - 1;
                    current_month = current_month + 12;
                }

                int calculated_date = current_date
                                 - listed_date;

                int calculated_month = current_month
                                        - listed_month;

                int calculated_year = current_year
                                         - listed_year;

                string old = $"{calculated_year} years, {calculated_month} months, {calculated_date} days";
                return old;
            }
        }
    }
}