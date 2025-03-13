using TaskManagerBackendSmartTalent.src.Entities;
using TaskManagerBackendSmartTalent.src.Repositories;

namespace TaskManagerBackendSmartTalent.src.Services
{
    /// <summary>
    /// Servicio para la gestión de tareas. 
    /// Proporciona métodos para realizar operaciones CRUD sobre las tareas.
    /// </summary>
    public class TaskService
    {
        private readonly ITaskRepository _taskRepository;

        /// <summary>
        /// Constructor que inicializa el servicio con el repositorio de tareas.
        /// </summary>
        /// <param name="taskRepository">Instancia del repositorio de tareas</param>
        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        /// <summary>
        /// Obtiene todas las tareas almacenadas en la base de datos.
        /// </summary>
        /// <returns>Lista de tareas</returns>
        public async Task<IEnumerable<TaskEntity>> GetAllTasksAsync() => await _taskRepository.GetAllTasksAsync();

        /// <summary>
        /// Obtiene una tarea específica por su ID.
        /// </summary>
        /// <param name="id">Identificador único de la tarea</param>
        /// <returns>Tarea encontrada o null si no existe</returns>
        public async Task<TaskEntity?> GetTaskByIdAsync(int id) => await _taskRepository.GetTaskByIdAsync(id);

        /// <summary>
        /// Crea una nueva tarea en la base de datos.
        /// </summary>
        /// <param name="task">Objeto de tarea a crear</param>
        /// <returns>La tarea creada</returns>
        public async Task<TaskEntity> CreateTaskAsync(TaskEntity task) => await _taskRepository.CreateTaskAsync(task);

        /// <summary>
        /// Actualiza una tarea existente en la base de datos.
        /// </summary>
        /// <param name="task">Objeto de tarea con los datos actualizados</param>
        /// <returns>True si la actualización fue exitosa, False si no</returns>
        public async Task<bool> UpdateTaskAsync(TaskEntity task)
        {
            var existingTask = await _taskRepository.GetTaskByIdAsync(task.Id);
            if (existingTask == null) throw new KeyNotFoundException("Tarea no encontrada");

            return await _taskRepository.UpdateTaskAsync(task);
        }

        /// <summary>
        /// Elimina una tarea de la base de datos por su ID.
        /// </summary>
        /// <param name="id">Identificador único de la tarea</param>
        /// <returns>True si la eliminación fue exitosa, False si no</returns>
        public async Task<bool> DeleteTaskAsync(int id)
        {
            var existingTask = await _taskRepository.GetTaskByIdAsync(id);
            if (existingTask == null) throw new KeyNotFoundException("Tarea no encontrada");

            return await _taskRepository.DeleteTaskAsync(id);
        }
    }
}

