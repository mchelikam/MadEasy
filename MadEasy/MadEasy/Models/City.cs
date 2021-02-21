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
        public string Name { get; set; }
        public List<Dwelling> Dwellings { get; set; }
        public List<SalesOffice> SalesOffices { get; set; }
    }
}
