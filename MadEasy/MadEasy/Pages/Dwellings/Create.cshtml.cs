using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MadEasy.Data;
using MadEasy.Models;

namespace MadEasy.Pages.Dwellings
{
    public class CreateModel : PageModel
    {
        private readonly MadEasy.Data.MadEasyContext _context;

        public CreateModel(MadEasy.Data.MadEasyContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AgentId"] = new SelectList(_context.Agent, "Id", "FullName");
        ViewData["CityId"] = new SelectList(_context.City, "Id", "Name");
        ViewData["SalesOfficeId"] = new SelectList(_context.Set<SalesOffice>(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Dwelling Dwelling { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Validation for Date of Listing to be not a future date
            var ListYear = Dwelling.DateOfListing.Year;
            var AllowedYear = DateTime.Now.Year;
            if (AllowedYear < ListYear)
            {
                ModelState.AddModelError("Dwelling.DateOfListing", "Date Of Listing cannot be a future year");
            }
            //Validation for Date of Listing to be not a past date

            if (AllowedYear > ListYear)
            {
                ModelState.AddModelError("Dwelling.DateOfListing", "Date Of Listing cannot be a past year");
            }

            //Validation for Listed Price to not be less than $1000

            decimal Price = Dwelling.ExpectedPrice.Value;

            if (Price < 1000)
            {
                ModelState.AddModelError("Dwelling.ExpectedPrice", "Price of Listed Property cannot be less than $1000");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dwelling.Add(Dwelling);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
