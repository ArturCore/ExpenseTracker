using ExpenseTracker.Api.Common.Validation;
using ExpenseTracker.Api.Infrastructure.DTO.Expense;

namespace ExpenseTracker.Api.Features.Expenses.Validation
{
    public class UpdateExpenseRequestValidator : IValidator<UpdateExpenseRequest>
    {
        public ValidationResult Validate(UpdateExpenseRequest request)
        {
            List<ValidationError> errors = new List<ValidationError>();

            if (request.Amount == null
                && request.Description == null
                && request.Category == null
                && request.ExpenseDate == null)
            {
                errors.Add(new ValidationError()
                {
                    Field = "request",
                    Message = "At least one field must be provided for update",
                    Code = "update_requires_at_least_one_field"
                });

                //validation below are pointless in case if all fields are null
                return new ValidationResult() { Errors = errors, IsValid = false };
            }


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

            if (request.Amount != null && request.Amount <= 0)
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
