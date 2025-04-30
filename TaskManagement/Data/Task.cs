using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement.Data
{
    public class Task
    {
        public int Id { get; set; }
         public required string Name { get; set; }
        
        public required string Description { get; set; }
        
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public UserApplication User { get; set; }
        public ICollection<TaskComment> TaskComments { get; set; }
    }
}
