using TaskManagement.DTOs;

namespace TaskManagement.Repo
{
    public interface ITaskManagementService
    {
        public Task<List<TaskDto>> GetTasks();
        public Task<TaskDto> GetTask(int id);
        public Task<List<TaskDto>> GetTasksByUser(string id);
        public Task<int> AddTask(TaskModel taskModel);
        public Task<string> DeleteTask(int id);
    }
}
