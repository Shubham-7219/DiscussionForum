using DiscussionForum.Data;
using DiscussionForum.Models;
using DiscussionForum.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DiscussionForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;


        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var questions = _context.Questions
         .Include(q => q.User) // Ensure User is included as a navigation property
         .Select(q => new QuestionViewModel
         {
             QuestionId = q.Question_Id,
             Title = q.Question_Title,
             Description = q.Question_Description,
             CreatedAt = q.QuestionCreateAt,
             Username = q.User.UserName // Access UserName safely
         })
         .ToList();

            return View(questions);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
