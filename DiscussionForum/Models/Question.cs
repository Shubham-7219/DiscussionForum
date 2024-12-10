using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscussionForum.Models
{
    public class Question
    {
        [Key] // Marks Question_Id as the primary key
        public int Question_Id { get; set; }

        [Required] // Marks Question_Title as a required field
        [StringLength(200)] // Sets a maximum length for the title (optional, based on your needs)
        public string Question_Title { get; set; }

        [Required] // Marks Question_Description as a required field
        [StringLength(1000)] // Sets a maximum length for the description (optional, based on your needs)
        public string Question_Description { get; set; }

        [Required] // Marks QuestionCreateAt as required, to track the timestamp
        public DateTime QuestionCreateAt { get; set; }
        public ICollection<Answer> Answers { get; set; }
        public string? User_Id { get; set; }
        [NotMapped]

        [BindNever]
        public IdentityUser User { get; set; }
    }
}
