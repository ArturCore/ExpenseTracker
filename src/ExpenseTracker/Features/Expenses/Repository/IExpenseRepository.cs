using ExpenseTracker.Api.Features.Expenses.Models;
using ExpenseTracker.Api.Infrastructure.DTO.Expense;

namespace ExpenseTracker.Api.Features.Expenses.Repository
{
    public interface IExpenseRepository
    {
        Task<Expense> GetByIdAsync(Guid id);
        Task<List<Expense>> GetAllAsync();
        Task<Expense> AddAsync(Expense expense);
        Task<Expense> UpdateAsync(Expense expense);
        Task<bool> DeleteAsync(Guid id);
        Task<List<Expense>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    }
}
