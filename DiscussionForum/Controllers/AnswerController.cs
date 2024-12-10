using DiscussionForum.Data;
using Microsoft.AspNetCore.Mvc;

namespace DiscussionForum.Controllers
{
    public class AnswerController : Controller
    {
        private readonly ApplicationDbContext _context;


        public AnswerController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
