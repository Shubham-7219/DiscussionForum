namespace DiscussionForum.ViewModel
{
    public class QuestionViewModel
    {
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Username { get; set; }
    }
}
