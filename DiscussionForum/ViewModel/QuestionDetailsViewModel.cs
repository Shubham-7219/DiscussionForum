using DiscussionForum.Models;

namespace DiscussionForum.ViewModel
{
    public class QuestionDetailsViewModel
    {
        public Question Question { get; set; } = new Question();
        public List<Answer> Answers { get; set; } = new List<Answer>();
        public Answer NewAnswer { get; set; } = new Answer();
    }
}
