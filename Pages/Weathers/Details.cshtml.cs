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
    public class DetailsModel : PageModel
    {
        private readonly LAB4_1.Data.LAB4_1Context _context;

        public DetailsModel(LAB4_1.Data.LAB4_1Context context)
        {
            _context = context;
        }

      public Weather Weather { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Weather == null)
            {
                return NotFound();
            }

            var weather = await _context.Weather.FirstOrDefaultAsync(m => m.Id == id);
            if (weather == null)
            {
                return NotFound();
            }
            else 
            {
                Weather = weather;
            }
            return Page();
        }
    }
}
