using System.ComponentModel.DataAnnotations;

namespace AdvancedTodo.Models
{
    public class ToDo
    {
        [Range(1, int.MaxValue,ErrorMessage = "please enter a value bigger then {1}")]
        public int UserId { get; set; }
        public int TodoId { get; set; }
        [Required, MaxLength(128)]
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}