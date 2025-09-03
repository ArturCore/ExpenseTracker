using ExpenseTracker.Api.Common.Validation;

namespace ExpenseTracker.Api.Common.Results
{
    public class ServiceResult<T> where T : class
    {
        public bool IsSuccess { get; private set; }
        public bool NotFound { get; private set; }
        public T? Value { get; private set; }
        public ValidationResult? Validation { get; private set; }
        public string? Message { get; set; }

        public static ServiceResult<T> NotFoundResult()
        {
            return new ServiceResult<T>
            {
                IsSuccess = false,
                NotFound = true,
                Value = null,
                Validation = null,
                Message = "Not found result using input data"
            };
        }
        public static ServiceResult<T> Success(T value)
        {
            return new ServiceResult<T>
            {
                IsSuccess = true,
                NotFound = false,
                Value = value,
                Validation = null,
                Message = null
            };
        }
        public static ServiceResult<T> ValidationError(ValidationResult validation)
        {
            return new ServiceResult<T>
            {
                IsSuccess = false,
                NotFound = false,
                Value = null,
                Validation = validation,
                Message = "Validation error"
            };
        }
        public static ServiceResult<T> UnexpectedError(string message)
        {
            return new ServiceResult<T>
            {
                IsSuccess = false,
                NotFound = false,
                Value = null,
                Validation = null,
                Message = $"Unexpected error occurred: {message}"
            };
        }
    }
}
