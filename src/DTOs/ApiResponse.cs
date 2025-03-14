namespace TaskManagerBackendSmartTalent.src.DTOs
{
    /// <summary>
    /// Modelo genérico para estructurar respuestas de la API.
    /// </summary>
    /// <typeparam name="T">Tipo de datos en la respuesta</typeparam>
    public class ApiResponse<T>
    {
        public bool Success { get; private set; }
        public int StatusCode { get; private set; }
        public string Message { get; private set; }
        public T? Data { get; private set; }

        /// <summary>
        /// Constructor de éxito.
        /// </summary>
        public ApiResponse(T data, string message = "Operación exitosa", int statusCode = 200)
        {
            Success = true;
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

        /// <summary>
        /// Constructor de error (sobrecarga estática).
        /// </summary>
        public static ApiResponse<T> Fail(string message, int statusCode = 400)
        {
            return new ApiResponse<T>(default, message, statusCode, false);
        }

        private ApiResponse(T? data, string message, int statusCode, bool success)
        {
            Success = success;
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }
    }
}
