﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MadEasy.Data;
using MadEasy.Models;
using Microsoft.EntityFrameworkCore;


namespace MadEasy.Pages.Agents
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
        ViewData["SalesOfficeId"] = new SelectList(_context.Set<SalesOffice>(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Agent Agent { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            // REPOPULATE DROPDOWN IF VALIDATION ERROR OCCURS
            ViewData["SalesOfficeId"] = new SelectList(_context.SalesOffice, "Id", "Name");

            // Agent email validation
            var e = Agent.Email;
            bool eAlreadyExists = await _context.Agent.AnyAsync(x => x.Email == e);

            if (eAlreadyExists)
            {
                ModelState.AddModelError("Agent.Email", "Email already exists");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Agent.Add(Agent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
