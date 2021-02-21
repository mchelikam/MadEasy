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
        ViewData["AgentId"] = new SelectList(_context.Agent, "Id", "Id");
        ViewData["CityId"] = new SelectList(_context.City, "Id", "Id");
        ViewData["SalesOfficeId"] = new SelectList(_context.Set<SalesOffice>(), "Id", "Id");
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

            _context.Dwelling.Add(Dwelling);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
