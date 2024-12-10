using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscussionForum.Models
{
    public class Answer
    {
        [Key] // Marks Answer_Id as the primary key
        public int Answer_Id { get; set; }

        [Required] // Marks Answer_Name as required
        [StringLength(1000)] // Sets a maximum length for the answer (optional, based on your needs)
        public string? Answer_Name { get; set; }

        [Required] // Marks Answer_Date as required to track the timestamp
        public DateTime Answer_Date { get; set; }


        public int Question_Id { get; set; }

        [BindNever] // Prevents the Question property from being bound to model binding
        [NotMapped] // Specifies that this property should not be mapped to a database column
        public Question Question { get; set; }


        public string? User_Id { get; set; }
        [NotMapped]

        [BindNever]
        public IdentityUser User { get; set; }

    }
}
