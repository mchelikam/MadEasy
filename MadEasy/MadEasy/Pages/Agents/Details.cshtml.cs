using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MadEasy.Data;
using MadEasy.Models;

namespace MadEasy.Pages.Agents
{
    public class DetailsModel : PageModel
    {
        private readonly MadEasy.Data.MadEasyContext _context;

        public DetailsModel(MadEasy.Data.MadEasyContext context)
        {
            _context = context;
        }

        public Agent Agent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Agent = await _context.Agent
                .Include(a => a.SalesOffice).FirstOrDefaultAsync(m => m.Id == id);

            if (Agent == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
