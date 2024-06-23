using JWTLoginAPI.Interface;

namespace JWTLoginAPI.Services
{
    public class ResultService<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string? ErrorMessage { get; set; }

        public static ResultService<T> SuccessResult(T data)
        {
            return new ResultService<T> { Success = true, Data = data };
        }

        public static ResultService<T> FailureResult(string errorMessage)
        {
            return new ResultService<T> { Success = false, ErrorMessage = errorMessage };
        }
    }

}
