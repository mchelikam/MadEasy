using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MadEasy.Data;
using MadEasy.Models;

namespace MadEasy.Pages.Prospects
{
    public class DeleteModel : PageModel
    {
        private readonly MadEasy.Data.MadEasyContext _context;

        public DeleteModel(MadEasy.Data.MadEasyContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Prospect Prospect { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Prospect = await _context.Prospect.FirstOrDefaultAsync(m => m.Id == id);

            if (Prospect == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Prospect = await _context.Prospect.FindAsync(id);

            if (Prospect != null)
            {
                _context.Prospect.Remove(Prospect);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
