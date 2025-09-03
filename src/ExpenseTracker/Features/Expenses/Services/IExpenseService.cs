using ExpenseTracker.Api.Common.Results;
using ExpenseTracker.Api.Infrastructure.DTO.Expense;

namespace ExpenseTracker.Api.Features.Expenses.Services
{
    public interface IExpenseService
    {
        Task<ServiceResult<ExpenseResponse>> GetByIdAsync(Guid id);
        Task<ServiceResult<ExpenseResponse>> CreateExpenseAsync(CreateExpenseRequest request);
        Task<ServiceResult<ExpenseResponse>> UpdateExpenseAsync(UpdateExpenseRequest request);
        Task<ServiceResult<DeleteExpenseResult>> DeleteExpenseAsync(Guid id);
        Task<ServiceResult<List<ExpenseResponse>>> GetAllAsync();
        Task<ServiceResult<List<ExpenseResponse>>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
