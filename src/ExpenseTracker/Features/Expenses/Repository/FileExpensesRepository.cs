using ExpenseTracker.Api.Features.Expenses.Models;
using System;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace ExpenseTracker.Api.Features.Expenses.Repository
{

    public class FileExpensesRepository : IExpenseRepository
    {
        private readonly string filePath = "AppData/expenses.json";

        public Task<Expense> AddAsync(Expense expense)
        {
            if (expense == null)
            {
                throw new ArgumentNullException(nameof(expense));
            }
            Guid expenseId = Guid.NewGuid();
            expense.Id = expenseId;

            var currentData = File.ReadAllText(filePath);
            List<Expense> currentExpenses = JsonSerializer.Deserialize<List<Expense>>(currentData) ?? new List<Expense>();
            currentExpenses.Add(expense);
            File.WriteAllText(filePath, JsonSerializer.Serialize(currentExpenses));

            return Task.FromResult(expense);
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return Task.FromResult(false);
            }

            var currentData = File.ReadAllText(filePath);
            List<Expense> currentExpenses = JsonSerializer.Deserialize<List<Expense>>(currentData) ?? new List<Expense>();
            currentExpenses.RemoveAll(e => e.Id == id);
            File.WriteAllText(filePath, JsonSerializer.Serialize(currentExpenses));

            return Task.FromResult(true);
        }

        public Task<List<Expense>> GetAllAsync()
        {
            var currentData = File.ReadAllText(filePath);
            List<Expense> expenses = JsonSerializer.Deserialize<List<Expense>>(currentData) ?? new List<Expense>();
            return Task.FromResult(expenses);
        }

        public Task<List<Expense>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<Expense> GetByIdAsync(Guid id)
        {
            var currentData = File.ReadAllText(filePath);
            List<Expense> expenses = JsonSerializer.Deserialize<List<Expense>>(currentData) ?? new List<Expense>();
            return Task.FromResult(expenses.FirstOrDefault(e => e.Id == id) ?? new Expense());
        }

        public Task<Expense> UpdateAsync(Expense expense)
        {
            if (expense == null)
            {
                throw new ArgumentNullException(nameof(expense));
            }

            var currentData = File.ReadAllText(filePath);
            List<Expense> expenses = JsonSerializer.Deserialize<List<Expense>>(currentData) ?? new List<Expense>();
            int index = expenses.FindIndex(e => e.Id == expense.Id);

            if (expense.Id == Guid.Empty || index == -1)
            {
                throw new KeyNotFoundException(nameof(expense));
            }

            expenses[index] = expense;
            File.WriteAllText(filePath, JsonSerializer.Serialize(expenses));

            return Task.FromResult(expense);
        }
    }
}
