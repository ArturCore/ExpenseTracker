using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.Api.Features.Expenses.Validation
{
    public static class ValidationsProblemBuilder
    {
        public static ValidationProblemDetails Build(string title, ValidationResult result)
        {
            return new ValidationProblemDetails
            {
                Status = 400,
                Title = "Validation failed: " + title,
                Errors = result.Errors
                    .GroupBy(e => e.Field)
                    .ToDictionary(
                        group => group.Key, 
                        group => group.Select(e => e.Message).ToArray()
                    )
            };
        }
    }
}
