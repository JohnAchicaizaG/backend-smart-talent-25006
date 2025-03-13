using System.Threading.Tasks;
using TaskManagerBackendSmartTalent.src.Entities;

namespace TaskManagerBackendSmartTalent.src.Repositories
{
    /// <summary>
    /// Interfaz para la gestión de tareas en la base de datos.
    /// Define las operaciones CRUD básicas para las tareas.
    /// </summary>
    public interface ITaskRepository
    {
        /// <summary>
        /// Obtiene todas las tareas almacenadas en la base de datos.
        /// </summary>
        /// <returns>Lista de tareas.</returns>
        Task<IEnumerable<TaskEntity>> GetAllTasksAsync();

        /// <summary>
        /// Obtiene una tarea específica por su ID.
        /// </summary>
        /// <param name="id">Identificador único de la tarea.</param>
        /// <returns>La tarea encontrada o null si no existe.</returns>
        Task<TaskEntity?> GetTaskByIdAsync(int id);

        /// <summary>
        /// Crea una nueva tarea en la base de datos.
        /// </summary>
        /// <param name="task">Objeto de tarea a crear.</param>
        /// <returns>La tarea creada.</returns>
        Task<TaskEntity> CreateTaskAsync(TaskEntity task);

        /// <summary>
        /// Actualiza una tarea existente en la base de datos.
        /// </summary>
        /// <param name="task">Objeto de tarea con los datos actualizados.</param>
        /// <returns>True si la actualización fue exitosa, False si no.</returns>
        Task<bool> UpdateTaskAsync(TaskEntity task);

        /// <summary>
        /// Elimina una tarea de la base de datos por su ID.
        /// </summary>
        /// <param name="id">Identificador único de la tarea.</param>
        /// <returns>True si la eliminación fue exitosa, False si no.</returns>
        Task<bool> DeleteTaskAsync(int id);
    }
}