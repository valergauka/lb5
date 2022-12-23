using lb5.Context;
using lb5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lb5.Pages.Cities
{
    public class DeleteModel : PageModel
    {
        private readonly ConversationContext _context;
        public City City { get; set; }
        public DeleteModel(ConversationContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> OnGet(int? id)
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

        public async Task<IActionResult> OnPost(int? id)
        {
            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
