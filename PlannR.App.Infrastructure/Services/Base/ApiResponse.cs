namespace PlannR.App.Infrastructure.Services.Base
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Errors { get; set; }
        public string Message { get; set; }
    }
}
