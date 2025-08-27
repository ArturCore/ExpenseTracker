using ExpenseTracker.Api.Features.Expenses.Models;

namespace ExpenseTracker.Api.Features.Expenses.Repository
{
    public interface IExpenseRepository
    {
        Task<Expense?> GetByIdAsync(Guid id);
        Task<List<Expense?>> GetAllAsync();
        Task AddAsync(Expense expense);
        Task UpdateAsync(Expense expense);
        Task DeleteAsync(Guid id);
    }
}
