using System.ComponentModel.DataAnnotations;

namespace TaskManagement.DTOs
{
    public class TaskCommentDto
    {
        public int Id { get; set; }
        public required string Details { get; set; }
        public int TaskId { get; set; }
        public string UserId { get; set; }
    }
}
