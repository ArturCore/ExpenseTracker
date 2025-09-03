using ExpenseTracker.Api.Features.Expenses.Services;
using ExpenseTracker.Api.Infrastructure.DTO.Expense;

namespace ExpenseTracker.Api.Features.Expenses.Endpoints
{
    public static class ExpensesEndpoints
    {
        public static IEndpointRouteBuilder MapExpenseEndpoints(this IEndpointRouteBuilder app)
        {
            var expenses = app.MapGroup("/api/expenses").WithTags("Expenses");

            expenses.MapGet("/", async (IExpenseService service) =>
            {
                var result = await service.GetAllAsync();
                if (!result.IsSuccess)
                    return Results.Problem(result.Message);
                return Results.Ok(result);
            });

            expenses.MapGet("/{id:guid}", async (Guid id, IExpenseService service) =>
            {
                var result = await service.GetByIdAsync(id);
                if (!result.IsSuccess)
                    return Results.Problem(result.Message);
                return Results.Ok(result);
            });

            expenses.MapPost("/", async (CreateExpenseRequest request, IExpenseService service) =>
            {
                var result = await service.CreateExpenseAsync(request);
                if (!result.IsSuccess)
                    return Results.Problem(result.Message);
                return Results.Ok(result);
            });

            expenses.MapPut("/", async (UpdateExpenseRequest request, IExpenseService service) => 
            {
                var result = await service.UpdateExpenseAsync(request);
                if (!result.IsSuccess)
                    return Results.Problem(result.Message);
                return Results.Ok(result);
            });

            expenses.MapDelete("/{id:guid}", async (Guid id, IExpenseService service) =>
            {
                var result = await service.DeleteExpenseAsync(id);
                if (!result.IsSuccess)
                    return Results.Problem(result.Message);
                return Results.Ok(result);
            });

            expenses.MapGet("/range", async (DateTime startDate, DateTime endDate, IExpenseService service) =>
            {
                var result = await service.GetByDateRangeAsync(startDate, endDate);
                if (!result.IsSuccess)
                    return Results.Problem(result.Message);
                return Results.Ok(result);
            });

            return app;
        }
    }
}
