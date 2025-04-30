using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data;
using TaskManagement.DTOs;
using static System.Reflection.Metadata.BlobBuilder;

namespace TaskManagement.Repo
{
    public class TaskManagementService : ITaskManagementService
    {
        private readonly UserManager<UserApplication> _userManager;
        private readonly DbContextTaskManagement _context;
        private readonly IMapper _mapper;

        public TaskManagementService(UserManager<UserApplication> userManager, DbContextTaskManagement context, IMapper mapper)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<TaskDto>> GetTasks()
        {
            var tasks = await _context.Tasks.ToListAsync();
            var AllTasks = _mapper.Map<List<TaskDto>>(tasks);
            return AllTasks;

        }

        public async Task<TaskDto> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return null;
            }
            return _mapper.Map<TaskDto>(task);

        }

        public async Task<List<TaskDto>> GetTasksByUser(string id)
        {
            var tasks = await _context.Tasks.Include(t => t.User).Where(t => t.User.Id == id).ToListAsync();
            var tasksByUser = tasks.Where(t => t.UserId == id).ToList();
            if (tasksByUser == null)
            {
                return null;
            }
            return _mapper.Map<List<TaskDto>>(tasksByUser);

        }

        public async Task<int> AddTask(TaskModel taskModel)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync();
            Data.Task task = new Data.Task()
            {
                Name = taskModel.Name,
                Description = taskModel.Description,
                UserId = user.Id
            };
            
            _context.Add(task);
            await _context.SaveChangesAsync();
            return task.Id;
        }

        public async Task<string> DeleteTask(int id)
        {

            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Remove(task);
                await _context.SaveChangesAsync();
                return task.Name;
            }
            return null;



        }
    }
}
    
        


    
