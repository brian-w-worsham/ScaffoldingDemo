using System.ComponentModel.DataAnnotations;

namespace ScaffoldingDemo.Models
{
    public class ToDoListModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Note { get; set; }
    }
}
