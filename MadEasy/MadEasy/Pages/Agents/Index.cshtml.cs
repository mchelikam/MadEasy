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
    public class IndexModel : PageModel
    {
        private readonly MadEasy.Data.MadEasyContext _context;

        public IndexModel(MadEasy.Data.MadEasyContext context)
        {
            _context = context;
        }

        public IList<Agent> Agent { get;set; }

        public async Task OnGetAsync()
        {
            Agent = await _context.Agent
                .Include(a => a.SalesOffice).ToListAsync();
        }
    }
}
