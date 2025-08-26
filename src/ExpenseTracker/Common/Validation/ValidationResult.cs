namespace ExpenseTracker.Api.Common.Validation
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public IReadOnlyList<ValidationError> Errors { get; set; }
    }
}
