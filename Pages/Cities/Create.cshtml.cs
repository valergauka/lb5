using lb5.Context;
using lb5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lb5.Pages.Cities
{
    public class CreateModel : PageModel
    {
        private readonly ConversationContext _context;
        public City city { get; set; }
        public CreateModel(ConversationContext context)
        {
            _context = context;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync(City city)
        {
            if (ModelState.IsValid)
            {
                _context.Cities.AddAsync(city);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
