using Microsoft.AspNetCore.Mvc;
using TaskTrackerAPI.Models;
using TaskTrackerAPI.Repositories;

namespace TaskTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _repository;

        public TaskController(ITaskRepository repository)
        {
            _repository = repository;
        }

        // GET: api/task
        [HttpGet]
        public ActionResult<IEnumerable<TaskDto>> GetAll()
        {
            var tasks = _repository.GetAll()
                .Select(t => ToDto(t))
                .ToList();
            return Ok(tasks);
        }

        // GET: api/task/{id}
        [HttpGet("{id}")]
        public ActionResult<TaskDto> GetById(int id)
        {
            var task = _repository.GetById(id);
            if (task == null) return NotFound();
            return Ok(ToDto(task));
        }

        // POST: api/task
        [HttpPost]
        public ActionResult<TaskDto> Create(TaskCreateDto taskDto)
        {
            if (string.IsNullOrWhiteSpace(taskDto.Title))
                return BadRequest("Title is required.");

            var entity = new TaskEntity
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                DueDate = taskDto.DueDate,
                Status = taskDto.Status
            };

            _repository.Add(entity);
            return CreatedAtAction(nameof(GetById), new { id = entity.Id }, ToDto(entity));
        }

        // PUT: api/task/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, TaskDto taskDto)
        {
            var existing = _repository.GetById(id);
            if (existing == null) return NotFound();

            existing.Title = taskDto.Title;
            existing.Description = taskDto.Description;
            existing.DueDate = taskDto.DueDate;
            existing.Status = taskDto.Status;

            _repository.Update(existing);
            return NoContent();
        }

        // DELETE: api/task/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _repository.GetById(id);
            if (existing == null) return NotFound();

            _repository.Delete(id);
            return NoContent();
        }

        // Helper method to map entity to DTO
        private static TaskDto ToDto(TaskEntity entity) => new TaskDto
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            DueDate = entity.DueDate,
            Status = entity.Status
        };
    }
}
