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
    public class DeleteModel : PageModel
    {
        private readonly LAB4_1.Data.LAB4_1Context _context;

        public DeleteModel(LAB4_1.Data.LAB4_1Context context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Weather == null)
            {
                return NotFound();
            }
            var weather = await _context.Weather.FindAsync(id);

            if (weather != null)
            {
                Weather = weather;
                _context.Weather.Remove(Weather);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
