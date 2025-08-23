using ExpenseTracker.Api.Features.Expenses.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapExpenseEndpoints();

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();