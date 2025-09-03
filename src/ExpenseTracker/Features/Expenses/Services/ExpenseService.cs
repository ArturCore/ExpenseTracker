using ExpenseTracker.Api.Common.Results;
using ExpenseTracker.Api.Common.Validation;
using ExpenseTracker.Api.Features.Expenses.Models;
using ExpenseTracker.Api.Features.Expenses.Repository;
using ExpenseTracker.Api.Infrastructure.DTO.Expense;

namespace ExpenseTracker.Api.Features.Expenses.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository repo;
        private readonly IValidator<CreateExpenseRequest> createValidator;
        private readonly IValidator<UpdateExpenseRequest> updateValidator;

        public ExpenseService(IExpenseRepository _repo, 
            IValidator<CreateExpenseRequest> _createValidator,
            IValidator<UpdateExpenseRequest> _updateValidator)
        {
            repo = _repo;
            createValidator = _createValidator;
            updateValidator = _updateValidator;
        }

        public async Task<ServiceResult<ExpenseResponse>> CreateExpenseAsync(CreateExpenseRequest request)
        {
            ValidationResult validation = createValidator.Validate(request);
            if(!validation.IsValid)
            {
                return ServiceResult<ExpenseResponse>.ValidationError(validation);
            }

            Expense newExpense = await repo.AddAsync(new Expense()
            {
                Description = request.Description,
                Amount = request.Amount,
                ExpenseDate = request.ExpenseDate ?? DateTime.Now,
                Category = request.Category ?? ExpenseCategory.Other
            });
            return ServiceResult<ExpenseResponse>.Success(new ExpenseResponse
            {
                Id = newExpense.Id,
                Description = newExpense.Description,
                Amount = newExpense.Amount,
                ExpenseDate = newExpense.ExpenseDate,
                Category = newExpense.Category
            });
        }


        public async Task<bool> DeleteExpenseAsync(Guid id)
        {
            return await repo.DeleteAsync(id);
        }

        public async Task<ServiceResult<List<ExpenseResponse>>> GetAllAsync()
        {
            List<Expense> expenses = await repo.GetAllAsync();
            List<ExpenseResponse> expenseResponses = expenses.Select(e => new ExpenseResponse
            {
                Id = e.Id,
                Description = e.Description,
                Amount = e.Amount,
                ExpenseDate = e.ExpenseDate,
                Category = e.Category
            }).ToList();
            return ServiceResult<List<ExpenseResponse>>.Success(expenseResponses);
            
        }

        public async Task<ServiceResult<List<ExpenseResponse>>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            List<Expense> expenses = await repo.GetByDateRangeAsync(startDate, endDate);
            List<ExpenseResponse> expenseResponses = expenses.Select(e => new ExpenseResponse
            {
                Id = e.Id,
                Description = e.Description,
                Amount = e.Amount,
                ExpenseDate = e.ExpenseDate,
                Category = e.Category
            }).ToList();
            return ServiceResult<List<ExpenseResponse>>.Success(expenseResponses);
        }

        public async Task<ServiceResult<ExpenseResponse>> GetByIdAsync(Guid id)
        {
            Expense expense = await repo.GetByIdAsync(id);
            if (expense == null)
            {
                return ServiceResult<ExpenseResponse>.NotFoundResult();
            }
            return ServiceResult<ExpenseResponse>.Success(new ExpenseResponse()
            {
                Id = expense.Id,
                Description = expense.Description,
                Amount = expense.Amount,
                ExpenseDate = expense.ExpenseDate,
                Category = expense.Category
            });
        }

        public async Task<ServiceResult<ExpenseResponse>> UpdateExpenseAsync(UpdateExpenseRequest request)
        {
            ValidationResult validation = updateValidator.Validate(request);
            if (!validation.IsValid)
            {
                return ServiceResult<ExpenseResponse>.ValidationError(validation);
            }

            Expense currentExpense = await repo.GetByIdAsync(request.Id);
            Expense updatedExpense = await repo.UpdateAsync(new Expense
            {
                Id = request.Id,
                Description = request.Description ?? currentExpense.Description,
                Amount = request.Amount ?? currentExpense.Amount,
                ExpenseDate = request.ExpenseDate ?? currentExpense.ExpenseDate,
                Category = request.Category ?? currentExpense.Category
            });
            return ServiceResult<ExpenseResponse>.Success(new ExpenseResponse
            {
                Id = updatedExpense.Id,
                Description = updatedExpense.Description,
                Amount = updatedExpense.Amount,
                ExpenseDate = updatedExpense.ExpenseDate,
                Category = updatedExpense.Category
            });
        }
    }
}
