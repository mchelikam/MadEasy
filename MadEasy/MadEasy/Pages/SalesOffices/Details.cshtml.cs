﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MadEasy.Data;
using MadEasy.Models;

namespace MadEasy.Pages.SalesOffices
{
    public class DetailsModel : PageModel
    {
        private readonly MadEasy.Data.MadEasyContext _context;

        public DetailsModel(MadEasy.Data.MadEasyContext context)
        {
            _context = context;
        }

        public SalesOffice SalesOffice { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalesOffice = await _context.SalesOffice
                .Include(s => s.City)
                .Include(s => s.Agents)
                .Include(s => s.Dwellings)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (SalesOffice == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
