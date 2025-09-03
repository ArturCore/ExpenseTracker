using ExpenseTracker.Api.Features.Expenses.Models;
using System.Collections.Concurrent;

namespace ExpenseTracker.Api.Features.Expenses.Repository
{
    public class InMemoryExpensesRepository : IExpenseRepository
    {
        ConcurrentDictionary<Guid, Expense> _expenses = new();

        public Task<Expense> AddAsync(Expense expense)
        {
            if (expense == null)
            {
                throw new ArgumentNullException(nameof(expense));
            }
            Guid expenseId = Guid.NewGuid();
            expense.Id = expenseId;
            _expenses.TryAdd(expenseId, expense);
            return Task.FromResult(expense);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return Task.FromResult(false);
            }
            bool removeRusult = _expenses.TryRemove(id, out _);
            return Task.FromResult(removeRusult);
        }

        public Task<List<Expense>> GetAllAsync()
        {
            return Task.FromResult(_expenses.Values.ToList());
        }

        public Task<Expense?> GetByIdAsync(Guid id)
        {
            _expenses.TryGetValue(id, out var e);
            return Task.FromResult(e);
        }

        public Task<Expense> UpdateAsync(Expense expense)
        {
            if (expense == null)
            {
                throw new ArgumentNullException(nameof(expense));
            }
            if (expense.Id == Guid.Empty || !_expenses.ContainsKey(expense.Id))
            {
                return Task.FromResult(expense);
            }

            bool updateResult = _expenses.TryUpdate(expense.Id, expense, _expenses[expense.Id]);
            return Task.FromResult(_expenses[expense.Id]);
        }

        public Task<List<Expense>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            List<Expense> expensesInRange = _expenses.Values
                .Where(e => e.ExpenseDate.Date >= startDate.Date && e.ExpenseDate.Date <= endDate.Date)
                .ToList();
            return Task.FromResult(expensesInRange);
        }
    }
}
