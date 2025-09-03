using ExpenseTracker.Api.Common.Validation;
using ExpenseTracker.Api.Features.Expenses.Endpoints;
using ExpenseTracker.Api.Features.Expenses.Repository;
using ExpenseTracker.Api.Features.Expenses.Validation;
using ExpenseTracker.Api.Infrastructure.DTO.Expense;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IValidator<CreateExpenseRequest>, CreateExpenseRequestValidator>();
builder.Services.AddTransient<IValidator<UpdateExpenseRequest>, UpdateExpenseRequestValidator>();

builder.Services.AddSingleton<IExpenseRepository, InMemoryExpensesRepository>();

var app = builder.Build();

app.MapExpenseEndpoints();

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();