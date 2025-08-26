using ExpenseTracker.Api.Common.Validation;
using ExpenseTracker.Api.Infrastructure.DTO.Expense;

namespace ExpenseTracker.Api.Features.Expenses.Validation
{
    public class CreateExpenseRequestValidator : IValidator<CreateExpenseRequest>
    {
        public ValidationResult Validate(CreateExpenseRequest request)
        {
            List<ValidationError> errors = new List<ValidationError>();

            if (request.Description != null && string.IsNullOrWhiteSpace(request.Description))
            {
                errors.Add(new ValidationError()
                {
                    Field = "Description",
                    Message = "Description consists only white space(-s)",
                    Code = "descriptions_only_white_spaces"
                });
            }
            if (request.Description != null && request.Description.Length > 255)
            {
                errors.Add(new ValidationError()
                {
                    Field = "Description",
                    Message = "Description must be at most 255 symbols",
                    Code = "descriptions_max_255"
                });
            }

            if (request.Amount <= 0)
            {
                errors.Add(new ValidationError()
                {
                    Field = "Amount",
                    Message = "Amount must be greater than 0",
                    Code = "amount_gt_zero"
                });
            }

            bool isValid = true;
            if (errors.Count > 0) isValid = false;

            return new ValidationResult() { Errors = errors, IsValid = isValid };
        }
    }
}
