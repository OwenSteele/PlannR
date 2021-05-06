namespace Plannr.App.Infrastructure.Services.Base
{
    public class ApiResponse<T>
    {
        public T Context { get; set; }
        public bool Successful { get; set; }
        public string Errors { get; set; }
        public string Message { get; set; }
    }
}
