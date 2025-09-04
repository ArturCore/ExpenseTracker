using ExpenseTracker.Api.Features.Expenses.Services;
using ExpenseTracker.Api.Infrastructure.DTO.Expense;

namespace ExpenseTracker.Api.Features.Expenses.Endpoints
{
    public static class ExpensesEndpoints
    {
        public static IEndpointRouteBuilder MapExpenseEndpoints(this IEndpointRouteBuilder app)
        {
            var expenses = app.MapGroup("/api/expenses").WithTags("Expenses");

            expenses.MapGet("/", GetAllExpenses);
            expenses.MapGet("/{id:guid}", GetByIdAsync);
            expenses.MapPost("/", CreateExpenseAsync);
            expenses.MapPut("/", UpdateExpenseAsync);
            expenses.MapDelete("/{id:guid}", DeleteExpenseAsync);
            expenses.MapGet("/range", GetByDateRangeAsync);

            return app;
        }

        private static async Task<IResult> GetAllExpenses(IExpenseService service)
        {
            var result = await service.GetAllAsync();
            if (!result.IsSuccess)
                return Results.Problem(result.Message);
            return Results.Ok(result);
        }

        private static async Task<IResult> GetByIdAsync(Guid id, IExpenseService service)
        {
            var result = await service.GetByIdAsync(id);
            if (!result.IsSuccess)
                return Results.Problem(result.Message);
            return Results.Ok(result);
        }

        private static async Task<IResult> CreateExpenseAsync(CreateExpenseRequest request, IExpenseService service)
        {
            var result = await service.CreateExpenseAsync(request);
            if (!result.IsSuccess)
                return Results.Problem(result.Message);
            return Results.Ok(result);
        }

        private static async Task<IResult> UpdateExpenseAsync(UpdateExpenseRequest request, IExpenseService service)
        {
            var result = await service.UpdateExpenseAsync(request);
            if (!result.IsSuccess)
                return Results.Problem(result.Message);
            return Results.Ok(result);
        }

        private static async Task<IResult> DeleteExpenseAsync(Guid id, IExpenseService service)
        {
            var result = await service.DeleteExpenseAsync(id);
            if (!result.IsSuccess)
                return Results.Problem(result.Message);
            return Results.Ok(result);
        }

        private static async Task<IResult> GetByDateRangeAsync(DateTime startDate, DateTime endDate, IExpenseService service)
        {
            var result = await service.GetByDateRangeAsync(startDate, endDate);
            if (!result.IsSuccess)
                return Results.Problem(result.Message);
            return Results.Ok(result);
        }
    }
}
