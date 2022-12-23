using lb5.Context;
using lb5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lb5.Pages.Abonents
{
    public class IndexModel : PageModel
    {
        private readonly ConversationContext _context;

        public IndexModel(ConversationContext context)
        {
            _context = context;
        }
        public List<Abonent> Abonents { get; set; }
        public void OnGet()
        {
            Abonents = _context.Abonents.ToList();
        }
    }
}
