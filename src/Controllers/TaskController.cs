using Microsoft.AspNetCore.Mvc;
using TaskManagerBackendSmartTalent.src.DTOs;
using TaskManagerBackendSmartTalent.src.Services;
using TaskManagerBackendSmartTalent.src.Entities;

namespace TaskManagerBackendSmartTalent.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Obtiene todas las tareas.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(new ApiResponse<IEnumerable<TaskEntity>>(tasks));
        }

        /// <summary>
        /// Obtiene una tarea por ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            return task == null
                ? NotFound(ApiResponse<string>.Fail("Tarea no encontrada", 404))
                : Ok(new ApiResponse<TaskEntity>(task));
        }

        /// <summary>
        /// Crea una nueva tarea.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskDto taskDto)
        {
            if (taskDto == null || string.IsNullOrEmpty(taskDto.Title))
                return BadRequest(ApiResponse<string>.Fail("El título es obligatorio"));

            var newTask = new TaskEntity
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                IsCompleted = taskDto.IsCompleted
            };

            var createdTask = await _taskService.CreateTaskAsync(newTask);
            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id },
                new ApiResponse<TaskEntity>(createdTask, "Tarea creada exitosamente", 201));
        }

        /// <summary>
        /// Actualiza una tarea existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskDto taskDto)
        {
            var existingTask = await _taskService.GetTaskByIdAsync(id);
            if (existingTask == null)
                return NotFound(ApiResponse<string>.Fail("Tarea no encontrada", 404));

            existingTask.Title = taskDto.Title;
            existingTask.Description = taskDto.Description;
            existingTask.IsCompleted = taskDto.IsCompleted;

            var updated = await _taskService.UpdateTaskAsync(existingTask);
            return updated
                ? Ok(new ApiResponse<TaskEntity>(existingTask, "Tarea actualizada exitosamente"))
                : StatusCode(500, ApiResponse<string>.Fail("Error al actualizar la tarea", 500));
        }

        /// <summary>
        /// Elimina una tarea por ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var deleted = await _taskService.DeleteTaskAsync(id);
            return deleted
                ? NoContent()
                : NotFound(ApiResponse<string>.Fail("Tarea no encontrada", 404));
        }
    }
}
