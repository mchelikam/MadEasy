using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MadEasy.Data;
using MadEasy.Models;

namespace MadEasy.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly MadEasy.Data.MadEasyContext _context;

        public SignUpModel(MadEasy.Data.MadEasyContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
        [BindProperty]
        public Prospect Prospect { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Prospect.Add(Prospect);
            await _context.SaveChangesAsync();
            return RedirectToPage("./ThankYou");
        }
    }
}
