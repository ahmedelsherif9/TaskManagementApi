using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.DTOs;
using TaskManagement.Repo;
using static System.Reflection.Metadata.BlobBuilder;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskManagement.Controllers
{
    [ApiController]
    [Route("api")]
    //[Authorize]
    
    public class TasksController : ControllerBase
    {
        private readonly ITaskManagementService _taskManagementService;

        public TasksController(ITaskManagementService taskManagementService)
        {
            _taskManagementService = taskManagementService;
        }

        [HttpGet("Tasks")]
        public async Task<IActionResult> GetTasks()
        {
            var tasks = await _taskManagementService.GetTasks();
            if (tasks.Count == 0)
            {
                return NotFound();
            }
            return Ok(tasks);
        }

        [HttpGet("Tasks/{id}")]
        public async Task<IActionResult> GetTask([FromRoute] int id)
        {
            var task = await _taskManagementService.GetTask(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpGet("Tasks/User/{id}")]
        public async Task<IActionResult> GetTasksByUser([FromRoute] string id)
        {
            var tasks = await _taskManagementService.GetTasksByUser(id);
            if (tasks == null)
            {
                return NotFound();
            }
            return Ok(tasks);
        }


        [HttpPost("Tasks")]
        public async Task<ActionResult<string>> CreateTask([FromBody] TaskModel taskModel)
        {
            try
            {
                var id = await _taskManagementService.AddTask(taskModel);
                if (id == 0)
                {
                    return NotFound();
                }
                return Created("api/Tasks/" + id, id);

            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }


        [HttpDelete("Tasks/{id}")]
        public async Task<ActionResult<string>> DeleteTask([FromRoute] int id)
        {
            try
            {
                var result = await _taskManagementService.DeleteTask(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);

            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }


    }

}
