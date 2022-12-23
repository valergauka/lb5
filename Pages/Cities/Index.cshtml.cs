using lb5.Context;
using lb5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lb5.Pages.Cities
{
    public class IndexModel : PageModel
    {
        private readonly ConversationContext _context;

        public IndexModel(ConversationContext context)
        {
            _context = context;
        }
        public List<City> Cities { get; set; }
        public void OnGet()
        {
            Cities = _context.Cities.ToList();
        }
    }
}
