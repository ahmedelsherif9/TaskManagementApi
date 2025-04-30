using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement.Data
{
    public class TaskComment
    {
        public int Id { get; set; }
        public required string Details { get; set; }
        public int TaskId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public UserApplication User { get; set; }
        [ForeignKey("TaskId")]
        public Task Task { get; set; }
    }
}
