using DiscussionForum.Data;
using DiscussionForum.Models;
using DiscussionForum.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DiscussionForum.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly ApplicationDbContext _context;
        public QuestionController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateQue()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateQue(Question question)
        {
            ModelState.Remove("User");
            if (ModelState.IsValid)
            {
                question.User_Id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _context.Add(question);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Appointment created successfully!";
                return RedirectToAction("Index", "Home");
            }
            return View(question);
        }

        public IActionResult Details(int id)
        {
            var question = _context.Questions
                                   .Include(q => q.Answers)
                                   .ThenInclude(a => a.User) // Include User if applicable
                                   .FirstOrDefault(q => q.Question_Id == id);

            if (question == null)
                return NotFound();

            var model = new QuestionDetailsViewModel
            {
                Question = question,
                Answers = question.Answers.ToList(),
                NewAnswer = new Answer()
            };

            return View(model);
        }


        [HttpPost]
        public IActionResult AddAnswer(QuestionDetailsViewModel model)
        {
            // Remove validation for properties not being posted
            ModelState.Remove("User");
            ModelState.Remove("Answers");
            ModelState.Remove("Question");
            ModelState.Remove("NewAnswer.User");
            ModelState.Remove("NewAnswer.Question");

            if (ModelState.IsValid)
            {
                var question = _context.Questions.Include(q => q.Answers).FirstOrDefault(q => q.Question_Id == model.NewAnswer.Question_Id);
                model.Question = question;
                model.Answers = question.Answers.ToList();
                return View("Details", model);
            }

            // Save the new answer
            var answer = new Answer
            {
                Answer_Name = model.NewAnswer.Answer_Name,
                Answer_Date = DateTime.Now,
                Question_Id = model.NewAnswer.Question_Id,
                User_Id = User.FindFirstValue(ClaimTypes.NameIdentifier) // Current user
            };

            _context.Answers.Add(answer);
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = model.NewAnswer.Question_Id });
        }




    }
}
