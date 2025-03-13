using Microsoft.EntityFrameworkCore;
using TaskManagerBackendSmartTalent.Data;
using TaskManagerBackendSmartTalent.src.Entities;

namespace TaskManagerBackendSmartTalent.src.Repositories
{
    /// <summary>
    /// Repositorio para la gestión de tareas en la base de datos.
    /// </summary>
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _context;

        /// <summary>
        /// Constructor que recibe el contexto de base de datos.
        /// </summary>
        /// <param name="context">Contexto de la base de datos</param>
        public TaskRepository(TaskDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todas las tareas de la base de datos.
        /// </summary>
        /// <returns>Lista de tareas</returns>
        public async Task<IEnumerable<TaskEntity>> GetAllTasksAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        /// <summary>
        /// Obtiene una tarea específica por su ID.
        /// </summary>
        /// <param name="id">Identificador de la tarea</param>
        /// <returns>Tarea encontrada o null si no existe</returns>
        public async Task<TaskEntity?> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        /// <summary>
        /// Crea una nueva tarea en la base de datos.
        /// </summary>
        /// <param name="task">Objeto de tarea a crear</param>
        /// <returns>Tarea creada</returns>
        public async Task<TaskEntity> CreateTaskAsync(TaskEntity task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        /// <summary>
        /// Actualiza una tarea existente en la base de datos.
        /// </summary>
        /// <param name="task">Objeto de tarea con los datos actualizados</param>
        /// <returns>True si la actualización fue exitosa, False si no</returns>
        public async Task<bool> UpdateTaskAsync(TaskEntity task)
        {
            _context.Entry(task).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// Elimina una tarea de la base de datos por su ID.
        /// </summary>
        /// <param name="id">Identificador de la tarea</param>
        /// <returns>True si la eliminación fue exitosa, False si no</returns>
        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

