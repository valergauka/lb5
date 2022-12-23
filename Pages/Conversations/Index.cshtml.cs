using lb5.Context;
using lb5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace lb5.Pages.Conversations
{
    public class IndexModel : PageModel
    {
        private readonly ConversationContext _context;

        public IndexModel(ConversationContext context)
        {
            _context = context;
        }
        public List<Conversation> Conversations { get; set; } = null!;
        public void OnGet()
        {
            Conversations = _context.Conversations.Include(prop => prop.Abonent).Include(prop => prop.City).ToList();
        }
    }
}
