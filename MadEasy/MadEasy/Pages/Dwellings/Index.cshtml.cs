using System;
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
    public class IndexModel : PageModel
    {
        private readonly MadEasy.Data.MadEasyContext _context;

        public IndexModel(MadEasy.Data.MadEasyContext context)
        {
            _context = context;
        }

        public IList<Dwelling> Dwelling { get;set; }

        public async Task OnGetAsync()
        {
            Dwelling = await _context.Dwelling
                .Include(d => d.Agent)
                .Include(d => d.City)
                .Include(d => d.SalesOffice).ToListAsync();
        }
    }
}
