using System;
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
    public class IndexModel : PageModel
    {
        private readonly MadEasy.Data.MadEasyContext _context;

        public IndexModel(MadEasy.Data.MadEasyContext context)
        {
            _context = context;
        }

        public IList<SalesOffice> SalesOffice { get;set; }

        public async Task OnGetAsync()
        {
            SalesOffice = await _context.SalesOffice
                .Include(s => s.City).ToListAsync();
        }
    }
}
