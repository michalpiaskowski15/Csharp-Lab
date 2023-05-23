using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LAB4_1.Data;
using LAB4_1.Models;

namespace LAB4_1.Pages.Weathers
{
    public class EditModel : PageModel
    {
        private readonly LAB4_1.Data.LAB4_1Context _context;

        public EditModel(LAB4_1.Data.LAB4_1Context context)
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

            var weather =  await _context.Weather.FirstOrDefaultAsync(m => m.Id == id);
            if (weather == null)
            {
                return NotFound();
            }
            Weather = weather;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Weather).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherExists(Weather.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WeatherExists(int id)
        {
          return (_context.Weather?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
