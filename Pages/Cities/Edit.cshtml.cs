using lb5.Context;
using lb5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lb5.Pages.Cities
{
    public class EditModel : PageModel
    {
        private readonly ConversationContext _context;
        public City City { get; set; }
        public EditModel(ConversationContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            City = await _context.Cities.FindAsync(id);

            if (City == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(City city)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cities.Update(city);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
