using lb5.Context;
using lb5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lb5.Pages.Abonents
{
    public class CreateModel : PageModel
    {
        private readonly ConversationContext _context;
        public Abonent? Abonent { get; set; }
        public CreateModel(ConversationContext context)
        {
            _context = context;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync(Abonent abonent)
        {
            if (ModelState.IsValid)
            {
                _context.Abonents.AddAsync(abonent);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
