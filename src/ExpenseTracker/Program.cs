using ExpenseTracker.Api.Common.Validation;
using ExpenseTracker.Api.Features.Expenses.Endpoints;
using ExpenseTracker.Api.Features.Expenses.Models;
using ExpenseTracker.Api.Features.Expenses.Repository;
using ExpenseTracker.Api.Features.Expenses.Services;
using ExpenseTracker.Api.Features.Expenses.Validation;
using ExpenseTracker.Api.Infrastructure.DTO.Expense;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(cfg => cfg.AddProfile<ExpenseMappingProfile>());

builder.Services.AddTransient<IValidator<CreateExpenseRequest>, CreateExpenseRequestValidator>();
builder.Services.AddTransient<IValidator<UpdateExpenseRequest>, UpdateExpenseRequestValidator>();

builder.Services.AddSingleton<IExpenseRepository, InMemoryExpensesRepository>();
builder.Services.AddSingleton<IExpenseService, ExpenseService>();

var app = builder.Build();

app.MapExpenseEndpoints();

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();