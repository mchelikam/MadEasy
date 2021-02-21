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
    public class IndexModel : PageModel
    {
        private readonly MadEasy.Data.MadEasyContext _context;

        public IndexModel(MadEasy.Data.MadEasyContext context)
        {
            _context = context;
        }

        public IList<Prospect> Prospect { get;set; }

        public async Task OnGetAsync()
        {
            Prospect = await _context.Prospect.ToListAsync();
        }
    }
}
