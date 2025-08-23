namespace ExpenseTracker.Api.Features.Expenses.Models
{
    public class Expense
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public ExpenseCategory Category { get; set; }
    }
}
