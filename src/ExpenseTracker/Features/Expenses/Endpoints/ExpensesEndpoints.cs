namespace ExpenseTracker.Api.Features.Expenses.Endpoints
{
    public static class ExpensesEndpoints
    {
        public static IEndpointRouteBuilder MapExpenseEndpoints(this IEndpointRouteBuilder app)
        {
            var expenses = app.MapGroup("/api/expenses").WithTags("Expenses");

            expenses.MapGet("/", () => Results.Ok(new { Id = 1, Amount = 100500, Description = "Test"}));
            expenses.MapPost("/", () => "Hello");
            expenses.MapPut("/", () => "Hello");
            expenses.MapDelete("/", () => "Hello");

            return app;
        }
    }
}
