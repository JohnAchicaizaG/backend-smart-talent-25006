
namespace TaskManagerBackendSmartTalent.src.DTOs
{
    /// <summary>
    /// DTO (Data Transfer Object) para representar una tarea en las solicitudes y respuestas de la API.
    /// </summary>
    public class TaskDto
    {
        /// <summary>
        /// Título de la tarea. Es obligatorio.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Descripción opcional de la tarea.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Indica si la tarea ha sido completada.
        /// </summary>
        public bool IsCompleted { get; set; } = false;
    }
}