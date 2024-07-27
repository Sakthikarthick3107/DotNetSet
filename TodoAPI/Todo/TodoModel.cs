using System.ComponentModel.DataAnnotations;

namespace TodoAPI.Todo
{
    public class TodoModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(10,ErrorMessage = "Title should be a minimum length of 10")]
        public string Title { get; set; }

        [Required]
        [MinLength(10,ErrorMessage = "Description should be a length of minimum 10")]
        [MaxLength(50,ErrorMessage = "Description should not exceed length 50")]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public bool IsCompleted { get; set; }
    }
}
