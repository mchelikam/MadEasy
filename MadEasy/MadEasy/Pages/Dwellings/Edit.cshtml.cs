using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MadEasy.Data;
using MadEasy.Models;

namespace MadEasy.Pages.Dwellings
{
    public class EditModel : PageModel
    {
        private readonly MadEasy.Data.MadEasyContext _context;

        public EditModel(MadEasy.Data.MadEasyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dwelling Dwelling { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dwelling = await _context.Dwelling
                .Include(d => d.Agent)
                .Include(d => d.City)
                .Include(d => d.SalesOffice).FirstOrDefaultAsync(m => m.Id == id);

            if (Dwelling == null)
            {
                return NotFound();
            }
           ViewData["AgentId"] = new SelectList(_context.Agent, "Id", "FullName");
           ViewData["CityId"] = new SelectList(_context.City, "Id", "Name");
           ViewData["SalesOfficeId"] = new SelectList(_context.Set<SalesOffice>(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // REPOPULATE DROPDOWN IF VALIDATION ERROR OCCURS
            ViewData["AgentId"] = new SelectList(_context.Agent, "Id", "FullName");
            ViewData["CityId"] = new SelectList(_context.City, "Id", "Name");
            ViewData["SalesOfficeId"] = new SelectList(_context.SalesOffice, "Id", "Name");

            //Validation for Date of Listing to be not a future date
            var ListYear = Dwelling.DateOfListing.Year;
            var CurrentYear = DateTime.Now.Year;
            var ListMonth = Dwelling.DateOfListing.Month;
            var CurrentMonth = DateTime.Now.Month;
            var ListDay = Dwelling.DateOfListing.Day;
            var CurrentDay = DateTime.Now.Day;

            if (CurrentYear < ListYear)
            {
                ModelState.AddModelError("Dwelling.DateOfListing", "Date Of Listing cannot be in future");
            }
            if (CurrentYear == ListYear && CurrentMonth < ListMonth)
            {
                ModelState.AddModelError("Dwelling.DateOfListing", "Date Of Listing cannot be in future");

            }
            if (CurrentYear == ListYear && CurrentMonth == ListMonth && CurrentDay < ListDay)
            {
                ModelState.AddModelError("Dwelling.DateOfListing", "Date Of Listing cannot be in future");

            }
            //Validation for Date of Listing cannot be past a year

            if (CurrentYear > ListYear)
            {
                if (CurrentMonth > ListMonth)
                {
                    ModelState.AddModelError("Dwelling.DateOfListing", "Date Of Listing cannot be past a year");
                }
                if (CurrentMonth == ListMonth && CurrentDay > ListDay)
                {
                    ModelState.AddModelError("Dwelling.DateOfListing", "Date Of Listing cannot be past a year");
                }

            }

            //Validation for Listed Price to not be less than $1000

            //decimal Price = Dwelling.ExpectedPrice.Value;

            //if (Price < 1000)
            {
               // ModelState.AddModelError("Dwelling.ExpectedPrice", "Price of Listed Property cannot be less than $1000");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Dwelling).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DwellingExists(Dwelling.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DwellingExists(int id)
        {
            return _context.Dwelling.Any(e => e.Id == id);
        }
    }
}
