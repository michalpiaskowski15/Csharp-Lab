using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LAB4_1.Data;
using LAB4_1.Models;

namespace LAB4_1.Pages.Weathers
{
    public class IndexModel : PageModel
    {
        private readonly LAB4_1.Data.LAB4_1Context _context;

        public IndexModel(LAB4_1.Data.LAB4_1Context context)
        {
            _context = context;
        }

        public IList<Weather> Weather { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Weather != null)
            {
                Weather = await _context.Weather.ToListAsync();
            }
        }
    }
}
