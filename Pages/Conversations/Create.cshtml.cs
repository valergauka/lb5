using lb5.Context;
using lb5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lb5.Pages.Conversations
{
    public class CreateModel : PageModel
    {
        private readonly ConversationContext _context;
        public Conversation Conversation { get; set; }
        public SelectList AbonentList { get; set; } = null!;
        public SelectList CityList { get; set; } = null!;
        public CreateModel(ConversationContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            AbonentList = new SelectList(_context.Abonents, "Id", "FirstName");
            CityList = new SelectList(_context.Cities, "Id", "Name");
        }
        public async Task<IActionResult> OnPostAsync(Conversation conversation)
        {
            if (conversation.AbonentId != 0 && conversation.CityId != 0)
            {
                _context.Conversations.Add(conversation);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            AbonentList = new SelectList(_context.Abonents, "Id", "FirstName");
            CityList = new SelectList(_context.Cities, "Id", "Name");
            return Page();
        }
    }
}
