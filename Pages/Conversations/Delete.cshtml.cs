using lb5.Context;
using lb5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lb5.Pages.Conversations
{
    public class DeleteModel : PageModel
    {
        private readonly ConversationContext _context;
        public Conversation Conversation { get; set; }
        public Abonent? Abonent { get; set; }
        public City? City { get; set; }
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

            Conversation = await _context.Conversations.FindAsync(id);

            if (Conversation == null)
            {
                return NotFound();
            }
            Abonent = _context.Abonents.First(p => p.Id == Conversation.AbonentId);
            City = _context.Cities.First(p => p.Id == Conversation.CityId);

            return Page();
        }

        public async Task<IActionResult> OnPost(int? id)
        {
            var conversation = await _context.Conversations.FindAsync(id);
            if (conversation == null)
            {
                return NotFound();
            }
            _context.Conversations.Remove(conversation);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");

        }
    }
}
