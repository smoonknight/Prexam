using System.Net;

namespace Prexam.DTOs
{
    public class ApiResponse<T>
    {
        public int Code { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public ApiResponse() { }

        public ApiResponse(int code, string message, T? data = default)
        {
            Code = code;
            Message = message;
            Data = data;
        }

        public ApiResponse(HttpStatusCode code, string message, T? data = default)
            : this((int)code, message, data) { }
    }

}