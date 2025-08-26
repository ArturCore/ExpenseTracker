namespace ExpenseTracker.Api.Common.Validation
{
    public interface IValidator<T>
    {
        ValidationResult Validate(T instance);
    }
}
