using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MadEasy.Data;


namespace MadEasy.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MadEasy.Data.MadEasyContext _context;
        public IndexModel(ILogger<IndexModel> logger, MadEasy.Data.MadEasyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public int TotalDwellings { get; set; }
        public int TotalCities { get; set; }
        public int TotalSalesOffices { get; set; }
        public int TotalAgents { get; set; }
        public async Task OnGetAsync()
        {
            TotalDwellings = await _context.Dwelling.CountAsync();
            TotalCities = await _context.City.CountAsync();
            TotalSalesOffices = await _context.SalesOffice.CountAsync();
            TotalAgents = await _context.Agent.CountAsync();

        }
    }
}
