using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MadEasy.Data;
using MadEasy.Models;

namespace MadEasy.Pages.SalesOffices
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
        ViewData["CityId"] = new SelectList(_context.City, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public SalesOffice SalesOffice { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SalesOffice.Add(SalesOffice);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
