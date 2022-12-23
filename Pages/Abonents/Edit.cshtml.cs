using lb5.Context;
using lb5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lb5.Pages.Abonents
{
    public class EditModel : PageModel
    {
        private readonly ConversationContext _context;
        public Abonent Abonent { get; set; } 
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

            Abonent = await _context.Abonents.FindAsync(id);

            if (Abonent == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(Abonent abonent)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Abonents.Update(abonent);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
