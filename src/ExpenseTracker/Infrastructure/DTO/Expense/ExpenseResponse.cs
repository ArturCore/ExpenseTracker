using ExpenseTracker.Api.Features.Expenses.Models;

namespace ExpenseTracker.Api.Infrastructure.DTO.Expense
{
    public record ExpenseResponse
    {
        public long Id { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public ExpenseCategory Category { get; set; }
    }
}
