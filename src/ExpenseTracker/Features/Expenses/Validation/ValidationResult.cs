namespace ExpenseTracker.Api.Features.Expenses.Validation
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public IReadOnlyList<ValidationError> Errors { get; set; }
    }
}
