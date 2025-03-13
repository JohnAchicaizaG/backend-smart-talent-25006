using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerBackendSmartTalent.src.Entities
{
    /// <summary>
    /// Representa una tarea dentro del sistema.
    /// </summary>
    [Table("Tasks")]
    public class TaskEntity
    {
        /// <summary>
        /// Identificador único de la tarea.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Título de la tarea. Es obligatorio y tiene un límite de 200 caracteres.
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Descripción opcional de la tarea con un máximo de 500 caracteres.
        /// </summary>
        [MaxLength(500)]
        public string? Description { get; set; }

        /// <summary>
        /// Indica si la tarea ha sido completada.
        /// </summary>
        public bool IsCompleted { get; set; } = false;

        /// <summary>
        /// Fecha y hora de creación de la tarea, se guarda en UTC.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

