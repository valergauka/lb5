using lb5.Context;
using lb5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lb5.Pages.Abonents
{
    public class DeleteModel : PageModel
    {
        private readonly ConversationContext _context;
        public Abonent Abonents { get; set; }
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

            Abonents = await _context.Abonents.FindAsync(id);
            if (Abonents == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            var abonent = await _context.Abonents.FindAsync(id);
            if (abonent == null)
            {
                return NotFound();
            }
            _context.Abonents.Remove(abonent);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
