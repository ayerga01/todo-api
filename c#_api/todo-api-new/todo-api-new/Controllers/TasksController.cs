using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todo_api_new.Data;
using todo_api_new.Models;
using todo_api_new.Models.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace todo_api_new.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public TasksController(ApplicationDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            //get data from db - domain models
            var tasks = await dbContext.Tasks.ToListAsync();

            //map domain models to DTOs
            var tasksDto = new List<TaskDto>();
            foreach(var task in tasks)
            {
                tasksDto.Add(new TaskDto()
                {
                    id = task.id,
                    title = task.title,
                    description = task.description,
                    date = task.date,
                    priority = task.priority,
                    status = task.status
                });
            }

            return Ok(tasksDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTask(Guid id)
        {
            //get data from db - domain models
            var task = await dbContext.Tasks.FindAsync(id);
            if(task == null)
            {
                return NotFound();
            }

            //map domain models to DTOs
            var taskDto = new TaskDto()
            {
                id = task.id,
                title = task.title,
                description = task.description,
                date = task.date,
                priority = task.priority,
                status = task.status
            };

            return Ok(taskDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskRequestDto taskRequest)
        {
            //map or convert dto model
            var taskDomain = new TaskEntity
            {
                title = taskRequest.title,
                description = taskRequest.description,
                date = taskRequest.date,
                priority = taskRequest.priority,
                status = taskRequest.status
            };

            //use domain model to create region
            await dbContext.Tasks.AddAsync(taskDomain);
            await dbContext.SaveChangesAsync();

            //map domain back to dto
            var taskDto = new TaskDto
            {
                id = taskDomain.id,
                title = taskDomain.title,
                description = taskDomain.description,
                date = taskDomain.date,
                priority = taskDomain.priority,
                status = taskDomain.status      
            };
            return CreatedAtAction(nameof(GetTask), new {id = taskDto.id }, taskDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTask([FromBody] TaskUpdateRequestDto taskUpdateRequest)
        {
            //get data from db - domain models
            var task = await dbContext.Tasks.FindAsync(taskUpdateRequest.id);
            if (task == null)
            {
                return NotFound();
            }

            //map dto to domain
            task.status = taskUpdateRequest.status;

            await dbContext.SaveChangesAsync();

            //domain to dto
            var updatedTaskDto = new TaskDto()
            {
                id = task.id,
                title = task.title,
                description = task.description,
                date = task.date,
                priority = task.priority,
                status = task.status
            };

            return Ok(updatedTaskDto);
        }
    }
}
