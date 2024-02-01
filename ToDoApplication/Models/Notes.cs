using System.ComponentModel.DataAnnotations;

namespace ToDoApplication.Models
{
    public class Notes
    {
        public long id { get; set; }
        [Required]
        public string? description { get; set; }  
    }
}
