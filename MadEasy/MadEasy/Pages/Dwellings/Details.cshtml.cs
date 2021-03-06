﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MadEasy.Data;
using MadEasy.Models;

namespace MadEasy.Pages.Dwellings
{
    public class DetailsModel : PageModel
    {
        private readonly MadEasy.Data.MadEasyContext _context;

        public DetailsModel(MadEasy.Data.MadEasyContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
