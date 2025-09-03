namespace ExpenseTracker.Api.Infrastructure.DTO.Expense
{
    public record DeleteExpenseResult
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
    }
}
