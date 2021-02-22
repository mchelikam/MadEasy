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

namespace MadEasy.Pages.SalesOffices
{
    public class EditModel : PageModel
    {
        private readonly MadEasy.Data.MadEasyContext _context;

        public EditModel(MadEasy.Data.MadEasyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SalesOffice SalesOffice { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalesOffice = await _context.SalesOffice
                .Include(s => s.City).FirstOrDefaultAsync(m => m.Id == id);

            if (SalesOffice == null)
            {
                return NotFound();
            }
           ViewData["CityId"] = new SelectList(_context.City, "Id", "Name");
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

            _context.Attach(SalesOffice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesOfficeExists(SalesOffice.Id))
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

        private bool SalesOfficeExists(int id)
        {
            return _context.SalesOffice.Any(e => e.Id == id);
        }
    }
}
