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

        /// <summary>
        /// Constructor del controlador que recibe el servicio de tareas.
        /// </summary>
        /// <param name="taskService">Instancia de TaskService</param>
        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// Obtiene todas las tareas registradas.
        /// </summary>
        /// <returns>Lista de tareas</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllTasks() => Ok(await _taskService.GetAllTasksAsync());

        /// <summary>
        /// Obtiene una tarea específica por su ID.
        /// </summary>
        /// <param name="id">Identificador de la tarea</param>
        /// <returns>Tarea correspondiente al ID</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            return task == null ? NotFound() : Ok(task);
        }

        /// <summary>
        /// Crea una nueva tarea.
        /// </summary>
        /// <param name="taskDto">Datos de la nueva tarea</param>
        /// <returns>La tarea creada</returns>
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskDto? taskDto)
        {
            if (taskDto == null || string.IsNullOrEmpty(taskDto.Title))
            {
                return BadRequest("The title is required");
            }

            var newTask = new TaskEntity
            {
                Title = taskDto.Title,
                Description = taskDto.Description,
                IsCompleted = taskDto.IsCompleted
            };

            var createdTask = await _taskService.CreateTaskAsync(newTask);
            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }

        /// <summary>
        /// Actualiza una tarea existente.
        /// </summary>
        /// <param name="id">Identificador de la tarea</param>
        /// <param name="taskDto">Datos actualizados de la tarea</param>
        /// <returns>Código de estado HTTP</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] TaskDto taskDto)
        {
            var existingTask = await _taskService.GetTaskByIdAsync(id);
            if (existingTask == null) return NotFound();

            existingTask.Title = taskDto.Title;
            existingTask.Description = taskDto.Description;
            existingTask.IsCompleted = taskDto.IsCompleted;

            return await _taskService.UpdateTaskAsync(existingTask) ? NoContent() : NotFound();
        }

        /// <summary>
        /// Elimina una tarea por su ID.
        /// </summary>
        /// <param name="id">Identificador de la tarea</param>
        /// <returns>Código de estado HTTP</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id) =>
            await _taskService.DeleteTaskAsync(id) ? NoContent() : NotFound();
    }
}

